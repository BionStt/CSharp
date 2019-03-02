using System;
using System.Collections.Generic;
using System.Linq;

public static class Generator
{
	private static string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

	private static int depth = 2;

	private static string lastLetter = string.Empty.PadLeft(depth, 'Z');

	private static int lastNumber = 999999;

	public static List<Item> GenerateIntervalItens(List<Item> items)
	{
		//Permute alphabet
		var alphabet = PermuteAlphabet(depth).ToArray();

		//Order itens
		items = OrderItens(items);

		var iterationItens = items.ToList();

		for (int i = 0; i < iterationItens.Count; i++)
		{
			if (i + 1 >= iterationItens.Count) { break; }

			var currentItem = iterationItens[i];
			var nextItem = iterationItens[i + 1];

			var newItem = new Item(string.Empty, 0, string.Empty, 0, true);

			//Start
			if (currentItem.LetterEnd.EndsWith("Z") && currentItem.NumberEnd == lastNumber)
			{
				var index = Array.IndexOf(alphabet, currentItem.LetterEnd);
				newItem.LetterStart = alphabet[index + 1];
				newItem.NumberStart = 1;
			}
			else
			{
				newItem.LetterStart = currentItem.LetterEnd;
				newItem.NumberStart = currentItem.NumberEnd + 1;
			}

			//End
			if (nextItem.LetterStart.EndsWith("A") && currentItem.NumberStart == 1)
			{
				var index = Array.IndexOf(alphabet, nextItem.LetterStart);
				newItem.LetterEnd = alphabet[index - 1];
				newItem.NumberEnd = lastNumber;
			}
			else
			{
				newItem.LetterEnd = nextItem.LetterStart;
				newItem.NumberEnd = nextItem.NumberStart - 1;
			}

			items.Add(newItem);
		}

		//Order itens
		items = OrderItens(items);

		//First Item
		if (!items.FirstOrDefault().LetterStart.Equals("A") || items.FirstOrDefault().NumberStart > 1)
		{
			var firstItem = new Item("A", 1, items.FirstOrDefault().LetterStart, items.FirstOrDefault().NumberStart - 1, true);

			if (firstItem.NumberEnd <= 0)
			{
				firstItem.NumberEnd = lastNumber;
				firstItem.LetterEnd = alphabet[Array.IndexOf(alphabet, items.FirstOrDefault().LetterStart) - 1];
			}

			items.Add(firstItem);
		}

		//Order itens
		items = OrderItens(items);

		//Last Item
		if (!items.LastOrDefault().LetterEnd.Equals(lastLetter) || items.LastOrDefault().NumberEnd < lastNumber)
		{
			var lastItem = new Item(items.LastOrDefault().LetterEnd, items.LastOrDefault().NumberEnd + 1, lastLetter, lastNumber, true);

			if (lastItem.NumberStart >= lastNumber)
			{
				lastItem.NumberStart = 1;
				lastItem.LetterStart = alphabet[Array.IndexOf(alphabet, items.LastOrDefault().LetterEnd) + 1];
			}

			items.Add(lastItem);
		}

		//Order itens
		items = OrderItens(items);

		return items.Where(x => x.IsGenerated).ToList();
	}

	private static List<Item> OrderItens(List<Item> items)
	{
		return items.OrderBy(x => x.LetterStart.Length).ThenBy(x => x.LetterStart).ThenBy(x => x.NumberStart).ToList();
	}

	private static IEnumerable<string> PermuteAlphabet(int depth = 1)
	{
		var letters = new List<string>();
		if (depth > 1) { alphabet.ToList().ForEach(letter => letters.Add(letter.ToString())); }
		letters.AddRange(PermuteAlphabetRecursive(depth).ToList());
		return letters;
	}

	private static IEnumerable<string> PermuteAlphabetRecursive(int depth)
	{
		foreach (var letter in alphabet)
		{
			if (depth == 1) { yield return letter.ToString(); }
			else { foreach (var letters in PermuteAlphabetRecursive(depth - 1)) { yield return letter + letters; } }
		}
	}
}

public class Item
{
	public Item(string letterStart, long numberStart, string letterEnd, long numberEnd, bool isGenerated = false)
	{
		LetterStart = letterStart;
		NumberStart = numberStart;
		LetterEnd = letterEnd;
		NumberEnd = numberEnd;
		IsGenerated = isGenerated;
	}

	public bool IsGenerated { get; set; }
	public string LetterEnd { get; set; }
	public string LetterStart { get; set; }
	public long NumberEnd { get; set; }
	public long NumberStart { get; set; }
}

internal class Program
{
	private static void Main(string[] args)
	{
		var items = new List<Item>
		{
			new Item("A", 3, "F", 800),
			new Item("F", 900, "F", 950),
			new Item("BB", 250, "BB", 450),
			new Item("CD", 300, "CP", 100),
			new Item("DA", 500, "EE", 200),
			new Item("EG", 600, "FB", 350)
		};

		foreach (var item in Generator.GenerateIntervalItens(items))
		{
			Console.WriteLine("{0}:{1} - {2}:{3} \n",
				item.LetterStart.PadLeft(2, ' '),
				item.NumberStart.ToString().PadLeft(6, '0'),
				item.LetterEnd.PadLeft(2, ' '),
				item.NumberEnd.ToString().PadLeft(6, '0'));
		}

		Console.ReadKey();
	}
}