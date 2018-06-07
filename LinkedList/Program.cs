using System;
using System.Runtime.InteropServices;
using System.Text;

namespace LinkedList
{
	class Program
	{
		static void Main()
		{
			Console.WriteLine("Hello World!");
			var list = new LinkedList<int>();
			list.AddLast(0);
			list.AddLast(3);
			list.AddFirst(5);
			Console.WriteLine(list.ToString());
			Console.ReadKey();
		}
	}

	public class Node<T>
	{
		public T Value { get; set; }
		public Node<T> Next { get; set; }
	}

	public class LinkedList<T>
	{
		private Node<T> _head;
		private Node<T> _tail;

		public void AddLast(T value)
		{
			if (_head is null)
			{
				_head = new Node<T> { Value = value };
				_tail = _head;
			}
			else
			{
				_tail.Next = new Node<T> { Value = value };
				_tail = _tail.Next;
			}
		}

		public void AddFirst(T value)
		{
			var newHead = new Node<T> { Value = value, Next = _head };
			_head = newHead;
		}

		public override string ToString()
		{
			if (_head != null)
			{
				var sb = new StringBuilder();
				var current = _head;
				sb.Append($"{current.Value} ");

				while (current.Next != null)
				{
					current = current.Next;
					sb.Append($"{current.Value} ");
				}


				return sb.ToString();
			}

			return String.Empty;
		}
	}
}