namespace ObserverPattern
{
    public class SomeProduct : ASubject
    {
        public void ChangePrice(float price)
        {
            this.Notify(price);
        }
    }
}
