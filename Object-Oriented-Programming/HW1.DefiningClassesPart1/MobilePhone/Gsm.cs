namespace MobilePhone
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Gsm
    {
        private static readonly Gsm iPhone4S = new Gsm("iPhone 4s", "Apple", 1000, new Person("Ivan", "Ivanov"), new Battery("iSiktir", 0, 0, BatteryType.LiIon), new Display(7, 256000));
        private string model;
        private string manufacturer;
        private decimal price;

        public Gsm(string model, string manufacturer)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.CallHistory = new List<Call>();
        }

        public Gsm(string model, string manufacturer, decimal price = 0, Person owner = null, Battery battery = null, Display display = null)
            : this(model, manufacturer)
        {
            this.Price = price;
            this.Owner = owner;
            this.Battery = battery;
            this.Display = display;
        }

        public static Gsm IPhone4s
        {
            get { return iPhone4S; }
        }

        public List<Call> CallHistory { get; set; }

        public Person Owner { get; set; }

        public Battery Battery { get; set; }

        public Display Display { get; set; }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                DataValidator.NegativeNumber("Price", value);
                this.price = value;
            }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }

            set
            {
                DataValidator.StringNullEmptyValidation("Manufacturer", value);
                this.manufacturer = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            set
            {
                DataValidator.StringNullEmptyValidation("Model", value);
                this.model = value;
            }
        }

        public void AddCall(Call newCall)
        {
            this.CallHistory.Add(newCall);
        }

        public void ClearCallHistory()
        {
            this.CallHistory.Clear();
        }

        public void RemoveCallHistory()
        {
            Console.WriteLine("Remove history call for number 1 to {0}: ", this.CallHistory.Count);
            this.DisplayCallHistory();

            int callToRemove = int.Parse(Console.ReadLine());

            if (callToRemove < 1 || callToRemove > this.CallHistory.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid value");
            }

            this.CallHistory.RemoveAt(callToRemove - 1);
        }

        public void DisplayCallHistory()
        {
            if (this.CallHistory.Count > 0)
            {
                int number = 1;
                foreach (var call in this.CallHistory)
                {
                    Console.WriteLine(call);
                    number++;
                }
            }
            else
            {
                Console.WriteLine("Call history is empty...");
            }
        }

        public decimal CalcPricePerMinute(decimal pricePerMinute)
        {
            decimal pricePerSecond = pricePerMinute / 60;
            decimal totalPrice = 0;
            int totalSeconds = 0;

            foreach (var call in this.CallHistory)
            {
                totalSeconds += call.Duration;
            }

            if (totalSeconds != 0)
            {
                totalPrice = totalSeconds * pricePerSecond;
                return totalPrice;
            }

            return 0;
        }

        public void RemoveLongestCallAndCalcPpm(decimal pricePerMinute)
        {
            int maxIndex = 0;
            int maxCallHistory = this.CallHistory[maxIndex].Duration;

            for (int i = 1; i < this.CallHistory.Count; i++)
            {
                if (this.CallHistory[i].Duration > maxCallHistory)
                {
                    maxIndex = i;
                }
            }

            this.CallHistory.RemoveAt(maxIndex);

            this.CalcPricePerMinute(pricePerMinute);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Model: " + this.Model);
            sb.AppendLine("Manufacturer: " + this.Manufacturer);
            sb.AppendLine("Price: " + this.Price);
            sb.AppendLine(string.Format("Owner: ({0})", this.Owner.ToString()));
            sb.AppendLine(string.Format("Battery: ({0})", this.Battery.ToString()));
            sb.AppendLine(string.Format("Display: ({0})", this.Display.ToString()));

            return sb.ToString();
        }
    }
}
