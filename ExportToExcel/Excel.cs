using System.Collections.Generic;
using System.IO;
using System.Linq;
using ClosedXML.Excel;

namespace Examples
{
	public static class Excel
	{
		public static byte[] Generate<T>(IEnumerable<T> rows, string[] headers)
		{
			using (var workbook = new XLWorkbook())
			{
				var worksheet = workbook.Worksheets.Add("Plan1");

				for (var i = 0; i < headers.Count(); i++)
				{
					worksheet.Cell(1, i + 1).Value = headers[i];
				}

				worksheet.Cell(2, 1).InsertData(rows);

				using (var memoryStream = new MemoryStream())
				{
					workbook.SaveAs(memoryStream);
					return memoryStream.ToArray();
				}
			}
		}
	}
}