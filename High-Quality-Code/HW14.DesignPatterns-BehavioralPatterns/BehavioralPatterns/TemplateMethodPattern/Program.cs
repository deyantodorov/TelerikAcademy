using System;

namespace TemplateMethodPattern
{
    public class Program
    {
        private static void Main()
        {
            DataExporter exporter = new ExcelExporter();
            exporter.ExportFormatedData();

            Console.WriteLine();

            exporter = new PdfExporter();
            exporter.ExportFormatedData();
        }
    }
}
