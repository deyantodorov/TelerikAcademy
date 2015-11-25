namespace T01.KnapsackProblem
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Knapsack : IEnumerable<Item>
    {
        private readonly List<Item> items;
        private readonly int knapsackCapacity;

        public Knapsack(int knapsackCapacity)
        {
            this.knapsackCapacity = knapsackCapacity;
            this.items = new List<Item>();
        }

        public int TotalWeight
        {
            get
            {
                var sum = 0;
                foreach (Item i in this)
                {
                    sum += i.Weight;
                }

                return sum;
            }
        }

        public IEnumerator<Item> GetEnumerator()
        {
            foreach (Item i in this.items)
            {
                yield return i;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Calculate(List<Item> items)
        {
            foreach (Item i in this.Sorting(items))
            {
                this.AddItem(i);
            }
        }

        private void AddItem(Item i)
        {
            if ((this.TotalWeight + i.Weight) <= this.knapsackCapacity)
            {
                this.items.Add(i);
            }
        }

        private List<Item> Sorting(List<Item> inputItems)
        {
            List<Item> choosenItems = new List<Item>();

            for (int i = 0; i < inputItems.Count; i++)
            {
                int j = -1;
                if (i == 0)
                {
                    choosenItems.Add(inputItems[i]);
                }

                if (i > 0)
                {
                    if (!this.RecursiveF(inputItems, choosenItems, i, choosenItems.Count - 1, false, ref j))
                    {
                        choosenItems.Add(inputItems[i]);
                    }
                }
            }

            return choosenItems;
        }

        private bool RecursiveF(List<Item> knapsackItems, List<Item> choosenItems, int i, int lastBound, bool dec, ref int indxToAdd)
        {
            if (!(lastBound < 0))
            {
                if (knapsackItems[i].ResultWeightValue < choosenItems[lastBound].ResultWeightValue)
                {
                    indxToAdd = lastBound;
                }

                return this.RecursiveF(knapsackItems, choosenItems, i, lastBound - 1, true, ref indxToAdd);
            }

            if (indxToAdd > -1)
            {
                choosenItems.Insert(indxToAdd, knapsackItems[i]);
                return true;
            }

            return false;
        }
    }
}
