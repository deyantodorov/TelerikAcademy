namespace Toys.XmlReportExporter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Toys.Data;

    public class DbReportsDataExtractor
    {
        public List<Report> GetData(object db)
        {
            var dbContext = db as ToysDbContext;
            var reportsList = new List<Report>();

            var reportsData = dbContext.Manufacturers
                .Join(
                    dbContext.Products,
                    manufacturer => manufacturer.Id,
                    product => product.ManufacturerId,
                    (manufacturer, product) => new { manufacturer, product })
                    .Join(
                        dbContext.Countries,
                        mn => mn.manufacturer.CountryId,
                        country => country.Id,
                        (mn, country) => new { mn, country })
                        .Join(
                            dbContext.Sales,
                            mmn => mmn.mn.product.Id,
                            sales => sales.ProductId,
                            (mmn, sales) => new { mmn, sales })
                            .Join(
                                dbContext.Sellers,
                                mmmn => mmmn.sales.SellerId,
                                seller => seller.Id,
                                (mmmn, seller) => new { mmmn, seller })
                                .Select(x => new
                                {
                                    ManufacturerName = x.mmmn.mmn.mn.manufacturer.Name,
                                    ManufacturerEmail = x.mmmn.mmn.mn.manufacturer.Email,
                                    Country = x.mmmn.mmn.country.Name,
                                    ProductDescription = x.mmmn.mmn.mn.product.Description,
                                    Quantity = x.mmmn.sales.Quantity,
                                    ProductRetailPrice = x.mmmn.mmn.mn.product.RetailPrice,
                                    ProductWholesalePrice = x.mmmn.mmn.mn.product.WholesalePrice,
                                    Seller = x.seller.Name,
                                    OrderDate = x.mmmn.sales.Date
                                })
                                .GroupBy(x => x.Seller)
                                .ToList();

            foreach (var group in reportsData)
            {
                foreach (var entry in group)
                {
                    reportsList.Add(new Report()
                        {
                            SellerName = group.Key.ToString(),
                            OrderDate = entry.OrderDate,
                            Quantity = (uint)entry.Quantity,
                            CountryOfOrigin = entry.Country,
                            ManufacturerName = entry.ManufacturerName,
                            ManufacturerEmail = entry.ManufacturerEmail,
                            ProductDescription = entry.ProductDescription,
                            RetailPrice = (decimal)entry.ProductRetailPrice,
                            WholesalePrice = (decimal)entry.ProductWholesalePrice
                        });
                }
            }

            return reportsList;
        }
    }
}
