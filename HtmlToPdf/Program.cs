using OpenHtmlToPdf;
using System;
using System.IO;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            //var basePath = AppDomain.CurrentDomain.BaseDirectory;

            var basePath = Environment.CurrentDirectory;

            var filesPath = Path.Combine(basePath, "Files");

            var pdfPath = Path.Combine(filesPath, "template.pdf");

            var htmlPath = Path.Combine(filesPath, "template.html");

            var html = File.ReadAllText(htmlPath);

            var pdf = Pdf
                .From(html)
                .OfSize(PaperSize.A4)
                .WithTitle("PDF")
                .WithoutOutline()
                .WithMargins(1.Centimeters())
                .Portrait()
                .Comressed()
                .Content();

            File.WriteAllBytes(pdfPath, pdf);
        }
    }
}