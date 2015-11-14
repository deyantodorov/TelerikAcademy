using System.ServiceModel;

namespace T03.CompareStrings
{
    [ServiceContract]
    public interface IStringCompare
    {
        [OperationContract]
        int NumberOfContains(string first, string second);
    }
}
