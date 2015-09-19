namespace CommandPattern
{
    public class SubstractCommand : ACommand
    {
        public SubstractCommand(IReceiver receiver) 
            : base(receiver)
        {
        }

        public override int Execute()
        {
            this.receiver.SetAction(ActionList.Substract);
            return this.receiver.GetResult();
        }
    }
}
