namespace CommandPattern
{
    public interface IReceiver
    {
        void SetAction(ActionList action);

        int GetResult();
    }
}
