using System;
using PPM.Model;
using PPM.Domain;

namespace PPM.UIConsole
{
    public class CheckEmployeeAssignedToWhichRoleConsole
    {
        ViewEmployeeAssignedToWhichRoleDomain viewEmployeeAssignedToWhichRoleDomain =new ViewEmployeeAssignedToWhichRoleDomain();

        RoleDomain roleDomain = new RoleDomain();

        public static int CheckEmployeeAssignedToWhichRoleModule()
        {
            Console.WriteLine("========================");
            Console.WriteLine("1. Check Employee Assigned To Which Role");
            Console.WriteLine("2. Return to Main Menu");
            Console.WriteLine("=========================");

            Console.WriteLine("Please choose Your Choice");
            int checkChoice = int.Parse(Console.ReadLine());
            return checkChoice;
        }

        public void ViewEmployeeAssignedToWhichRole()
        {
            Console.WriteLine("Enter ProjectId");
            int projectId = int.Parse(Console.ReadLine());

            var project = viewEmployeeAssignedToWhichRoleDomain.GetProjectById(projectId);
            if (project != null)
            {
                Console.WriteLine("----------Your Project Details Are-------");
                Console.WriteLine($"ProjectId: {project.ProjectId}, ProjectName: {project.ProjectName}, Description: {project.Description}, ProjectStartDate: {project.StartDate}, ProjectEndDate: {project.EndDate}");

                Console.WriteLine("Employee Assigned By Role");
                //RoleConsole roleConsole = new RoleConsole(); // Create an instance of RoleConsole
                foreach (var item in project.EmployeeIds)
                {
                    var employee = EmployeeDomain.employees.FirstOrDefault(e => e.EmployeeId == item);
                    if (employee != null)
                    {
                        var role = roleDomain.GetById(employee.RoleId); // Call the method on the instance
                        if (role != null)
                        {
                            Console.WriteLine(
                                $"Employee with ID {employee.EmployeeId} and Name {employee.EmployeeFirstName} {employee.EmployeeLastName} is assigned to Project with ID {project.ProjectId} and Name '{project.ProjectName}' with the Role of '{role.RoleName}'.");
                        }
                        else
                        {
                            Console.WriteLine(
                                $"EmployeeId: {employee.EmployeeId}, EmployeeName: {employee.EmployeeFirstName} {employee.EmployeeLastName}, RoleName: Role Not Found"
                            );
                        }
                    }
                    else
                    {
                        Console.WriteLine($"EmployeeId: {item} Sorry, EmployeeId Not Found");
                    }
                }
            }
            else
            {
                Console.WriteLine("Warning: No Data Is Found! Please Choose a Valid ProjectId ");
            }
        }
    }
}
