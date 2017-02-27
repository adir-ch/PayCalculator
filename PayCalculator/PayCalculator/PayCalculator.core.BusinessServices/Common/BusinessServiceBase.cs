using log4net;
using PayCalculator.Contracts.Common;
using PayCalculator.core.Model.Common;
using System;

namespace PayCalculator.core.BusinessServices.Common
{
    public abstract class BusinessServiceBase<TRequest, TResponse> : IBusinessService
        where TRequest : ServiceRequestBase, new()
        where TResponse : ServiceResponseBase, new()
    {
        protected readonly ILog _log = LogManager.GetLogger("ServerLogger");

        protected abstract void DoServiceExecute(TRequest request);
        protected abstract void FillResponse(TRequest request, TResponse response);
        protected abstract void ValidateRequest(TRequest request);

        public IServiceResponse Execute(IServiceRequest request)
        {
            IServiceResponse response;
            var requestObject = request as TRequest;

            try
            {
                ValidateRequest(requestObject);
                DoServiceExecute(requestObject);
                response = GenerateResponse(requestObject);
            }
            catch (Exception e)
            {
                _log.ErrorFormat("Service exception on request (id: {0}) for service: {1}", request.RequestId, request.ServiceName);
                _log.DebugFormat("Exception data: {0}{1}", Environment.NewLine, e.Message);

                // TODO: I could call a factory to generate an error response 
                response = BuildErrorResponse(request);
            }

            return response;
        }

        private ServiceErrorResponse BuildErrorResponse(IServiceRequest request)
        {
            var response = new ServiceErrorResponse()
            {
                ServiceName = request.ServiceName,
                RequestId = request.RequestId,
                Status = false,
                ErrorCode = 99,
                Message = String.Format("Error while handling request for service: {0}", request.ServiceName)
            };
            return response;
        }

        private TResponse GenerateResponse(TRequest request)
        {
            var response = new TResponse();
            response.RequestId = request.RequestId;
            response.ServiceName = request.ServiceName;
            FillResponse(request, response);
            return response;
        }
    }
}
