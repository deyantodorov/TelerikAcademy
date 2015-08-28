namespace FurnitureManufacturer.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Interfaces;

    public class Company : ICompany
    {
        private const int NameMinValue = 5;
        private const int RegistrationLength = 10;

        private string name;
        private string registrationNumber;
        private ICollection<IFurniture> furnitures;

        public Company(string name, string registrationNumber)
        {
            this.Name = name;
            this.RegistrationNumber = registrationNumber;
            this.Furnitures = new List<IFurniture>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validation.StringIsNullOrEmpty(value, "Name");
                Validation.LessThan(value.Length, Company.NameMinValue, "Name");
                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get
            {
                return this.registrationNumber;
            }

            private set
            {
                Validation.StringIsNullOrEmpty(value, "RegistrationNumber");
                Validation.IsInRange(value.Length, "RegistrationNumber", Company.RegistrationLength, Company.RegistrationLength);
                Validation.IsDigits(value, "RegistrationNumber");
                this.registrationNumber = value;
            }
        }

        public ICollection<IFurniture> Furnitures
        {
            get
            {
                return this.furnitures;
            }

            private set
            {
                Validation.IsNull(value, "Furnitures");
                this.furnitures = value;
            }
        }

        public void Add(IFurniture furniture)
        {
            this.Furnitures.Add((furniture));
        }

        public void Remove(IFurniture furniture)
        {
            this.Furnitures.Remove(furniture);
        }

        public IFurniture Find(string model)
        {
            return this.Furnitures.FirstOrDefault(x => x.Model.ToUpper().Equals(model.ToUpper()));
        }

        public string Catalog()
        {
            var sb = new StringBuilder();

            sb.AppendLine(string.Format("{0} - {1} - {2} {3}",
                this.Name,
                this.RegistrationNumber,
                this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no",
                this.Furnitures.Count != 1 ? "furnitures" : "furniture"
                ));

            if (this.Furnitures.Count > 0)
            {
                var sortFurniturs = this.Furnitures.OrderBy(x => x.Price).ThenBy(x => x.Model);

                foreach (var furniture in sortFurniturs)
                {
                    sb.AppendLine(furniture.ToString());
                }
            }

            return sb.ToString().Trim();
        }

        public override string ToString()
        {
            return this.Catalog();
        }
    }
}