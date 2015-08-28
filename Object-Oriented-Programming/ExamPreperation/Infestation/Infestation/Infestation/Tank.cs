﻿namespace Infestation
{
    public class Tank : Unit
    {
        private const int TankPower = 25;
        private const int TankHealth = 20;
        private const int TankAggression = 25;
        
        public Tank(string id)
            : base(id, UnitClassification.Mechanical, Tank.TankHealth, Tank.TankPower, Tank.TankAggression)
        {
        }
    }
}
