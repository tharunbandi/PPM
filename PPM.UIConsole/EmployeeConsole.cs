using System;
using System.Text.RegularExpressions;
using PPM.Model;
using PPM.Domain;

namespace PPM.UIConsole
{
    public class EmployeeConsole
    {
        EmployeeDomain employeeDomain = new EmployeeDomain();

        public static int EmployeeModule()
        {
            Console.WriteLine("==================================");
            Console.WriteLine("╔════════ Employee Module ═════════╗");
            Console.WriteLine("║ 1. Add Employee                  ║");
            Console.WriteLine("║ 2. View Employee Details         ║");
            Console.WriteLine("║ 3. GetEmployeeDetailsByEmployeeId║");
            Console.WriteLine("║ 4. Delete Employee By EmployeeId ║");
            Console.WriteLine("║ 5. Return To Main Menu           ║");
            Console.WriteLine("║                                  ║");
            Console.WriteLine("╚══════════════════════════════════╝");

            Console.WriteLine("Choose Your Option Here!");
            int employeeChoice = int.Parse(Console.ReadLine());
            return employeeChoice;
        }

        public void AddEmployee()
        {
            while (true)
            {
                EmployeeId:
                Console.WriteLine("Enter EmployeeId:");
                int employeeId = int.Parse(Console.ReadLine());
                if (employeeDomain.GetById(employeeId) != null)
                {
                    Console.WriteLine("Please enter a unique EmployeeId");
                    goto EmployeeId;
                }

                FirstName:
                Console.WriteLine("Enter Employee FirstName:");
                string firstName = Console.ReadLine();
                if (firstName.Any(char.IsDigit))
                {
                    Console.WriteLine("Please enter a proper name");
                    goto FirstName;
                }

                LastName:
                Console.WriteLine("Enter Employee LastName:");
                string lastName = Console.ReadLine();
                if (lastName.Any(char.IsDigit))
                {
                    Console.WriteLine("Please enter a proper name");
                    goto LastName;
                }

                PhoneNumber:
                Console.WriteLine("Enter Employee PhoneNumber:");
                string phoneNumber = Console.ReadLine();

                if (!IsValidPhoneNumber(phoneNumber))
                {
                    Console.WriteLine("Please enter a valid PhoneNumber (e.g., +919640277613)");
                    goto PhoneNumber;
                }

                if (EmployeeDomain.employees.Exists(p => p.PhoneNumber == phoneNumber))
                {
                    Console.WriteLine(
                        "Phone number already exists. Please enter a unique phone number"
                    );
                    goto PhoneNumber;
                }

                Email:
                Console.WriteLine("Enter Employee Email:");
                string email = Console.ReadLine();

                if (!IsValidEmail(email))
                {
                    Console.WriteLine("Please enter a valid Email (e.g., banditharun77@gmail.com)");
                    goto Email;
                }

                if (EmployeeDomain.employees.Exists(e => e.Email == email))
                {
                    Console.WriteLine("Email already exists. Please enter a unique Email Id");
                    goto Email;
                }

                RoleId:
                Console.WriteLine("Enter Employee RoleId:");
                int roleId = int.Parse(Console.ReadLine());

                if (!RoleDomain.roles.Exists(r => r.RoleId == roleId))
                {
                    Console.WriteLine(
                        "Role with the specified RoleId does not exist. Please add the role first."
                    );
                    goto RoleId;
                }

                Employee employee = new Employee
                {
                    EmployeeId = employeeId,
                    EmployeeFirstName = firstName,
                    EmployeeLastName = lastName,
                    PhoneNumber = phoneNumber,
                    Email = email,
                    RoleId = roleId
                };

                employeeDomain.Add(employee);

                Console.WriteLine("***********Employee Details Are Added Successfully*******");

                Console.WriteLine("Do You Want to Add One More Employee (yes/No)");
                string addMore = Console.ReadLine().ToLower();
                if (addMore != "yes")
                {
                    return;
                }
            }
        }

        public void ViewEmployeeDetails()
        {
            System.Console.WriteLine();
            bool hasEmployee = employeeDomain.View();

            if (hasEmployee)
            {
                System.Console.WriteLine("********** Your Role Details Are *********************");
                foreach (var EmployeeList in EmployeeDomain.employees)
                {
                    System.Console.WriteLine(
                        $"EmployeeId:{EmployeeList.EmployeeId},EmployeeFirstName:{EmployeeList.EmployeeFirstName},EmployeeLastName:{EmployeeList.EmployeeLastName},PhoneNumber:{EmployeeList.PhoneNumber},Email:{EmployeeList.Email},EmployeeRoleId:{EmployeeList.RoleId}"
                    );
                }
            }
            else
            {
                System.Console.WriteLine("No Data Is Found");
            }
        }

        public bool IsValidPhoneNumber(string phoneNumber)
        {
            string phonePattern = @"^\+\d{10,}$";
            return Regex.IsMatch(phoneNumber, phonePattern);
        }

        public bool IsValidEmail(string email)
        {
            string emailPattern = @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}$";
            return Regex.IsMatch(email, emailPattern);
        }

        public Employee GetEmployeeById()
        {
            Console.WriteLine("Enter EmployeeId:");
            int employeeId = int.Parse(Console.ReadLine());
            var getEmployee = employeeDomain.GetById(employeeId);
            if (getEmployee != null)
            {
                Console.WriteLine("Employee Details");
                Console.WriteLine(
                    $"EmployeeId: {getEmployee.EmployeeId}, Employee FirstName: {getEmployee.EmployeeFirstName}, Employee LastName: {getEmployee.EmployeeLastName}, Employee PhoneNumber: {getEmployee.PhoneNumber}, Employee Email: {getEmployee.Email}, Employee RoleId: {getEmployee.RoleId}"
                );
            }
            else
            {
                Console.WriteLine($"No Employee with EmployeeId {employeeId} Is Found");
            }
            return getEmployee;
        }

        // public Employee DeleteEmployeeById()
        // {
        //     Console.WriteLine("Enter EmployeeId:");
        //     int employeeId = int.Parse(Console.ReadLine());

        //     var employeeGet = employeeDomain.GetEmployeeById(employeeId);
        //     if (employeeGet != null)
        //     {
        //         employeeDomain.DeleteEmployee(employeeGet);
        //         Console.WriteLine(
        //             $"Employee with EmployeeId {employeeGet.EmployeeId} has been Deleted Successfully"
        //         );
        //     }
        //     else
        //     {
        //         Console.WriteLine($"No Employee with EmployeeId {employeeId} Was Not Found");
        //     }
        //     return employeeGet;
        // }

        public void DeleteEmployee()
        {
            Console.WriteLine("Enter Employee ID:");
            int employeeId = int.Parse(Console.ReadLine());

            bool success = employeeDomain.DeleteEmployeeSafely(employeeId);

            if (success)
            {
                Console.WriteLine($"Employee with ID {employeeId} has been deleted successfully.");
            }
            else
            {
                Console.WriteLine(
                    $"Employee with ID {employeeId} not found or is mapped to a project."
                );
            }
        }
    }
}
