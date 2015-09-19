namespace CommandPattern
{
    public class MultiplyCommand : ACommand
    {
        public MultiplyCommand(IReceiver receiver)
            : base(receiver)
        {
        }

        public override int Execute()
        {
            this.receiver.SetAction(ActionList.Multiply);
            return this.receiver.GetResult();
        }
    }
}
