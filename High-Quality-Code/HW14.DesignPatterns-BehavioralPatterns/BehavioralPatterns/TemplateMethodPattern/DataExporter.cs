using System;

namespace TemplateMethodPattern
{
    public abstract class DataExporter
    {
        public void ReadData()
        {
            Console.WriteLine("Reading the data from SQL Server");
        }

        public void FormatData()
        {
            Console.WriteLine("Formating the data as per requriements.");   
        }

        public abstract void ExportData();

        public void ExportFormatedData()
        {
            this.ReadData();
            this.FormatData();
            this.ExportData();
        }
    }
}
