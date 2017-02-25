using PayCalculator.Contracts.Employee;
using PayCalculator.core.BusinessServices.Common;
using PayCalculator.core.Model.Employee;
using System;

namespace PayCalculator.core.BusinessServices.Employee
{
    public class EmployeeLookupService : BusinessServiceBase<EmployeeLookupServiceRequest, EmployeeLookupServiceResponse>
    {
        private readonly IEmployeeDao _employeeDao;
        private IEmployee _employee;

        public EmployeeLookupService(IEmployeeDao employeeDao)
        {
            _employeeDao = employeeDao;
        }

        protected override void DoServiceExecute(EmployeeLookupServiceRequest request)
        {
            _log.DebugFormat("Request to lookup employee: {0}", request.EmployeeName);
            _employee = _employeeDao.Get(request.EmployeeName);
            if (_employee == null)
            {
                throw new Exception(String.Format("Unable to locate employee: {0}", request.EmployeeName));
            }
        }

        protected override void ValidateRequest(EmployeeLookupServiceRequest request)
        {
            if (String.IsNullOrEmpty(request.EmployeeName) == true)
            {
                throw new Exception("Invalid employee name cannot be empty or null");
            }
        }

        protected override void FillResponse(EmployeeLookupServiceRequest request, EmployeeLookupServiceResponse response)
        {
            response.Status = true;
            response.Message = "Employee located successfully";

            response.EmployeeName = _employee.Name;
            response.Location = _employee.Location;

            if(_employee.EmployeeSalary != null)
            {
                response.GrossSalary = _employee.EmployeeSalary.GrossSalary;
                response.TaxableIncome = _employee.EmployeeSalary.TaxableIncome;
                response.NetAnnualSalary = _employee.EmployeeSalary.NetAnnualSalary;
                response.Deductions = _employee.EmployeeSalary.Deductions;
            }
        }
    }
}
