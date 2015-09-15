using System.Collections.Generic;

namespace AdapterPattern
{
    public interface ITarget
    {
        List<string> GetProducts();
    }
}
