namespace CommandPattern
{
    public abstract class ACommand
    {
        protected IReceiver receiver;

        protected ACommand(IReceiver receiver)
        {
            this.receiver = receiver;
        }

        public abstract int Execute();
    }
}
