using EmployeeCrudApi.Models;
namespace EmployeeCrudApi.Services
{
    public interface IEmployeeService
    {
        List<Employee> GetAllEmployees();
        Employee? GetEmployeeById(int id);
        Employee? UpdateEmployee(int id, EmployeeUpdateRequest updateRequest);
        Employee CreateEmployee(Employee employee);
        bool DeleteEmployee(int id);
        List<int> GetValidEmployeeIds();
    }
    public class EmployeeService : IEmployeeService
    {
        // Hardcoded employee data as per requirements
        private static List<Employee> _employees = new List<Employee>
{
new Employee { Id = 1, Name = "John Doe", Email =
"john.doe@company.com", Department = "Engineering", Salary = 75000, HireDate
= "2022-01-15" },
new Employee { Id = 2, Name = "Jane Smith", Email =
"jane.smith@company.com", Department = "Marketing", Salary = 65000, HireDate
= "2021-03-20" },
new Employee { Id = 3, Name = "Mike Johnson", Email =
"mike.johnson@company.com", Department = "Sales", Salary = 60000, HireDate =
"2023-02-10" },
new Employee { Id = 4, Name = "Sarah Wilson", Email =
"sarah.wilson@company.com", Department = "HR", Salary = 55000, HireDate =
"2020-11-05" },
new Employee { Id = 5, Name = "David Brown", Email =
"david.brown@company.com", Department = "Finance", Salary = 70000, HireDate =
"2022-06-30" }
};
        public List<Employee> GetAllEmployees()
        {
            return _employees.ToList();
        }
        public Employee? GetEmployeeById(int id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }
        public Employee? UpdateEmployee(int id, EmployeeUpdateRequest
        updateRequest)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
                return null;
            // Update only provided fields
            if (!string.IsNullOrEmpty(updateRequest.Name))
                employee.Name = updateRequest.Name;
            if (!string.IsNullOrEmpty(updateRequest.Email))
                employee.Email = updateRequest.Email;
            if (!string.IsNullOrEmpty(updateRequest.Department))
                employee.Department = updateRequest.Department;
            if (updateRequest.Salary.HasValue)
                employee.Salary = updateRequest.Salary.Value;
            if (!string.IsNullOrEmpty(updateRequest.HireDate))
                employee.HireDate = updateRequest.HireDate;
            return employee;
        }
        public Employee CreateEmployee(Employee employee)
        {
            employee.Id = _employees.Max(e => e.Id) + 1;
            _employees.Add(employee);
            return employee;
        }
        public bool DeleteEmployee(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
                return false;
            _employees.Remove(employee);
            return true;
        }
        public List<int> GetValidEmployeeIds()
        {
            return _employees.Select(e => e.Id).ToList();
        }
    }
}