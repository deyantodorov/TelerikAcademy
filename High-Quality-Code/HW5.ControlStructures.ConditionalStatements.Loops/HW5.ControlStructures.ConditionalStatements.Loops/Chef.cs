namespace HW5.ControlStructures.ConditionalStatements.Loops
{
    using System;

    public class Chef
    {
        public void Cook()
        {
            Potato potato = this.GetPotato();
            
            // Task 2
            if (potato != null)
            {
                if (!(potato.IsPeel || potato.IsRotten))
                {
                    this.Cook(potato);
                }
            }

            this.Peel(potato);
            this.Cut(potato);

            Carrot carrot = this.GetCarrot();
            this.Peel(carrot);
            this.Cut(carrot);
            
            Bowl bowl;
            bowl = this.GetBowl();
            bowl.Add(potato);
            bowl.Add(carrot);
        }

        private void Cook(IVegetable potato)
        {
            throw new NotImplementedException();
        }

        private void Peel(IVegetable vegetable)
        {
            throw new NotImplementedException();
        }

        private Carrot GetCarrot()
        {
            throw new NotImplementedException();
        }

        private void Cut(Vegetable potato)
        {
            throw new NotImplementedException();
        }

        private Potato GetPotato()
        {
            throw new NotImplementedException();
        }

        private Bowl GetBowl()
        {
            throw new NotImplementedException();
        }
    }
}
