namespace RestaurantManager.Models
{
    using System;
    using System.Text;
    using RestaurantManager.Interfaces;

    public class MainCourse : Meal, IMainCourse
    {
        public MainCourse(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isVegan, MainCourseType type)
            : base(name, price, calories, quantityPerServing, timeToPrepare, isVegan)
        {
            this.Type = type;
        }

        public MainCourseType Type { get; set; }

        public override string ToString()
        {
            var output = new StringBuilder();

            output.AppendFormat("{0}{1}{2}", this.IsVegan ? "[VEGAN] " : string.Empty, base.ToString(), Environment.NewLine);
            output.AppendFormat("Type: {0}{1}", this.Type, Environment.NewLine);

            return output.ToString();
        }
    }
}
