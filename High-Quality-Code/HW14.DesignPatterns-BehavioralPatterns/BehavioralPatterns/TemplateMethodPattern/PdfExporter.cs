using System;

namespace TemplateMethodPattern
{
    public class PdfExporter : DataExporter
    {
        public override void ExportData()
        {
            Console.WriteLine("Exporting the data to a PDF file.");
        }
    }
}
