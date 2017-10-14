using System.Collections.Generic;

namespace _08_DictionaryTryGetContains
{
	public class DictionaryPerformanceRunner : IPerformanceRunner
	{
		private const int Size = 1000000;

		private readonly Dictionary<int, string> _dictionary;

		public DictionaryPerformanceRunner()
		{
			_dictionary = new Dictionary<int, string>();

			for (var i = 0; i < Size; i++)
			{
				_dictionary.Add(i, i.ToString());
			}
		}


		public string UsingContainsKey()
		{
			var result = string.Empty;
			for (var i = 0; i < Size; i++)
			{
				if (_dictionary.ContainsKey(i))
				{
					result = _dictionary[i];
				}
			}
			return result;
		}

		public string UsingTryGetValue()
		{
			var result = string.Empty;
			for (var i = 0; i < Size; i++)
			{
				_dictionary.TryGetValue(i, out result);
			}
			return result;
		}
	}

	public interface IPerformanceRunner
	{
	}
}