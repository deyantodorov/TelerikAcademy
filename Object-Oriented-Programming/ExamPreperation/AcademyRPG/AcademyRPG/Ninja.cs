using System;
using System.Collections.Generic;
using System.Linq;

namespace AcademyRPG
{
    public class Ninja : Character, IControllable, IFighter, IGatherer
    {
        private int attackPoints;

        public Ninja(string name, Point position, int owner)
            : base(name, position, owner)
        {
            this.HitPoints = 1;
            this.AttackPoints = 0;
        }

        public int AttackPoints
        {
            get { return this.attackPoints; }
            private set { this.attackPoints = value; }
        }

        public int DefensePoints
        {
            get { return int.MinValue; }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            int maxHitPoints = int.MinValue;
            int targetId = -1;

            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != this.Owner && availableTargets[i].Owner != 0)
                {
                    if (availableTargets[i].HitPoints > maxHitPoints)
                    {
                        maxHitPoints = availableTargets[i].HitPoints;
                        targetId = i;
                    }
                }
            }

            return targetId;
        }

        public bool TryGather(IResource resource)
        {

            if (resource.Type == ResourceType.Lumber)
            {
                this.AttackPoints += resource.Quantity;
                return true;
            }

            if (resource.Type == ResourceType.Stone)
            {
                this.AttackPoints += resource.Quantity * 2;
                return true;
            }

            return false;
        }
    }
}
