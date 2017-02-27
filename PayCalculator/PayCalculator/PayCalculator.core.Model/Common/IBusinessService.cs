using PayCalculator.Contracts.Common;

namespace PayCalculator.core.Model.Common
{
    public interface IBusinessService
    {
        IServiceResponse Execute(IServiceRequest request);
    }
}
