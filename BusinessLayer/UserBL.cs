using ModelLayer;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace BusinessLayer
{
    public class UserBL : IUserBL
    {
        private readonly IUserRL userRL;
        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }
        public IEnumerable<EmployeePModel> GetAllEmployeesDetails()
        {
            try
            {
                return this.userRL.GetAllEmployeesDetails();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddEmployees(EmployeePModel employeee)
        {
            try
            {
                this.userRL.AddEmployees(employeee);
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public void UpdateEmployee(EmployeePModel employee)
        {
            try
            {
                this.userRL.UpdateEmployee(employee);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public EmployeePModel GetEmployeeData(int? id)
        {
            try
            {
                return this.userRL.GetEmployeeData(id);
            }
            catch (Exception e)
            {
                throw;
            }

        }
        public void DeleteEmployee(int? id)
        {
            try
            {
                 this.userRL.DeleteEmployee(id);
            }
            catch (Exception e)
            {
                throw;
            }

        }


    }
}

