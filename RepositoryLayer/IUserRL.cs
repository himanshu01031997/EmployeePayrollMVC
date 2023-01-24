using ModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer
{
    public interface IUserRL
    {
        public IEnumerable<EmployeePModel> GetAllEmployeesDetails();
        public void AddEmployees(EmployeePModel employee);
        public void UpdateEmployee(EmployeePModel employee);
        public EmployeePModel GetEmployeeData(int? id);
        //public void DeleteEmployee(int? id);
    }
}
