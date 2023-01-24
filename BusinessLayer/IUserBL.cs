using ModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public interface IUserBL
    {
        public IEnumerable<EmployeePModel> GetAllEmployeesDetails();
        public void AddEmployees(EmployeePModel employeee);

        public void UpdateEmployee(EmployeePModel employee);
        public EmployeePModel GetEmployeeData(int? id);
    }
}
