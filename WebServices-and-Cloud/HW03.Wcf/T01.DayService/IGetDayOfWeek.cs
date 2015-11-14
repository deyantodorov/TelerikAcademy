using System;
using System.ServiceModel;

namespace DayService
{
    [ServiceContract]
    public interface IGetDayOfWeek
    {
        [OperationContract]
        string DayOfWeekInBulgarian(DateTime date);
    }
}
