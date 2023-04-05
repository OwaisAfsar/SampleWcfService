using System.ServiceModel;

namespace SampleWcfService
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string ConvertAmountData(string amount);
    }
}
