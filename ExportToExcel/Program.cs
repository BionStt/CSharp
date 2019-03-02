using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Examples
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			var list = new List<Data>();

			for (int i = 1; i <= 10; i++)
			{
				list.Add(new Data { Long = i, String = $"String {i}", DateTime = DateTime.Now });
			}

			var rows = list.Select(x => new { x.Long, x.String });

			var headers = new string[] { "Header 1", "Header 2" };

			var bytes = Excel.Generate(rows, headers);

			File.WriteAllBytes(@"C:\Teste.xlsx", bytes);
		}
	}
}