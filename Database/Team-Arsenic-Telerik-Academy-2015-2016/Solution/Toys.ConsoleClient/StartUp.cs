﻿namespace Toys.ConsoleClient
{
    using Toys.Data;
    using Toys.Core;
    using Toys.Core.ReportsExporters.JsonExporter;

    public class StartUp
    {
        private static void Main()
        {
            var context = new ToysDbContext();
            var db = new ToysData(context);

            var dataManager = new DataManager();
            dataManager.Start();
        }
    }
}