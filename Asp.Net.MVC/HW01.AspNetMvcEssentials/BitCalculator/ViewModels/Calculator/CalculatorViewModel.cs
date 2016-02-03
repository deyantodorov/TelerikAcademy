using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BitCalculator.ViewModels.Calculator
{
    public class CalculatorViewModel
    {
        public CalculatorViewModel()
        {
            this.Quantity = 1;
            this.TypeId = 0;
            this.TypeList = new List<SelectListItem>();
            this.KiloId = 0;
            this.KiloList = new List<SelectListItem>();
            this.GetBit = 1;
        }

        [Required]
        public int Quantity { get; set; }

        [Display(Name = "Type")]
        [Required]
        public int TypeId { get; set; }
        public IEnumerable<SelectListItem> TypeList { get; set; }

        [Display(Name = "Storage or Bandwidth")]
        [Required]
        public int KiloId { get; set; }
        public IEnumerable<SelectListItem> KiloList { get; set; }

        public double GetBit { get; set; }

        public double GetByte { get; set; }

        public double GetKilobit { get; set; }

        public double GetKilobyte { get; set; }

        public double GetMegabit { get; set; }

        public double GetMegabyte { get; set; }

        public double GetGigabit { get; set; }

        public double GetGigabyte { get; set; }

        public double GetTerabit { get; set; }

        public double GetTerabyte { get; set; }

        public double GetPetabit { get; set; }

        public double GetPetabyte { get; set; }

        public double GetExabit { get; set; }

        public double GetExabyte { get; set; }

        public double GetZettabit { get; set; }

        public double GetZettabyte { get; set; }

        public double GetYottabit { get; set; }

        public double GetYottabyte { get; set; }
    }
}