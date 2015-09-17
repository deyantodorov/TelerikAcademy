namespace ChainOfResponsibility
{
    public abstract class Approver
    {
        protected Approver Successor;

        public void SetSuccessor(Approver approver)
        {
            this.Successor = approver;
        }

        public abstract void ProcessRequest(Purchase purchase);
    }
}
