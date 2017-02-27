using System;

namespace PayCalculator.Contracts.Common
{
    public class ServiceErrorResponse : ServiceResponseBase
    {
        public int ErrorCode { get; set; }
        public string DetailedException { get; set; }
        
        public ServiceErrorResponse()
        {
        }

        public override string DumpResponseBody()
        {
            return String.Format(" ErrorCode {0}, Exception {1}", ErrorCode, DetailedException);
        }
    }
}
