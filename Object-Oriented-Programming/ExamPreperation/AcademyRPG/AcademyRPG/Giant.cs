using System;
using System.Collections.Generic;
using System.Linq;

namespace AcademyRPG
{
    public class Giant : Character, IControllable, IFighter, IGatherer
    {
        private const int IncreaseAttackOnStoneGather = 100;

        private bool foundStone = false;
        private int attackPoints;
        private int defensePoints;

        public Giant(string name, Point position)
            : base(name, position, 0)
        {
            this.HitPoints = 200;
            this.AttackPoints = 150;
            this.defensePoints = 80;
        }

        public int AttackPoints
        {
            get { return this.attackPoints; }
            private set { this.attackPoints = value; }
        }

        public int DefensePoints
        {
            get { return this.defensePoints; }
            private set { this.defensePoints = value; }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != 0)
                {
                    return i;
                }
            }

            return -1;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Stone)
            {
                if (!foundStone)
                {
                    foundStone = true;
                    this.AttackPoints += IncreaseAttackOnStoneGather;
                }

                return true;
            }

            return false;
        }
    }
}