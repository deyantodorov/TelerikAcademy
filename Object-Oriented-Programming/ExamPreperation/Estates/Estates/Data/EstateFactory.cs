using Estates.Engine;
using Estates.Interfaces;
using System;

namespace Estates.Data
{
    public class EstateFactory
    {
        public static IEstateEngine CreateEstateEngine()
        {
            return new EstateEngineExtended();
        }

        public static IEstate CreateEstate(EstateType type)
        {
            IEstate estate = null;

            switch (type)
            {
                case EstateType.Apartment:
                    estate = new Apartment();
                    break;
                case EstateType.Garage:
                    estate = new Garage();
                    break;
                case EstateType.House:
                    estate = new House();
                    break;
                case EstateType.Office:
                    estate = new Office();
                    break;
                default:
                    throw new ArgumentException("Unsupported estate type");
            }

            return estate;
        }

        public static IOffer CreateOffer(OfferType type)
        {
            IOffer offer = null;

            switch (type)
            {
                case OfferType.Rent:
                    offer = new RentOffer(OfferType.Rent);
                    break;
                case OfferType.Sale:
                    offer = new SaleOffer(OfferType.Sale);
                    break;
                default:
                    throw new ArgumentException("Unsuported office type");
            }

            return offer;
        }
    }
}