namespace AbstractFactory.Interfaces
{
    public interface IPhoneFactory
    {
        ISimplePhone GetSimplePhone();
        ISmartPhone GetSmartPhone();
    }
}