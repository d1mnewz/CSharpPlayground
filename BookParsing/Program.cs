using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using EpubSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using EpubBook = EpubSharp.EpubBook;
using EpubReader = EpubSharp.EpubReader;

namespace BookParsing
{
	internal class Program
	{
		public static void Main()
		{
			using (var reader = new PdfReader(new FileStream(@"C:\Users\d1mne\source\repos\CSharpPlayground\BookParsing\3.pdf", FileMode.Open)))
			{
				var text = new StringBuilder();

				for (var i = 3; i < reader.NumberOfPages - 1; i++)
				{
					text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
				}

				var dumm = text.ToString();
			}


			var fileStream = new FileStream(@"C:\Users\d1mne\source\repos\CSharpPlayground\BookParsing\1.epub", FileMode.Open);
			var dummy = ReadFully(fileStream);
			var epub = EpubReader.Read(fileStream, false);

			var plainText = epub.PayloadToPlainText(new List<string>
				{
					"cover",
					"title",
					"copyright",
					"table-of-content",
					"table_of_content",
					"kolofon",
					"titel"
				},
				new List<string>
				{
					"-1.xhtml",
					"-2.xhtml",
					"-3.xhtml",
					"-4.xhtml",
					"-5.xhtml",
					"-6.xhtml"
				});
		}

		public static byte[] ReadFully(Stream input)
		{
			var buffer = new byte[16 * 1024];
			using (var ms = new MemoryStream())
			{
				int read;
				while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
				{
					ms.Write(buffer, 0, read);
				}

				return ms.ToArray();
			}
		}
	}


	public static class EpubSharpExtensions
	{
		public static string PayloadToPlainText(this EpubBook epubBook, List<string> ignoredFiles,
			List<string> ignoredFileEndings)
		{
			var epubTextFiles = new List<EpubTextFile>();

			for (var index = 0; index < epubBook.SpecialResources.HtmlInReadingOrder.Count; index++)
			{
				var epubTextFile = epubBook.SpecialResources.HtmlInReadingOrder[index];
				var skipFile = ignoredFiles.Any(ignoredFile => epubTextFile.FileName.ToLower().Contains(ignoredFile))
				               || ignoredFileEndings.Any(f => epubTextFile.FileName.ToLower().EndsWith(f));
				if (!skipFile) epubTextFiles.Add(epubTextFile);
			}

			var builder = new StringBuilder();
			for (var index = 0; index < epubTextFiles.Count; index++)
			{
				var html = epubTextFiles[index];
				var contentAsPlainText = HtmlProcessor.GetContentAsPlainText(WebUtility.HtmlDecode(html.TextContent));
				builder.Append(contentAsPlainText);
				builder.Append('\n');
			}

			return builder.ToString().Trim();
		}
	}

	internal static class HtmlProcessor
	{
		private static readonly RegexOptions RegexOptions =
			RegexOptions.CultureInvariant | RegexOptions.IgnorePatternWhitespace | RegexOptions.ExplicitCapture;

		private static readonly RegexOptions RegexOptionsIgnoreCase = RegexOptions.IgnoreCase | RegexOptions;

		private static readonly RegexOptions RegexOptionsIgnoreCaseSingleLine =
			RegexOptions.Singleline | RegexOptionsIgnoreCase;

		private static readonly RegexOptions RegexOptionsIgnoreCaseMultiLine = RegexOptions.Multiline | RegexOptionsIgnoreCase;

		public static string GetContentAsPlainText(string html)
		{
			if (string.IsNullOrWhiteSpace(html)) throw new ArgumentNullException(nameof(html));

			html = html.Trim();
			html = Regex.Replace(html, @"\r\n?|\n", "");
			var match = Regex.Match(html, @"<body[^>]*>.+</body>", RegexOptionsIgnoreCaseSingleLine);
			return match.Success ? ClearText(match.Value).Trim(' ', '\r', '\n') : "";
		}

		private static string ClearText(string text)
		{
			if (text == null) return null;

			var result = ReplaceBlockTagsWithNewLines(text);
			result = RemoveHtmlTags(result);
			result = DecodeHtmlSymbols(result);
			return result;
		}

		private static string RemoveHtmlTags(string text)
		{
			return text == null ? null : Regex.Replace(text, @"</?(\w+|\s*!--)[^>]*>", " ", RegexOptions);
		}

		private static string ReplaceBlockTagsWithNewLines(string text)
		{
			return text is null
				? null
				: Regex.Replace(text, @"(?<!^\s*)<(p|div|h1|h2|h3|h4|h5|h6)[^>]*>", "\n", RegexOptionsIgnoreCaseMultiLine);
		}

		private static string DecodeHtmlSymbols(string text)
		{
			if (text is null) return null;
			var regex = new Regex(
				@"(?<defined>(&nbsp|&quot|&mdash|&ldquo|&rdquo|\&\#8211|\&\#8212|&\#8230|\&\#171|&laquo|&raquo|&amp);?)|(?<other>\&\#\d+;?)",
				RegexOptionsIgnoreCase);
			text = Regex.Replace(regex.Replace(text, SpecialSymbolsEvaluator), @"\ {2,}", " ", RegexOptions);
			text = WebUtility.HtmlDecode(text);
			return text;
		}

		private static string SpecialSymbolsEvaluator(Match m)
		{
			if (!m.Groups["defined"].Success) return " ";
			switch (m.Groups["defined"].Value.ToLower())
			{
				case "&nbsp;": return " ";
				case "&nbsp": return " ";
				case "&quot;": return "\"";
				case "&quot": return "\"";
				case "&mdash;": return " ";
				case "&mdash": return " ";
				case "&ldquo;": return "\"";
				case "&ldquo": return "\"";
				case "&rdquo;": return "\"";
				case "&rdquo": return "\"";
				case "&#8211;": return "-";
				case "&#8211": return "-";
				case "&#8212;": return "-";
				case "&#8212": return "-";
				case "&#8230": return "...";
				case "&#171;": return "\"";
				case "&#171": return "\"";
				case "&laquo;": return "\"";
				case "&laquo": return "\"";
				case "&raquo;": return "\"";
				case "&raquo": return "\"";
				case "&amp;": return "&";
				case "&amp": return "&";
				default: return " ";
			}
		}
	}
}