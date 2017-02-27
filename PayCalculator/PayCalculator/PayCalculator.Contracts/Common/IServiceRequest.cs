
namespace PayCalculator.Contracts.Common
{
    public interface IServiceRequest
    {
        string ServiceName { get; set; }
        string RequestId { get; set; }
    }
}
