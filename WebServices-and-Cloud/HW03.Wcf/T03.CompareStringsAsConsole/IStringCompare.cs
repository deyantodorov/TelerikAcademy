using System.ServiceModel;

namespace T03.CompareStringsAsConsole
{
    [ServiceContract]
    public interface IStringCompare
    {
        [OperationContract]
        int NumberOfContains(string first, string second);
    }
}
