using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using ModelLayer;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace RepositoryLayer
{
    public class UserRL:IUserRL
    {
        private readonly IConfiguration configuration;//used to read setting and connection string from appsetting.json
        public UserRL(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        
        public IEnumerable<EmployeePModel> GetAllEmployeesDetails()
        {
            List<EmployeePModel> listemployee = new List<EmployeePModel>();

            using (SqlConnection con = new SqlConnection(this.configuration.GetConnectionString("EmployeePayrollconnection")))
            {
                SqlCommand cmd = new SqlCommand("SpGetallEmp", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    EmployeePModel employee = new EmployeePModel();

                    employee.Emplooyeeid = Convert.ToInt32(rdr["Emplooyeeid"]);
                    employee.Employeename = rdr["Employeename"].ToString();
                    employee.Employeeimage = rdr["Employeeimage"].ToString();
                    employee.Gender = rdr["Gender"].ToString();
                    employee.Department = rdr["Department"].ToString();
                    employee.Salary = Convert.ToInt64(rdr["Salary"]);//
                    employee.Startdate = Convert.ToDateTime(rdr["Startdate"]);
                    employee.Notes = rdr["Notes"].ToString();


                    listemployee.Add(employee);
                }
                con.Close();
            }
            return listemployee;
        }
        //To Add new employee record
        public void AddEmployees(EmployeePModel employee)
        {
            using (SqlConnection con = new SqlConnection(this.configuration.GetConnectionString("EmployeePayrollconnection")))
            {
                SqlCommand cmd = new SqlCommand("SpAddEmpDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Employeename", employee.Employeename);
                cmd.Parameters.AddWithValue("@Employeeimage", employee.Employeeimage);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@Department", employee.Department);
                cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                cmd.Parameters.AddWithValue("@Startdate", employee.Startdate);
                cmd.Parameters.AddWithValue("@Notes", employee.Notes);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }


        //to update the records
        public void UpdateEmployee(EmployeePModel employee)
        {
            using (SqlConnection con = new SqlConnection(this.configuration.GetConnectionString("EmployeePayrollconnection")))
            {
                SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Emplooyeeid", employee.Emplooyeeid);
                cmd.Parameters.AddWithValue("@Employeename", employee.Employeename);
                cmd.Parameters.AddWithValue("@Employeeimage", employee.Employeeimage);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@Department", employee.Department);
                cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                cmd.Parameters.AddWithValue("@Startdate", employee.Startdate);
                cmd.Parameters.AddWithValue("@Notes", employee.Notes);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        //get all emplooyee by id
        public EmployeePModel GetEmployeeData(int? id)
        {
            EmployeePModel employee = new EmployeePModel();

            using (SqlConnection con = new SqlConnection(this.configuration.GetConnectionString("EmployeePayrollconnection")))
            {
                string sqlQuery = "SELECT * FROM EmployeeMVCTable WHERE Emplooyeeid= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    employee.Emplooyeeid = Convert.ToInt32(rdr["Emplooyeeid"]);
                    employee.Employeename = rdr["Employeename"].ToString();
                    employee.Employeeimage = rdr["Employeeimage"].ToString();
                    employee.Gender = rdr["Gender"].ToString();
                    employee.Department = rdr["Department"].ToString();
                    employee.Salary = Convert.ToInt64(rdr["Salary"]);//
                    employee.Startdate = Convert.ToDateTime(rdr["Startdate"]);
                    employee.Notes = rdr["Notes"].ToString();
                }
            }
            return employee;
        }
        //To Delete the record on a particular employee    
        //public void DeleteEmployee(int? id)
        //{

        //    using (SqlConnection con = new SqlConnection(connectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand("spDeleteEmp", con);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        cmd.Parameters.AddWithValue("@Emplooyeeid", id);

        //        con.Open();
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //    }
        //}
    }
}
