using System.Collections.Generic;
//System.Data.SqlClient;
using System.Runtime.InteropServices;
using PPM.Model;

namespace PPM.Domain
{
    public class EmployeeDomain : Ioperation<Employee>
    {
        //string ConnectionString ="Server=RHJ-9F-D200\\SQLEXPRESS;DataBase=ProlificsProjectManager;Integrated Security=SSPI";
        public static List<Employee> employees = new List<Employee>();

        public void Add(Employee employee )
        {
           

            employees.Add(employee);
            // using(SqlConnection connection=new SqlConnection(ConnectionString))
            // {
            //     connection.Open();

            //     string sqlQuery="Insert into Employee(EmployeeId,EmployeeFirstName,EmployeeLastName,PhoneNumber,Email,RoleId) values(@EmployeeId,@EmployeeFirstName,@EmployeeLastName,@PhoneNumber,@Email,@RoleId)";
            //     using(SqlCommand command=new SqlCommand(sqlQuery,connection))
            //     {
            //         command.Parameters.AddWithValue("@EmployeeId",employee.EmployeeId);
            //         command.Parameters.AddWithValue("@EmployeeFirstName",employee.EmployeeFirstName);
            //         command.Parameters.AddWithValue("@EmployeeLastName",employee.EmployeeLastName);
            //         command.Parameters.AddWithValue("@PhoneNumber",employee.PhoneNumber);
            //         command.Parameters.AddWithValue("@Email",employee.Email);
            //         command.Parameters.AddWithValue("@RoleId",employee.RoleId);
            //         command.ExecuteNonQuery();
            //     }
            // }

        }

        public Employee GetById(int employeeId)
        {
            var GetEmployee = EmployeeDomain.employees.FirstOrDefault(
                e => e.EmployeeId == employeeId
            );
            return GetEmployee;
        }

        public void Delete(Employee employee)
        {
            if (employees.Contains(employee))
            {
                employees.Remove(employee);
            }
        }

        public bool IsEmployeeMappedToProject(int employeeId)
        {
            // Check if the employee is mapped to any project
            return ProjectDomain.projects.Any(project => project.EmployeeIds.Contains(employeeId));
        }

        public bool DeleteEmployeeSafely(int employeeId)
        {
            if (IsEmployeeMappedToProject(employeeId))
            {
                return false; // Employee is mapped to a project, deletion is not allowed.
            }
            else
            {
                var employeeToDelete = GetById(employeeId);
                if (employeeToDelete != null)
                {
                    Delete(employeeToDelete);
                    return true; // Employee deleted successfully.
                }
                else
                {
                    return false; // Employee not found.
                }
            }
        }

        public bool View()
        {
            return employees.Count > 0;
        }
    }
}
