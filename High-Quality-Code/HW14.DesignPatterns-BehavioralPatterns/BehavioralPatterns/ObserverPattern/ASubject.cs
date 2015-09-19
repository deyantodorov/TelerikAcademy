using System.Collections;
using System.Collections.Generic;

namespace ObserverPattern
{
    public abstract class ASubject
    {
        private readonly List<Shop> list;

        protected ASubject()
        {
            this.list = new List<Shop>();
        }

        public void Attach(Shop product)
        {
            this.list.Add(product);
        }

        public void Detach(Shop product)
        {
            this.list.Remove(product);
        }

        protected void Notify(float price)
        {
            this.list.ForEach(x => x.Update(price));
        }
    }
}
