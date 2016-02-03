using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BitCalculator.ViewModels.Calculator;

namespace BitCalculator.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var model = new CalculatorViewModel();

            IEnumerable<CalculatorType> calculatorType = Enum.GetValues(typeof(CalculatorType)).Cast<CalculatorType>();
            IEnumerable<CalculatorKilo> calculatorKilo = Enum.GetValues(typeof(CalculatorKilo)).Cast<CalculatorKilo>();

            model.TypeList = GetTypeList(calculatorType, model.TypeId);
            model.KiloList = GetKiloList(calculatorKilo, model.KiloId);

            model = GetModelResult(model);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(CalculatorViewModel input)
        {
            var model = new CalculatorViewModel();

            IEnumerable<CalculatorType> calculatorType = Enum.GetValues(typeof(CalculatorType)).Cast<CalculatorType>();
            IEnumerable<CalculatorKilo> calculatorKilo = Enum.GetValues(typeof(CalculatorKilo)).Cast<CalculatorKilo>();

            model.TypeList = GetTypeList(calculatorType, input.TypeId);
            model.KiloList = GetKiloList(calculatorKilo, input.KiloId);

            model.Quantity = input.Quantity;
            model.TypeId = input.TypeId;
            model.KiloId = input.KiloId;

            // Calculate
            model = GetModelResult(model);

            return View(model);
        }

        private CalculatorViewModel GetModelResult(CalculatorViewModel model)
        {
            // TypeId:  
            // <option value="0">Bit</option>
            // <option value="1">Byte</option>
            // <option value="2">Kilobit</option>
            // <option value="3">Kilobyte</option>
            // <option value="4">Megabit</option>
            // <option value="5">Megabyte</option>
            // <option value="6">Gigabit</option>
            // <option value="7">Gigabyte</option>
            // <option value="8">Terabit</option>
            // <option value="9">Terabyte</option>
            // <option value="10">Petabit</option>
            // <option value="11">Petabyte</option>
            // <option value="12">Exabit</option>
            // <option value="13">Exabyte</option>
            // <option value="14">Zettabit</option>
            // <option value="15">Zettabyte</option>
            // <option value="16">Yottabit</option>
            // <option value="17">Yottabyte</option>

            // KiloId: 
            // <option value="0">Bandwidth1000</option>
            // <option value="1">Storage1024</option>

            var result = new CalculatorViewModel();

            if (model.TypeId == 0)
            {
                result = GetBitModel(model);
            }
            else if (model.TypeId == 1)
            {
                result = GetByteModel(model);
            }
            else if (model.TypeId == 2)
            {
                result = GetKilobitModel(model);
            }
            else if (model.TypeId == 3)
            {
                result = GetKilobyteModel(model);
            }
            else if (model.TypeId == 4)
            {
                result = GetMegabitModel(model);
            }
            else if (model.TypeId == 5)
            {
                result = GetMegabyteModel(model);
            }
            else if (model.TypeId == 6)
            {
                result = GetGigabitModel(model);
            }
            else if (model.TypeId == 7)
            {
                result = GetGigabyteModel(model);
            }
            else if (model.TypeId == 8)
            {
                result = GetTerabitModel(model);
            }
            else if (model.TypeId == 9)
            {
                result = GetTerabyteModel(model);
            }
            else if (model.TypeId == 10)
            {
                result = GetPetabitModel(model);
            }
            else if (model.TypeId == 11)
            {
                result = GetPetabyteModel(model);
            }
            else if (model.TypeId == 12)
            {
                result = GetExabitModel(model);
            }
            else if (model.TypeId == 13)
            {
                result = GetExabyteModel(model);
            }
            else if (model.TypeId == 14)
            {
                result = GetZettabitModel(model);
            }
            else if (model.TypeId == 15)
            {
                result = GetZettabyteModel(model);
            }
            else if (model.TypeId == 16)
            {
                result = GetYottabitModel(model);
            }
            else if (model.TypeId == 17)
            {
                result = GetYottabyteModel(model);
            }
            else
            {
                throw new ArgumentException("Invalid type");
            }

            return result;
        }

        private IEnumerable<SelectListItem> GetKiloList(IEnumerable<CalculatorKilo> calculatorKilo, int id)
        {
            var result = calculatorKilo
                .Select(x => new SelectListItem
                {
                    Text = x.ToString(),
                    Value = ((int)x).ToString(),
                    Selected = x.Equals(id)
                });

            return result;
        }

        private IEnumerable<SelectListItem> GetTypeList(IEnumerable<CalculatorType> calculatorType, int id)
        {
            var result = calculatorType.
                Select(x => new SelectListItem
                {
                    Text = x.ToString(),
                    Value = ((int)x).ToString(),
                    Selected = x.Equals(id)
                });

            return result;
        }

        // Byte
        private CalculatorViewModel GetByteModel(CalculatorViewModel model)
        {
            double bytes = 8;
            double quantity = model.Quantity;

            var result = model;

            if (model.KiloId == 0) // Bandwidth1000
            {
                result.GetBit = quantity * bytes;
                result.GetByte = quantity;
                result.GetKilobit = (quantity / Math.Pow(10, 3)) * bytes;
                result.GetKilobyte = quantity / Math.Pow(10, 3);
                result.GetMegabit = (quantity / Math.Pow(10, 6)) * bytes;
                result.GetMegabyte = quantity / Math.Pow(10, 6);
                result.GetGigabit = (quantity / Math.Pow(10, 9)) * bytes;
                result.GetGigabyte = quantity / Math.Pow(10, 9);
                result.GetTerabit = (quantity / Math.Pow(10, 12)) * bytes;
                result.GetTerabyte = quantity / Math.Pow(10, 12);
                result.GetPetabit = (quantity / Math.Pow(10, 15)) * bytes;
                result.GetPetabyte = quantity / Math.Pow(10, 15);
                result.GetExabit = (quantity / Math.Pow(10, 18)) * bytes;
                result.GetExabyte = quantity / Math.Pow(10, 18);
                result.GetZettabit = (quantity / Math.Pow(10, 21)) * bytes;
                result.GetZettabyte = quantity / Math.Pow(10, 21);
                result.GetYottabit = (quantity / Math.Pow(10, 24)) * bytes;
                result.GetYottabyte = quantity / Math.Pow(10, 24);
            }
            else if (model.KiloId == 1) // Storage1024
            {
                result.GetBit = quantity * bytes;
                result.GetByte = quantity;
                result.GetKilobit = (quantity / Math.Pow(2, 10)) * bytes;
                result.GetKilobyte = quantity / Math.Pow(2, 10);
                result.GetMegabit = (quantity / Math.Pow(2, 20)) * bytes;
                result.GetMegabyte = quantity / Math.Pow(2, 20);
                result.GetGigabit = (quantity / Math.Pow(2, 30)) * bytes;
                result.GetGigabyte = quantity / Math.Pow(2, 30);
                result.GetTerabit = (quantity / Math.Pow(2, 40)) * bytes;
                result.GetTerabyte = quantity / Math.Pow(2, 40);
                result.GetPetabit = (quantity / Math.Pow(2, 50)) * bytes;
                result.GetPetabyte = quantity / Math.Pow(2, 50);
                result.GetExabit = (quantity / Math.Pow(2, 60)) * bytes;
                result.GetExabyte = quantity / Math.Pow(2, 60);
                result.GetZettabit = (quantity / Math.Pow(2, 70)) * bytes;
                result.GetZettabyte = quantity / Math.Pow(2, 70);
                result.GetYottabit = (quantity / Math.Pow(2, 80)) * bytes;
                result.GetYottabyte = quantity / Math.Pow(2, 80);
            }
            else
            {
                throw new ArgumentException();
            }

            return result;
        }

        private CalculatorViewModel GetKilobyteModel(CalculatorViewModel model)
        {
            double bytes = 8;
            double quantity = model.Quantity;

            var result = model;

            if (model.KiloId == 0) // Bandwidth1000
            {
                result.GetBit = quantity * (Math.Pow(10, 3)) * bytes;
                result.GetByte = quantity * (Math.Pow(10, 3));
                result.GetKilobit = quantity * bytes;
                result.GetKilobyte = quantity;
                result.GetMegabit = quantity / (Math.Pow(10, 3) * bytes);
                result.GetMegabyte = quantity / (Math.Pow(10, 3));
                result.GetGigabit = quantity / (Math.Pow(10, 6) * bytes);
                result.GetGigabyte = quantity / (Math.Pow(10, 6));
                result.GetTerabit = quantity / (Math.Pow(10, 9) * bytes);
                result.GetTerabyte = quantity / (Math.Pow(10, 9));
                result.GetPetabit = quantity / (Math.Pow(10, 12) * bytes);
                result.GetPetabyte = quantity / (Math.Pow(10, 12));
                result.GetExabit = quantity / (Math.Pow(10, 15) * bytes);
                result.GetExabyte = quantity / (Math.Pow(10, 15));
                result.GetZettabit = quantity / (Math.Pow(10, 18) * bytes);
                result.GetZettabyte = quantity / (Math.Pow(10, 18));
                result.GetYottabit = quantity / (Math.Pow(10, 21) * bytes);
                result.GetYottabyte = quantity / (Math.Pow(10, 21));
            }
            else if (model.KiloId == 1) // Storage1024
            {
                result.GetBit = quantity * bytes;
                result.GetByte = quantity;
                result.GetKilobit = quantity / (Math.Pow(2, 10));
                result.GetKilobyte = quantity / (Math.Pow(2, 10) * bytes);
                result.GetMegabit = quantity / (Math.Pow(2, 20));
                result.GetMegabyte = quantity / (Math.Pow(2, 20) * bytes);
                result.GetGigabit = quantity / (Math.Pow(2, 30));
                result.GetGigabyte = quantity / (Math.Pow(2, 30) * bytes);
                result.GetTerabit = quantity / (Math.Pow(2, 40));
                result.GetTerabyte = quantity / (Math.Pow(2, 40) * bytes);
                result.GetPetabit = quantity / (Math.Pow(2, 50));
                result.GetPetabyte = quantity / (Math.Pow(2, 50) * bytes);
                result.GetExabit = quantity / (Math.Pow(2, 60));
                result.GetExabyte = quantity / (Math.Pow(2, 60) * bytes);
                result.GetZettabit = quantity / (Math.Pow(2, 70));
                result.GetZettabyte = quantity / (Math.Pow(2, 70) * bytes);
                result.GetYottabit = quantity / (Math.Pow(2, 80));
                result.GetYottabyte = quantity / (Math.Pow(2, 80) * bytes);
            }
            else
            {
                throw new ArgumentException();
            }

            return result;
        }

        private CalculatorViewModel GetMegabyteModel(CalculatorViewModel model)
        {
            double bytes = 8;
            double quantity = model.Quantity;

            var result = model;

            if (model.KiloId == 0) // Bandwidth1000
            {
                result.GetBit = quantity * Math.Pow(10, 6) * bytes;
                result.GetByte = quantity * Math.Pow(10, 6);
                result.GetKilobit = quantity * (Math.Pow(10, 3)) * bytes;
                result.GetKilobyte = quantity * Math.Pow(10, 3);
                result.GetMegabit = quantity * bytes;
                result.GetMegabyte = quantity;
                result.GetGigabit = (quantity / Math.Pow(10, 3)) * bytes;
                result.GetGigabyte = quantity / Math.Pow(10, 3);
                result.GetTerabit = (quantity / Math.Pow(10, 6)) * bytes;
                result.GetTerabyte = quantity / Math.Pow(10, 6);
                result.GetPetabit = (quantity / Math.Pow(10, 9)) * bytes;
                result.GetPetabyte = quantity / Math.Pow(10, 9);
                result.GetExabit = (quantity / Math.Pow(10, 12)) * bytes;
                result.GetExabyte = quantity / Math.Pow(10, 12);
                result.GetZettabit = (quantity / Math.Pow(10, 15)) * bytes;
                result.GetZettabyte = quantity / Math.Pow(10, 15);
                result.GetYottabit = (quantity / Math.Pow(10, 18)) * bytes;
                result.GetYottabyte = quantity / Math.Pow(10, 18);
            }
            else if (model.KiloId == 1) // Storage1024
            {
                result.GetBit = (quantity * Math.Pow(2, 20)) * bytes;
                result.GetByte = quantity * Math.Pow(2, 20);
                result.GetKilobit = (quantity * Math.Pow(2, 10)) * bytes;
                result.GetKilobyte = quantity * Math.Pow(2, 10);
                result.GetMegabit = quantity * bytes;
                result.GetMegabyte = quantity;
                result.GetGigabit = (quantity / Math.Pow(2, 10)) * bytes;
                result.GetGigabyte = quantity / Math.Pow(2, 10);
                result.GetTerabit = (quantity / Math.Pow(2, 20)) * bytes;
                result.GetTerabyte = quantity / Math.Pow(2, 20);
                result.GetPetabit = (quantity / Math.Pow(2, 30)) * bytes;
                result.GetPetabyte = quantity / Math.Pow(2, 30);
                result.GetExabit = (quantity / Math.Pow(2, 40)) * bytes;
                result.GetExabyte = quantity / Math.Pow(2, 40);
                result.GetZettabit = (quantity / Math.Pow(2, 50)) * bytes;
                result.GetZettabyte = quantity / Math.Pow(2, 50);
                result.GetYottabit = (quantity / (Math.Pow(2, 60))) * bytes;
                result.GetYottabyte = quantity / Math.Pow(2, 60);
            }
            else
            {
                throw new ArgumentException();
            }

            return result;
        }

        private CalculatorViewModel GetGigabyteModel(CalculatorViewModel model)
        {
            double bytes = 8;
            double quantity = model.Quantity;

            var result = model;

            if (model.KiloId == 0) // Bandwidth1000
            {
                result.GetBit = quantity * bytes;
                result.GetByte = quantity;
                result.GetKilobit = (quantity / Math.Pow(10, 3)) * bytes;
                result.GetKilobyte = quantity / Math.Pow(10, 3);
                result.GetMegabit = (quantity / Math.Pow(10, 6)) * bytes;
                result.GetMegabyte = quantity / Math.Pow(10, 6);
                result.GetGigabit = (quantity / Math.Pow(10, 9)) * bytes;
                result.GetGigabyte = quantity / Math.Pow(10, 9);
                result.GetTerabit = (quantity / Math.Pow(10, 12)) * bytes;
                result.GetTerabyte = quantity / Math.Pow(10, 12);
                result.GetPetabit = (quantity / Math.Pow(10, 15)) * bytes;
                result.GetPetabyte = quantity / Math.Pow(10, 15);
                result.GetExabit = (quantity / Math.Pow(10, 18)) * bytes;
                result.GetExabyte = quantity / Math.Pow(10, 18);
                result.GetZettabit = (quantity / Math.Pow(10, 21)) * bytes;
                result.GetZettabyte = quantity / Math.Pow(10, 21);
                result.GetYottabit = (quantity / Math.Pow(10, 24)) * bytes;
                result.GetYottabyte = quantity / Math.Pow(10, 24);
            }
            else if (model.KiloId == 1) // Storage1024
            {
                result.GetBit = quantity * bytes;
                result.GetByte = quantity;
                result.GetKilobit = (quantity / Math.Pow(2, 10)) * bytes;
                result.GetKilobyte = quantity / Math.Pow(2, 10);
                result.GetMegabit = (quantity / Math.Pow(2, 20)) * bytes;
                result.GetMegabyte = quantity / Math.Pow(2, 20);
                result.GetGigabit = (quantity / Math.Pow(2, 30)) * bytes;
                result.GetGigabyte = quantity / Math.Pow(2, 30);
                result.GetTerabit = (quantity / Math.Pow(2, 40)) * bytes;
                result.GetTerabyte = quantity / Math.Pow(2, 40);
                result.GetPetabit = (quantity / Math.Pow(2, 50)) * bytes;
                result.GetPetabyte = quantity / Math.Pow(2, 50);
                result.GetExabit = (quantity / Math.Pow(2, 60)) * bytes;
                result.GetExabyte = quantity / Math.Pow(2, 60);
                result.GetZettabit = (quantity / Math.Pow(2, 70)) * bytes;
                result.GetZettabyte = quantity / Math.Pow(2, 70);
                result.GetYottabit = (quantity / Math.Pow(2, 80)) * bytes;
                result.GetYottabyte = quantity / Math.Pow(2, 80);
            }
            else
            {
                throw new ArgumentException();
            }

            return result;
        }

        private CalculatorViewModel GetTerabyteModel(CalculatorViewModel model)
        {
            double bytes = 8;
            double quantity = model.Quantity;

            var result = model;

            if (model.KiloId == 0) // Bandwidth1000
            {
                result.GetBit = quantity * bytes;
                result.GetByte = quantity;
                result.GetKilobit = (quantity / Math.Pow(10, 3)) * bytes;
                result.GetKilobyte = quantity / Math.Pow(10, 3);
                result.GetMegabit = (quantity / Math.Pow(10, 6)) * bytes;
                result.GetMegabyte = quantity / Math.Pow(10, 6);
                result.GetGigabit = (quantity / Math.Pow(10, 9)) * bytes;
                result.GetGigabyte = quantity / Math.Pow(10, 9);
                result.GetTerabit = (quantity / Math.Pow(10, 12)) * bytes;
                result.GetTerabyte = quantity / Math.Pow(10, 12);
                result.GetPetabit = (quantity / Math.Pow(10, 15)) * bytes;
                result.GetPetabyte = quantity / Math.Pow(10, 15);
                result.GetExabit = (quantity / Math.Pow(10, 18)) * bytes;
                result.GetExabyte = quantity / Math.Pow(10, 18);
                result.GetZettabit = (quantity / Math.Pow(10, 21)) * bytes;
                result.GetZettabyte = quantity / Math.Pow(10, 21);
                result.GetYottabit = (quantity / Math.Pow(10, 24)) * bytes;
                result.GetYottabyte = quantity / Math.Pow(10, 24);
            }
            else if (model.KiloId == 1) // Storage1024
            {
                result.GetBit = quantity * bytes;
                result.GetByte = quantity;
                result.GetKilobit = (quantity / Math.Pow(2, 10)) * bytes;
                result.GetKilobyte = quantity / Math.Pow(2, 10);
                result.GetMegabit = (quantity / Math.Pow(2, 20)) * bytes;
                result.GetMegabyte = quantity / Math.Pow(2, 20);
                result.GetGigabit = (quantity / Math.Pow(2, 30)) * bytes;
                result.GetGigabyte = quantity / Math.Pow(2, 30);
                result.GetTerabit = (quantity / Math.Pow(2, 40)) * bytes;
                result.GetTerabyte = quantity / Math.Pow(2, 40);
                result.GetPetabit = (quantity / Math.Pow(2, 50)) * bytes;
                result.GetPetabyte = quantity / Math.Pow(2, 50);
                result.GetExabit = (quantity / Math.Pow(2, 60)) * bytes;
                result.GetExabyte = quantity / Math.Pow(2, 60);
                result.GetZettabit = (quantity / Math.Pow(2, 70)) * bytes;
                result.GetZettabyte = quantity / Math.Pow(2, 70);
                result.GetYottabit = (quantity / Math.Pow(2, 80)) * bytes;
                result.GetYottabyte = quantity / Math.Pow(2, 80);
            }
            else
            {
                throw new ArgumentException();
            }

            return result;
        }

        private CalculatorViewModel GetPetabyteModel(CalculatorViewModel model)
        {
            double bytes = 8;
            double quantity = model.Quantity;

            var result = model;

            if (model.KiloId == 0) // Bandwidth1000
            {
                result.GetBit = quantity * bytes;
                result.GetByte = quantity;
                result.GetKilobit = (quantity / Math.Pow(10, 3)) * bytes;
                result.GetKilobyte = quantity / Math.Pow(10, 3);
                result.GetMegabit = (quantity / Math.Pow(10, 6)) * bytes;
                result.GetMegabyte = quantity / Math.Pow(10, 6);
                result.GetGigabit = (quantity / Math.Pow(10, 9)) * bytes;
                result.GetGigabyte = quantity / Math.Pow(10, 9);
                result.GetTerabit = (quantity / Math.Pow(10, 12)) * bytes;
                result.GetTerabyte = quantity / Math.Pow(10, 12);
                result.GetPetabit = (quantity / Math.Pow(10, 15)) * bytes;
                result.GetPetabyte = quantity / Math.Pow(10, 15);
                result.GetExabit = (quantity / Math.Pow(10, 18)) * bytes;
                result.GetExabyte = quantity / Math.Pow(10, 18);
                result.GetZettabit = (quantity / Math.Pow(10, 21)) * bytes;
                result.GetZettabyte = quantity / Math.Pow(10, 21);
                result.GetYottabit = (quantity / Math.Pow(10, 24)) * bytes;
                result.GetYottabyte = quantity / Math.Pow(10, 24);
            }
            else if (model.KiloId == 1) // Storage1024
            {
                result.GetBit = quantity * bytes;
                result.GetByte = quantity;
                result.GetKilobit = (quantity / Math.Pow(2, 10)) * bytes;
                result.GetKilobyte = quantity / Math.Pow(2, 10);
                result.GetMegabit = (quantity / Math.Pow(2, 20)) * bytes;
                result.GetMegabyte = quantity / Math.Pow(2, 20);
                result.GetGigabit = (quantity / Math.Pow(2, 30)) * bytes;
                result.GetGigabyte = quantity / Math.Pow(2, 30);
                result.GetTerabit = (quantity / Math.Pow(2, 40)) * bytes;
                result.GetTerabyte = quantity / Math.Pow(2, 40);
                result.GetPetabit = (quantity / Math.Pow(2, 50)) * bytes;
                result.GetPetabyte = quantity / Math.Pow(2, 50);
                result.GetExabit = (quantity / Math.Pow(2, 60)) * bytes;
                result.GetExabyte = quantity / Math.Pow(2, 60);
                result.GetZettabit = (quantity / Math.Pow(2, 70)) * bytes;
                result.GetZettabyte = quantity / Math.Pow(2, 70);
                result.GetYottabit = (quantity / Math.Pow(2, 80)) * bytes;
                result.GetYottabyte = quantity / Math.Pow(2, 80);
            }
            else
            {
                throw new ArgumentException();
            }

            return result;
        }

        private CalculatorViewModel GetExabyteModel(CalculatorViewModel model)
        {
            double bytes = 8;
            double quantity = model.Quantity;

            var result = model;

            if (model.KiloId == 0) // Bandwidth1000
            {
                result.GetBit = quantity * bytes;
                result.GetByte = quantity;
                result.GetKilobit = (quantity / Math.Pow(10, 3)) * bytes;
                result.GetKilobyte = quantity / Math.Pow(10, 3);
                result.GetMegabit = (quantity / Math.Pow(10, 6)) * bytes;
                result.GetMegabyte = quantity / Math.Pow(10, 6);
                result.GetGigabit = (quantity / Math.Pow(10, 9)) * bytes;
                result.GetGigabyte = quantity / Math.Pow(10, 9);
                result.GetTerabit = (quantity / Math.Pow(10, 12)) * bytes;
                result.GetTerabyte = quantity / Math.Pow(10, 12);
                result.GetPetabit = (quantity / Math.Pow(10, 15)) * bytes;
                result.GetPetabyte = quantity / Math.Pow(10, 15);
                result.GetExabit = (quantity / Math.Pow(10, 18)) * bytes;
                result.GetExabyte = quantity / Math.Pow(10, 18);
                result.GetZettabit = (quantity / Math.Pow(10, 21)) * bytes;
                result.GetZettabyte = quantity / Math.Pow(10, 21);
                result.GetYottabit = (quantity / Math.Pow(10, 24)) * bytes;
                result.GetYottabyte = quantity / Math.Pow(10, 24);
            }
            else if (model.KiloId == 1) // Storage1024
            {
                result.GetBit = quantity * bytes;
                result.GetByte = quantity;
                result.GetKilobit = (quantity / Math.Pow(2, 10)) * bytes;
                result.GetKilobyte = quantity / Math.Pow(2, 10);
                result.GetMegabit = (quantity / Math.Pow(2, 20)) * bytes;
                result.GetMegabyte = quantity / Math.Pow(2, 20);
                result.GetGigabit = (quantity / Math.Pow(2, 30)) * bytes;
                result.GetGigabyte = quantity / Math.Pow(2, 30);
                result.GetTerabit = (quantity / Math.Pow(2, 40)) * bytes;
                result.GetTerabyte = quantity / Math.Pow(2, 40);
                result.GetPetabit = (quantity / Math.Pow(2, 50)) * bytes;
                result.GetPetabyte = quantity / Math.Pow(2, 50);
                result.GetExabit = (quantity / Math.Pow(2, 60)) * bytes;
                result.GetExabyte = quantity / Math.Pow(2, 60);
                result.GetZettabit = (quantity / Math.Pow(2, 70)) * bytes;
                result.GetZettabyte = quantity / Math.Pow(2, 70);
                result.GetYottabit = (quantity / Math.Pow(2, 80)) * bytes;
                result.GetYottabyte = quantity / Math.Pow(2, 80);
            }
            else
            {
                throw new ArgumentException();
            }

            return result;
        }

        private CalculatorViewModel GetZettabyteModel(CalculatorViewModel model)
        {
            double bytes = 8;
            double quantity = model.Quantity;

            var result = model;

            if (model.KiloId == 0) // Bandwidth1000
            {
                result.GetBit = quantity * bytes;
                result.GetByte = quantity;
                result.GetKilobit = (quantity / Math.Pow(10, 3)) * bytes;
                result.GetKilobyte = quantity / Math.Pow(10, 3);
                result.GetMegabit = (quantity / Math.Pow(10, 6)) * bytes;
                result.GetMegabyte = quantity / Math.Pow(10, 6);
                result.GetGigabit = (quantity / Math.Pow(10, 9)) * bytes;
                result.GetGigabyte = quantity / Math.Pow(10, 9);
                result.GetTerabit = (quantity / Math.Pow(10, 12)) * bytes;
                result.GetTerabyte = quantity / Math.Pow(10, 12);
                result.GetPetabit = (quantity / Math.Pow(10, 15)) * bytes;
                result.GetPetabyte = quantity / Math.Pow(10, 15);
                result.GetExabit = (quantity / Math.Pow(10, 18)) * bytes;
                result.GetExabyte = quantity / Math.Pow(10, 18);
                result.GetZettabit = (quantity / Math.Pow(10, 21)) * bytes;
                result.GetZettabyte = quantity / Math.Pow(10, 21);
                result.GetYottabit = (quantity / Math.Pow(10, 24)) * bytes;
                result.GetYottabyte = quantity / Math.Pow(10, 24);
            }
            else if (model.KiloId == 1) // Storage1024
            {
                result.GetBit = quantity * bytes;
                result.GetByte = quantity;
                result.GetKilobit = (quantity / Math.Pow(2, 10)) * bytes;
                result.GetKilobyte = quantity / Math.Pow(2, 10);
                result.GetMegabit = (quantity / Math.Pow(2, 20)) * bytes;
                result.GetMegabyte = quantity / Math.Pow(2, 20);
                result.GetGigabit = (quantity / Math.Pow(2, 30)) * bytes;
                result.GetGigabyte = quantity / Math.Pow(2, 30);
                result.GetTerabit = (quantity / Math.Pow(2, 40)) * bytes;
                result.GetTerabyte = quantity / Math.Pow(2, 40);
                result.GetPetabit = (quantity / Math.Pow(2, 50)) * bytes;
                result.GetPetabyte = quantity / Math.Pow(2, 50);
                result.GetExabit = (quantity / Math.Pow(2, 60)) * bytes;
                result.GetExabyte = quantity / Math.Pow(2, 60);
                result.GetZettabit = (quantity / Math.Pow(2, 70)) * bytes;
                result.GetZettabyte = quantity / Math.Pow(2, 70);
                result.GetYottabit = (quantity / Math.Pow(2, 80)) * bytes;
                result.GetYottabyte = quantity / Math.Pow(2, 80);
            }
            else
            {
                throw new ArgumentException();
            }

            return result;
        }

        private CalculatorViewModel GetYottabyteModel(CalculatorViewModel model)
        {
            double bytes = 8;
            double quantity = model.Quantity;

            var result = model;

            if (model.KiloId == 0) // Bandwidth1000
            {
                result.GetBit = quantity * bytes;
                result.GetByte = quantity;
                result.GetKilobit = (quantity / Math.Pow(10, 3)) * bytes;
                result.GetKilobyte = quantity / Math.Pow(10, 3);
                result.GetMegabit = (quantity / Math.Pow(10, 6)) * bytes;
                result.GetMegabyte = quantity / Math.Pow(10, 6);
                result.GetGigabit = (quantity / Math.Pow(10, 9)) * bytes;
                result.GetGigabyte = quantity / Math.Pow(10, 9);
                result.GetTerabit = (quantity / Math.Pow(10, 12)) * bytes;
                result.GetTerabyte = quantity / Math.Pow(10, 12);
                result.GetPetabit = (quantity / Math.Pow(10, 15)) * bytes;
                result.GetPetabyte = quantity / Math.Pow(10, 15);
                result.GetExabit = (quantity / Math.Pow(10, 18)) * bytes;
                result.GetExabyte = quantity / Math.Pow(10, 18);
                result.GetZettabit = (quantity / Math.Pow(10, 21)) * bytes;
                result.GetZettabyte = quantity / Math.Pow(10, 21);
                result.GetYottabit = (quantity / Math.Pow(10, 24)) * bytes;
                result.GetYottabyte = quantity / Math.Pow(10, 24);
            }
            else if (model.KiloId == 1) // Storage1024
            {
                result.GetBit = quantity * bytes;
                result.GetByte = quantity;
                result.GetKilobit = (quantity / Math.Pow(2, 10)) * bytes;
                result.GetKilobyte = quantity / Math.Pow(2, 10);
                result.GetMegabit = (quantity / Math.Pow(2, 20)) * bytes;
                result.GetMegabyte = quantity / Math.Pow(2, 20);
                result.GetGigabit = (quantity / Math.Pow(2, 30)) * bytes;
                result.GetGigabyte = quantity / Math.Pow(2, 30);
                result.GetTerabit = (quantity / Math.Pow(2, 40)) * bytes;
                result.GetTerabyte = quantity / Math.Pow(2, 40);
                result.GetPetabit = (quantity / Math.Pow(2, 50)) * bytes;
                result.GetPetabyte = quantity / Math.Pow(2, 50);
                result.GetExabit = (quantity / Math.Pow(2, 60)) * bytes;
                result.GetExabyte = quantity / Math.Pow(2, 60);
                result.GetZettabit = (quantity / Math.Pow(2, 70)) * bytes;
                result.GetZettabyte = quantity / Math.Pow(2, 70);
                result.GetYottabit = (quantity / Math.Pow(2, 80)) * bytes;
                result.GetYottabyte = quantity / Math.Pow(2, 80);
            }
            else
            {
                throw new ArgumentException();
            }

            return result;
        }


        // Bit
        private CalculatorViewModel GetBitModel(CalculatorViewModel model)
        {
            double bytes = 8;
            double quantity = model.Quantity;

            var result = model;

            if (model.KiloId == 0) // Bandwidth1000
            {
                result.GetBit = quantity;
                result.GetByte = quantity / bytes;
                result.GetKilobit = quantity / (Math.Pow(10, 3));
                result.GetKilobyte = quantity / (Math.Pow(10, 3) * bytes);
                result.GetMegabit = quantity / (Math.Pow(10, 6));
                result.GetMegabyte = quantity / (Math.Pow(10, 6) * bytes);
                result.GetGigabit = quantity / (Math.Pow(10, 9));
                result.GetGigabyte = quantity / (Math.Pow(10, 9) * bytes);
                result.GetTerabit = quantity / (Math.Pow(10, 12));
                result.GetTerabyte = quantity / (Math.Pow(10, 12) * bytes);
                result.GetPetabit = quantity / (Math.Pow(10, 15));
                result.GetPetabyte = quantity / (Math.Pow(10, 15) * bytes);
                result.GetExabit = quantity / (Math.Pow(10, 18));
                result.GetExabyte = quantity / (Math.Pow(10, 18) * bytes);
                result.GetZettabit = quantity / (Math.Pow(10, 21));
                result.GetZettabyte = quantity / (Math.Pow(10, 21) * bytes);
                result.GetYottabit = quantity / (Math.Pow(10, 24));
                result.GetYottabyte = quantity / (Math.Pow(10, 24) * bytes);
            }
            else if (model.KiloId == 1) // Storage1024
            {
                result.GetBit = quantity;
                result.GetByte = quantity / bytes;
                result.GetKilobit = quantity / (Math.Pow(2, 10));
                result.GetKilobyte = quantity / (Math.Pow(2, 10) * bytes);
                result.GetMegabit = quantity / (Math.Pow(2, 20));
                result.GetMegabyte = quantity / (Math.Pow(2, 20) * bytes);
                result.GetGigabit = quantity / (Math.Pow(2, 30));
                result.GetGigabyte = quantity / (Math.Pow(2, 30) * bytes);
                result.GetTerabit = quantity / (Math.Pow(2, 40));
                result.GetTerabyte = quantity / (Math.Pow(2, 40) * bytes);
                result.GetPetabit = quantity / (Math.Pow(2, 50));
                result.GetPetabyte = quantity / (Math.Pow(2, 50) * bytes);
                result.GetExabit = quantity / (Math.Pow(2, 60));
                result.GetExabyte = quantity / (Math.Pow(2, 60) * bytes);
                result.GetZettabit = quantity / (Math.Pow(2, 70));
                result.GetZettabyte = quantity / (Math.Pow(2, 70) * bytes);
                result.GetYottabit = quantity / (Math.Pow(2, 80));
                result.GetYottabyte = quantity / (Math.Pow(2, 80) * bytes);
            }
            else
            {
                throw new ArgumentException();
            }

            return result;
        }

        private CalculatorViewModel GetKilobitModel(CalculatorViewModel model)
        {
            double bytes = 8;
            double quantity = model.Quantity;

            var result = model;

            if (model.KiloId == 0) // Bandwidth1000
            {
                result.GetBit = quantity * (Math.Pow(10, 3));
                result.GetByte = quantity * (Math.Pow(10, 3) / bytes);
                result.GetKilobit = quantity;
                result.GetKilobyte = quantity / bytes;
                result.GetMegabit = quantity / (Math.Pow(10, 3));
                result.GetMegabyte = quantity / (Math.Pow(10, 3) * bytes);
                result.GetGigabit = quantity / (Math.Pow(10, 6));
                result.GetGigabyte = quantity / (Math.Pow(10, 6) * bytes);
                result.GetTerabit = quantity / (Math.Pow(10, 9));
                result.GetTerabyte = quantity / (Math.Pow(10, 9) * bytes);
                result.GetPetabit = quantity / (Math.Pow(10, 12));
                result.GetPetabyte = quantity / (Math.Pow(10, 12) * bytes);
                result.GetExabit = quantity / (Math.Pow(10, 15));
                result.GetExabyte = quantity / (Math.Pow(10, 15) * bytes);
                result.GetZettabit = quantity / (Math.Pow(10, 18));
                result.GetZettabyte = quantity / (Math.Pow(10, 18) * bytes);
                result.GetYottabit = quantity / (Math.Pow(10, 21));
                result.GetYottabyte = quantity / (Math.Pow(10, 21) * bytes);
            }
            else if (model.KiloId == 1) // Storage1024
            {
                result.GetBit = quantity * (Math.Pow(2, 10));
                result.GetByte = quantity * (Math.Pow(2, 10) / bytes);
                result.GetKilobit = quantity;
                result.GetKilobyte = quantity / (bytes);
                result.GetMegabit = quantity / (Math.Pow(2, 10));
                result.GetMegabyte = quantity / (Math.Pow(2, 10) * bytes);
                result.GetGigabit = quantity / (Math.Pow(2, 20));
                result.GetGigabyte = quantity / (Math.Pow(2, 20) * bytes);
                result.GetTerabit = quantity / (Math.Pow(2, 30));
                result.GetTerabyte = quantity / (Math.Pow(2, 30) * bytes);
                result.GetPetabit = quantity / (Math.Pow(2, 40));
                result.GetPetabyte = quantity / (Math.Pow(2, 40) * bytes);
                result.GetExabit = quantity / (Math.Pow(2, 50));
                result.GetExabyte = quantity / (Math.Pow(2, 50) * bytes);
                result.GetZettabit = quantity / (Math.Pow(2, 60));
                result.GetZettabyte = quantity / (Math.Pow(2, 60) * bytes);
                result.GetYottabit = quantity / (Math.Pow(2, 70));
                result.GetYottabyte = quantity / (Math.Pow(2, 70) * bytes);
            }
            else
            {
                throw new ArgumentException();
            }

            return result;
        }

        private CalculatorViewModel GetMegabitModel(CalculatorViewModel model)
        {
            double bytes = 8;
            double quantity = model.Quantity;

            var result = model;

            if (model.KiloId == 0) // Bandwidth1000
            {
                result.GetBit = quantity * (Math.Pow(10, 6));
                result.GetByte = quantity * (Math.Pow(10, 6) / bytes);
                result.GetKilobit = quantity * Math.Pow(10, 3);
                result.GetKilobyte = quantity * (Math.Pow(10, 3) / bytes);
                result.GetMegabit = quantity;
                result.GetMegabyte = quantity / bytes;
                result.GetGigabit = quantity / (Math.Pow(10, 3));
                result.GetGigabyte = quantity / (Math.Pow(10, 3) * bytes);
                result.GetTerabit = quantity / (Math.Pow(10, 6));
                result.GetTerabyte = quantity / (Math.Pow(10, 6) * bytes);
                result.GetPetabit = quantity / (Math.Pow(10, 9));
                result.GetPetabyte = quantity / (Math.Pow(10, 9) * bytes);
                result.GetExabit = quantity / (Math.Pow(10, 12));
                result.GetExabyte = quantity / (Math.Pow(10, 12) * bytes);
                result.GetZettabit = quantity / (Math.Pow(10, 15));
                result.GetZettabyte = quantity / (Math.Pow(10, 15) * bytes);
                result.GetYottabit = quantity / (Math.Pow(10, 18));
                result.GetYottabyte = quantity / (Math.Pow(10, 18) * bytes);
            }
            else if (model.KiloId == 1) // Storage1024
            {
                result.GetBit = quantity * (Math.Pow(2, 20));
                result.GetByte = (quantity * Math.Pow(2, 20) / bytes);
                result.GetKilobit = quantity * Math.Pow(2, 10);
                result.GetKilobyte = (quantity * Math.Pow(2, 10)) / bytes;
                result.GetMegabit = quantity;
                result.GetMegabyte = quantity / bytes;
                result.GetGigabit = quantity / Math.Pow(2, 10);
                result.GetGigabyte = quantity / (Math.Pow(2, 10) * bytes);
                result.GetTerabit = quantity / (Math.Pow(2, 20));
                result.GetTerabyte = quantity / (Math.Pow(2, 20) * bytes);
                result.GetPetabit = quantity / (Math.Pow(2, 30));
                result.GetPetabyte = quantity / (Math.Pow(2, 30) * bytes);
                result.GetExabit = quantity / (Math.Pow(2, 40));
                result.GetExabyte = quantity / (Math.Pow(2, 40) * bytes);
                result.GetZettabit = quantity / (Math.Pow(2, 50));
                result.GetZettabyte = quantity / (Math.Pow(2, 50) * bytes);
                result.GetYottabit = quantity / (Math.Pow(2, 60));
                result.GetYottabyte = quantity / (Math.Pow(2, 60) * bytes);
            }
            else
            {
                throw new ArgumentException();
            }

            return result;
        }

        private CalculatorViewModel GetGigabitModel(CalculatorViewModel model)
        {
            double bytes = 8;
            double quantity = model.Quantity;

            var result = model;

            if (model.KiloId == 0) // Bandwidth1000
            {
                result.GetBit = quantity * bytes;
                result.GetByte = quantity;
                result.GetKilobit = quantity / (Math.Pow(10, 3));
                result.GetKilobyte = quantity / (Math.Pow(10, 3) * bytes);
                result.GetMegabit = quantity / (Math.Pow(10, 6));
                result.GetMegabyte = quantity / (Math.Pow(10, 6) * bytes);
                result.GetGigabit = quantity / (Math.Pow(10, 9));
                result.GetGigabyte = quantity / (Math.Pow(10, 9) * bytes);
                result.GetTerabit = quantity / (Math.Pow(10, 12));
                result.GetTerabyte = quantity / (Math.Pow(10, 12) * bytes);
                result.GetPetabit = quantity / (Math.Pow(10, 15));
                result.GetPetabyte = quantity / (Math.Pow(10, 15) * bytes);
                result.GetExabit = quantity / (Math.Pow(10, 18));
                result.GetExabyte = quantity / (Math.Pow(10, 18) * bytes);
                result.GetZettabit = quantity / (Math.Pow(10, 21));
                result.GetZettabyte = quantity / (Math.Pow(10, 21) * bytes);
                result.GetYottabit = quantity / (Math.Pow(10, 24));
                result.GetYottabyte = quantity / (Math.Pow(10, 24) * bytes);
            }
            else if (model.KiloId == 1) // Storage1024
            {
                result.GetBit = quantity * bytes;
                result.GetByte = quantity;
                result.GetKilobit = quantity / (Math.Pow(2, 10));
                result.GetKilobyte = quantity / (Math.Pow(2, 10) * bytes);
                result.GetMegabit = quantity / (Math.Pow(2, 20));
                result.GetMegabyte = quantity / (Math.Pow(2, 20) * bytes);
                result.GetGigabit = quantity / (Math.Pow(2, 30));
                result.GetGigabyte = quantity / (Math.Pow(2, 30) * bytes);
                result.GetTerabit = quantity / (Math.Pow(2, 40));
                result.GetTerabyte = quantity / (Math.Pow(2, 40) * bytes);
                result.GetPetabit = quantity / (Math.Pow(2, 50));
                result.GetPetabyte = quantity / (Math.Pow(2, 50) * bytes);
                result.GetExabit = quantity / (Math.Pow(2, 60));
                result.GetExabyte = quantity / (Math.Pow(2, 60) * bytes);
                result.GetZettabit = quantity / (Math.Pow(2, 70));
                result.GetZettabyte = quantity / (Math.Pow(2, 70) * bytes);
                result.GetYottabit = quantity / (Math.Pow(2, 80));
                result.GetYottabyte = quantity / (Math.Pow(2, 80) * bytes);
            }
            else
            {
                throw new ArgumentException();
            }

            return result;
        }

        private CalculatorViewModel GetTerabitModel(CalculatorViewModel model)
        {
            double bytes = 8;
            double quantity = model.Quantity;

            var result = model;

            if (model.KiloId == 0) // Bandwidth1000
            {
                result.GetBit = quantity * bytes;
                result.GetByte = quantity;
                result.GetKilobit = quantity / (Math.Pow(10, 3));
                result.GetKilobyte = quantity / (Math.Pow(10, 3) * bytes);
                result.GetMegabit = quantity / (Math.Pow(10, 6));
                result.GetMegabyte = quantity / (Math.Pow(10, 6) * bytes);
                result.GetGigabit = quantity / (Math.Pow(10, 9));
                result.GetGigabyte = quantity / (Math.Pow(10, 9) * bytes);
                result.GetTerabit = quantity / (Math.Pow(10, 12));
                result.GetTerabyte = quantity / (Math.Pow(10, 12) * bytes);
                result.GetPetabit = quantity / (Math.Pow(10, 15));
                result.GetPetabyte = quantity / (Math.Pow(10, 15) * bytes);
                result.GetExabit = quantity / (Math.Pow(10, 18));
                result.GetExabyte = quantity / (Math.Pow(10, 18) * bytes);
                result.GetZettabit = quantity / (Math.Pow(10, 21));
                result.GetZettabyte = quantity / (Math.Pow(10, 21) * bytes);
                result.GetYottabit = quantity / (Math.Pow(10, 24));
                result.GetYottabyte = quantity / (Math.Pow(10, 24) * bytes);
            }
            else if (model.KiloId == 1) // Storage1024
            {
                result.GetBit = quantity * bytes;
                result.GetByte = quantity;
                result.GetKilobit = quantity / (Math.Pow(2, 10));
                result.GetKilobyte = quantity / (Math.Pow(2, 10) * bytes);
                result.GetMegabit = quantity / (Math.Pow(2, 20));
                result.GetMegabyte = quantity / (Math.Pow(2, 20) * bytes);
                result.GetGigabit = quantity / (Math.Pow(2, 30));
                result.GetGigabyte = quantity / (Math.Pow(2, 30) * bytes);
                result.GetTerabit = quantity / (Math.Pow(2, 40));
                result.GetTerabyte = quantity / (Math.Pow(2, 40) * bytes);
                result.GetPetabit = quantity / (Math.Pow(2, 50));
                result.GetPetabyte = quantity / (Math.Pow(2, 50) * bytes);
                result.GetExabit = quantity / (Math.Pow(2, 60));
                result.GetExabyte = quantity / (Math.Pow(2, 60) * bytes);
                result.GetZettabit = quantity / (Math.Pow(2, 70));
                result.GetZettabyte = quantity / (Math.Pow(2, 70) * bytes);
                result.GetYottabit = quantity / (Math.Pow(2, 80));
                result.GetYottabyte = quantity / (Math.Pow(2, 80) * bytes);
            }
            else
            {
                throw new ArgumentException();
            }

            return result;
        }

        private CalculatorViewModel GetPetabitModel(CalculatorViewModel model)
        {
            double bytes = 8;
            double quantity = model.Quantity;

            var result = model;

            if (model.KiloId == 0) // Bandwidth1000
            {
                result.GetBit = quantity * bytes;
                result.GetByte = quantity;
                result.GetKilobit = quantity / (Math.Pow(10, 3));
                result.GetKilobyte = quantity / (Math.Pow(10, 3) * bytes);
                result.GetMegabit = quantity / (Math.Pow(10, 6));
                result.GetMegabyte = quantity / (Math.Pow(10, 6) * bytes);
                result.GetGigabit = quantity / (Math.Pow(10, 9));
                result.GetGigabyte = quantity / (Math.Pow(10, 9) * bytes);
                result.GetTerabit = quantity / (Math.Pow(10, 12));
                result.GetTerabyte = quantity / (Math.Pow(10, 12) * bytes);
                result.GetPetabit = quantity / (Math.Pow(10, 15));
                result.GetPetabyte = quantity / (Math.Pow(10, 15) * bytes);
                result.GetExabit = quantity / (Math.Pow(10, 18));
                result.GetExabyte = quantity / (Math.Pow(10, 18) * bytes);
                result.GetZettabit = quantity / (Math.Pow(10, 21));
                result.GetZettabyte = quantity / (Math.Pow(10, 21) * bytes);
                result.GetYottabit = quantity / (Math.Pow(10, 24));
                result.GetYottabyte = quantity / (Math.Pow(10, 24) * bytes);
            }
            else if (model.KiloId == 1) // Storage1024
            {
                result.GetBit = quantity * bytes;
                result.GetByte = quantity;
                result.GetKilobit = quantity / (Math.Pow(2, 10));
                result.GetKilobyte = quantity / (Math.Pow(2, 10) * bytes);
                result.GetMegabit = quantity / (Math.Pow(2, 20));
                result.GetMegabyte = quantity / (Math.Pow(2, 20) * bytes);
                result.GetGigabit = quantity / (Math.Pow(2, 30));
                result.GetGigabyte = quantity / (Math.Pow(2, 30) * bytes);
                result.GetTerabit = quantity / (Math.Pow(2, 40));
                result.GetTerabyte = quantity / (Math.Pow(2, 40) * bytes);
                result.GetPetabit = quantity / (Math.Pow(2, 50));
                result.GetPetabyte = quantity / (Math.Pow(2, 50) * bytes);
                result.GetExabit = quantity / (Math.Pow(2, 60));
                result.GetExabyte = quantity / (Math.Pow(2, 60) * bytes);
                result.GetZettabit = quantity / (Math.Pow(2, 70));
                result.GetZettabyte = quantity / (Math.Pow(2, 70) * bytes);
                result.GetYottabit = quantity / (Math.Pow(2, 80));
                result.GetYottabyte = quantity / (Math.Pow(2, 80) * bytes);
            }
            else
            {
                throw new ArgumentException();
            }

            return result;
        }

        private CalculatorViewModel GetExabitModel(CalculatorViewModel model)
        {
            double bytes = 8;
            double quantity = model.Quantity;

            var result = model;

            if (model.KiloId == 0) // Bandwidth1000
            {
                result.GetBit = quantity * bytes;
                result.GetByte = quantity;
                result.GetKilobit = quantity / (Math.Pow(10, 3));
                result.GetKilobyte = quantity / (Math.Pow(10, 3) * bytes);
                result.GetMegabit = quantity / (Math.Pow(10, 6));
                result.GetMegabyte = quantity / (Math.Pow(10, 6) * bytes);
                result.GetGigabit = quantity / (Math.Pow(10, 9));
                result.GetGigabyte = quantity / (Math.Pow(10, 9) * bytes);
                result.GetTerabit = quantity / (Math.Pow(10, 12));
                result.GetTerabyte = quantity / (Math.Pow(10, 12) * bytes);
                result.GetPetabit = quantity / (Math.Pow(10, 15));
                result.GetPetabyte = quantity / (Math.Pow(10, 15) * bytes);
                result.GetExabit = quantity / (Math.Pow(10, 18));
                result.GetExabyte = quantity / (Math.Pow(10, 18) * bytes);
                result.GetZettabit = quantity / (Math.Pow(10, 21));
                result.GetZettabyte = quantity / (Math.Pow(10, 21) * bytes);
                result.GetYottabit = quantity / (Math.Pow(10, 24));
                result.GetYottabyte = quantity / (Math.Pow(10, 24) * bytes);
            }
            else if (model.KiloId == 1) // Storage1024
            {
                result.GetBit = quantity * bytes;
                result.GetByte = quantity;
                result.GetKilobit = quantity / (Math.Pow(2, 10));
                result.GetKilobyte = quantity / (Math.Pow(2, 10) * bytes);
                result.GetMegabit = quantity / (Math.Pow(2, 20));
                result.GetMegabyte = quantity / (Math.Pow(2, 20) * bytes);
                result.GetGigabit = quantity / (Math.Pow(2, 30));
                result.GetGigabyte = quantity / (Math.Pow(2, 30) * bytes);
                result.GetTerabit = quantity / (Math.Pow(2, 40));
                result.GetTerabyte = quantity / (Math.Pow(2, 40) * bytes);
                result.GetPetabit = quantity / (Math.Pow(2, 50));
                result.GetPetabyte = quantity / (Math.Pow(2, 50) * bytes);
                result.GetExabit = quantity / (Math.Pow(2, 60));
                result.GetExabyte = quantity / (Math.Pow(2, 60) * bytes);
                result.GetZettabit = quantity / (Math.Pow(2, 70));
                result.GetZettabyte = quantity / (Math.Pow(2, 70) * bytes);
                result.GetYottabit = quantity / (Math.Pow(2, 80));
                result.GetYottabyte = quantity / (Math.Pow(2, 80) * bytes);
            }
            else
            {
                throw new ArgumentException();
            }

            return result;
        }

        private CalculatorViewModel GetZettabitModel(CalculatorViewModel model)
        {
            double bytes = 8;
            double quantity = model.Quantity;

            var result = model;

            if (model.KiloId == 0) // Bandwidth1000
            {
                result.GetBit = quantity * bytes;
                result.GetByte = quantity;
                result.GetKilobit = quantity / (Math.Pow(10, 3));
                result.GetKilobyte = quantity / (Math.Pow(10, 3) * bytes);
                result.GetMegabit = quantity / (Math.Pow(10, 6));
                result.GetMegabyte = quantity / (Math.Pow(10, 6) * bytes);
                result.GetGigabit = quantity / (Math.Pow(10, 9));
                result.GetGigabyte = quantity / (Math.Pow(10, 9) * bytes);
                result.GetTerabit = quantity / (Math.Pow(10, 12));
                result.GetTerabyte = quantity / (Math.Pow(10, 12) * bytes);
                result.GetPetabit = quantity / (Math.Pow(10, 15));
                result.GetPetabyte = quantity / (Math.Pow(10, 15) * bytes);
                result.GetExabit = quantity / (Math.Pow(10, 18));
                result.GetExabyte = quantity / (Math.Pow(10, 18) * bytes);
                result.GetZettabit = quantity / (Math.Pow(10, 21));
                result.GetZettabyte = quantity / (Math.Pow(10, 21) * bytes);
                result.GetYottabit = quantity / (Math.Pow(10, 24));
                result.GetYottabyte = quantity / (Math.Pow(10, 24) * bytes);
            }
            else if (model.KiloId == 1) // Storage1024
            {
                result.GetBit = quantity * bytes;
                result.GetByte = quantity;
                result.GetKilobit = quantity / (Math.Pow(2, 10));
                result.GetKilobyte = quantity / (Math.Pow(2, 10) * bytes);
                result.GetMegabit = quantity / (Math.Pow(2, 20));
                result.GetMegabyte = quantity / (Math.Pow(2, 20) * bytes);
                result.GetGigabit = quantity / (Math.Pow(2, 30));
                result.GetGigabyte = quantity / (Math.Pow(2, 30) * bytes);
                result.GetTerabit = quantity / (Math.Pow(2, 40));
                result.GetTerabyte = quantity / (Math.Pow(2, 40) * bytes);
                result.GetPetabit = quantity / (Math.Pow(2, 50));
                result.GetPetabyte = quantity / (Math.Pow(2, 50) * bytes);
                result.GetExabit = quantity / (Math.Pow(2, 60));
                result.GetExabyte = quantity / (Math.Pow(2, 60) * bytes);
                result.GetZettabit = quantity / (Math.Pow(2, 70));
                result.GetZettabyte = quantity / (Math.Pow(2, 70) * bytes);
                result.GetYottabit = quantity / (Math.Pow(2, 80));
                result.GetYottabyte = quantity / (Math.Pow(2, 80) * bytes);
            }
            else
            {
                throw new ArgumentException();
            }

            return result;
        }

        private CalculatorViewModel GetYottabitModel(CalculatorViewModel model)
        {
            double bytes = 8;
            double quantity = model.Quantity;

            var result = model;

            if (model.KiloId == 0) // Bandwidth1000
            {
                result.GetBit = quantity * bytes;
                result.GetByte = quantity;
                result.GetKilobit = quantity / (Math.Pow(10, 3));
                result.GetKilobyte = quantity / (Math.Pow(10, 3) * bytes);
                result.GetMegabit = quantity / (Math.Pow(10, 6));
                result.GetMegabyte = quantity / (Math.Pow(10, 6) * bytes);
                result.GetGigabit = quantity / (Math.Pow(10, 9));
                result.GetGigabyte = quantity / (Math.Pow(10, 9) * bytes);
                result.GetTerabit = quantity / (Math.Pow(10, 12));
                result.GetTerabyte = quantity / (Math.Pow(10, 12) * bytes);
                result.GetPetabit = quantity / (Math.Pow(10, 15));
                result.GetPetabyte = quantity / (Math.Pow(10, 15) * bytes);
                result.GetExabit = quantity / (Math.Pow(10, 18));
                result.GetExabyte = quantity / (Math.Pow(10, 18) * bytes);
                result.GetZettabit = quantity / (Math.Pow(10, 21));
                result.GetZettabyte = quantity / (Math.Pow(10, 21) * bytes);
                result.GetYottabit = quantity / (Math.Pow(10, 24));
                result.GetYottabyte = quantity / (Math.Pow(10, 24) * bytes);
            }
            else if (model.KiloId == 1) // Storage1024
            {
                result.GetBit = quantity * bytes;
                result.GetByte = quantity;
                result.GetKilobit = quantity / (Math.Pow(2, 10));
                result.GetKilobyte = quantity / (Math.Pow(2, 10) * bytes);
                result.GetMegabit = quantity / (Math.Pow(2, 20));
                result.GetMegabyte = quantity / (Math.Pow(2, 20) * bytes);
                result.GetGigabit = quantity / (Math.Pow(2, 30));
                result.GetGigabyte = quantity / (Math.Pow(2, 30) * bytes);
                result.GetTerabit = quantity / (Math.Pow(2, 40));
                result.GetTerabyte = quantity / (Math.Pow(2, 40) * bytes);
                result.GetPetabit = quantity / (Math.Pow(2, 50));
                result.GetPetabyte = quantity / (Math.Pow(2, 50) * bytes);
                result.GetExabit = quantity / (Math.Pow(2, 60));
                result.GetExabyte = quantity / (Math.Pow(2, 60) * bytes);
                result.GetZettabit = quantity / (Math.Pow(2, 70));
                result.GetZettabyte = quantity / (Math.Pow(2, 70) * bytes);
                result.GetYottabit = quantity / (Math.Pow(2, 80));
                result.GetYottabyte = quantity / (Math.Pow(2, 80) * bytes);
            }
            else
            {
                throw new ArgumentException();
            }

            return result;
        }
    }
}