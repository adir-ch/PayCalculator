using PayCalculator.Contracts.Employee;
using PayCalculator.core.BusinessServices.Common;
using PayCalculator.core.Model.Employee;
using PayCalculator.core.Model.Salary;
using System;

namespace PayCalculator.core.BusinessServices.Employee
{
    public class EmployeeCalculateSalaryService : BusinessServiceBase<EmployeeCalculateSalaryServiceRequest, EmployeeCalculateSalaryServiceResponse>
    {

        private readonly IEmployeeDao _employeeDao;
        private ISalary _calculatedSalary;

        public EmployeeCalculateSalaryService(IEmployeeDao employeeDao)
        {
            _employeeDao = employeeDao;
        }

        protected override void DoServiceExecute(EmployeeCalculateSalaryServiceRequest request)
        {
            _log.DebugFormat("Request to calculate net salary for employee: {0}", request.EmployeeName);
            var employee = _employeeDao.Get(request.EmployeeName);
            _calculatedSalary = employee.CalculateNetSalary();
            _log.DebugFormat("Employee {0}, Gross salary={1}, Net salary={2}", employee.Name, _calculatedSalary.GrossSalary, _calculatedSalary.NetAnnualSalary);
            _employeeDao.Save(employee);
        }

        protected override void ValidateRequest(EmployeeCalculateSalaryServiceRequest request)
        {
            if (String.IsNullOrEmpty(request.EmployeeName) == true)
            {
                throw new Exception("Employee name cannot be empty");
            }
        }

        protected override void FillResponse(EmployeeCalculateSalaryServiceRequest request, EmployeeCalculateSalaryServiceResponse response)
        {
            response.Status = true;
            response.Message = "Net salary calculated";
            response.NetAnnualSalary = _calculatedSalary.NetAnnualSalary;
        }
    }
}
