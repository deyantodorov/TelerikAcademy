namespace CommandPattern
{
    public class AddCommand : ACommand
    {
        public AddCommand(IReceiver receiver) 
            : base(receiver)
        {
        }

        public override int Execute()
        {
            this.receiver.SetAction(ActionList.Add);
            return this.receiver.GetResult();
        }
    }
}
