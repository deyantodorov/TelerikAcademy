using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using T01.SearchingForCars.Models;

namespace T01.SearchingForCars
{
    public partial class Default : System.Web.UI.Page
    {
        private const int Count = 10;

        private List<Producer> carProducers;
        private List<Car> carModels;
        private List<Extra> extras;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                GenerateProducers();
                GenerateModels();
                GenerateExtras();

                this.ViewState["CarModels"] = this.carModels;

                this.DropDownListProducer.DataSource = carProducers;
                this.RadioButtonListEngineType.DataSource = GetEngineTypes();
                this.CheckBoxExtra.DataSource = this.extras;
                this.DataBind();
                this.DropDownListProducer.Items.Insert(0, new ListItem("Select Producer", "-1"));

                this.SubmitInformation.Visible = false;
            }
        }

        protected void DropDownListProducer_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var dropDownList = sender as DropDownList;
            if (dropDownList == null)
            {
                return;
            }

            this.carModels = this.ViewState["CarModels"] as List<Car>;
            if (this.carModels == null)
            {
                return;
            }

            var selectedId = int.Parse(dropDownList.SelectedIndex.ToString());
            var selectedCars = this.carModels.Where(car => car.Producer.Id == selectedId).ToList();
            this.DropDownListCarModel.DataSource = selectedCars;
            this.DropDownListCarModel.DataBind();
            this.DropDownListCarModel.Items.Insert(0, new ListItem("Select Car Model", "-1"));
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (!this.Page.IsValid)
            {
                return;
            }

            var builder = new StringBuilder();

            builder.Append("<strong>Producer: </strong>" + this.DropDownListProducer.SelectedItem.Text + "<br />");
            builder.Append("<strong>Car Model: </strong>" + this.DropDownListCarModel.SelectedItem.Text + "<br />");

            var selectedExtras = this.CheckBoxExtra.Items.Cast<ListItem>()
                .Where(li => li.Selected)
                .ToList();

            if (selectedExtras.Any())
            {
                builder.AppendLine("<strong>Extras: </strong>");
            }

            foreach (var listItem in selectedExtras)
            {
                builder.AppendLine(listItem + " ");
            }

            if (selectedExtras.Any())
            {
                builder.AppendLine("<br />");
            }

            builder.Append("<strong>Engine type: </strong>" + this.RadioButtonListEngineType.SelectedItem.Text + "<br />");

            this.SubmitInformation.Visible = true;
            this.SubmitInformation.Text = builder.ToString();
        }

        private void GenerateModels()
        {
            this.carModels = new List<Car>();

            for (int i = 0; i < Count * 2; i++)
            {
                var carModel = new Car()
                {
                    Id = i + 1,
                    Model = "Car Model " + (i + 1),
                    Producer = i >= this.carProducers.Count ? carProducers[i - Count] : carProducers[i]
                };

                this.carModels.Add(carModel);
            }
        }

        private void GenerateProducers()
        {
            this.carProducers = new List<Producer>();

            for (int i = 0; i < Count; i++)
            {
                var carProducer = new Producer()
                {
                    Id = i + 1,
                    Name = "Producer " + (i + 1)
                };

                this.carProducers.Add(carProducer);
            }
        }

        private string[] GetEngineTypes()
        {
            var engines = new string[4];
            engines[0] = "Hybrid";
            engines[1] = "Gas";
            engines[2] = "Diesel";
            engines[3] = "Petrol";

            return engines;
        }

        private void GenerateExtras()
        {
            this.extras = new List<Extra>();

            for (int i = 0; i < Count; i++)
            {
                var extra = new Extra()
                {
                    Id = i + 1,
                    Name = "Extra " + (i + 1)
                };

                this.extras.Add(extra);
            }
        }
    }
}