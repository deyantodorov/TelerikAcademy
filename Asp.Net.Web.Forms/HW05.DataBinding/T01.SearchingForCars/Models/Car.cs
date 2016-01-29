using System;

namespace T01.SearchingForCars.Models
{
    [Serializable]
    public class Car
    {
        public int Id { get; set; }

        public string Model  { get; set; }

        public Producer Producer { get; set; }
    }
}