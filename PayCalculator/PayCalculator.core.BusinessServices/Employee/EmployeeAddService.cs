using PayCalculator.Contracts.Employee;
using PayCalculator.core.BusinessServices.Common;
using PayCalculator.core.Model.Employee;
using System;

namespace PayCalculator.core.BusinessServices.Employee
{
    public class EmployeeAddService : BusinessServiceBase<EmployeeAddServiceRequest, EmployeeAddServiceResponse>
    {

        private readonly IEmployeeDao _employeeDao;

        public EmployeeAddService(IEmployeeDao employeeDao)
        {
            _employeeDao = employeeDao;
        }

        protected override void DoServiceExecute(EmployeeAddServiceRequest request)
        {
            _log.DebugFormat("Request to add new employee: {0}", request.EmployeeName);
            var employee = _employeeDao.GetOrCreateNew(request.EmployeeName);
            UpdateEmployeeData(employee, request);
            _employeeDao.Save(employee);
        }

        private void UpdateEmployeeData(IEmployee employee, EmployeeAddServiceRequest request)
        {
            employee.Init(request.EmployeeName, request.EmployeeLocation, request.GrossSalary);
        }

        protected override void ValidateRequest(EmployeeAddServiceRequest request)
        {
            if (String.IsNullOrEmpty(request.EmployeeName) == true)
            {
                throw new Exception("Employee name cannot be empty");
            }
        }

        protected override void FillResponse(EmployeeAddServiceRequest request, EmployeeAddServiceResponse response)
        {
            response.Status = true;
            response.Message = "Employee added successfully";
        }
    }
}
