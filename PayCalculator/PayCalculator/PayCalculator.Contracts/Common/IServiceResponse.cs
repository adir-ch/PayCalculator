
namespace PayCalculator.Contracts.Common
{
    public interface IServiceResponse
    {
        string RequestId { get; set; }
        bool Status { get; set; }
        string Message { get; set; }
        string ServiceName { get; set; }

        string DumpResponseHeader();
        string DumpResponseBody(); 
    }
}
