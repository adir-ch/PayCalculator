using PayCalculator.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculator.core.Model.Common
{
    public interface IBusinessService
    {
        IServiceResponse Execute(IServiceRequest request);
    }
}
