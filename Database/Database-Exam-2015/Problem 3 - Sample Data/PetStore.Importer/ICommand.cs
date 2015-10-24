namespace PetStore.Importer
{
    public interface ICommand
    {
        void Execute();

        string Message();
    }
}
