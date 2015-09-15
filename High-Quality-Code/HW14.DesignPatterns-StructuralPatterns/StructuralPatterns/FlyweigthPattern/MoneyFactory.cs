using System;
using System.Collections.Generic;

namespace FlyweigthPattern
{
    public class MoneyFactory
    {
        private Dictionary<MoneyType, IMoney> moneyObjects;

        public int ObjectCount { get; set; }

        public IMoney GetMoneyToDisplay(MoneyType form)
        {
            if (this.moneyObjects == null)
            {
                this.moneyObjects = new Dictionary<MoneyType, IMoney>();
            }

            if (this.moneyObjects.ContainsKey(form))
            {
                return this.moneyObjects[form];
            }

            switch (form)
            {
                case MoneyType.Metalic:
                    this.moneyObjects.Add(form, new MetalicMoney());
                    this.ObjectCount++;
                    break;
                case MoneyType.Paper:
                    this.moneyObjects.Add(form, new PaperMoney());
                    this.ObjectCount++;
                    break;
                default:
                    throw new ArgumentException("Unsupported money type");
            }

            return this.moneyObjects[form];
        }
    }
}
