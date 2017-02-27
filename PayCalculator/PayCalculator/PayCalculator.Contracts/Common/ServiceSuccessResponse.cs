using PayCalculator.Contracts.Common;

namespace Contracts.Common
{
    public class ServiceSuccessResponse : ServiceResponseBase
    {
        public override string DumpResponseBody()
        {
            return "Service finished successfully";
        }
    }
}
