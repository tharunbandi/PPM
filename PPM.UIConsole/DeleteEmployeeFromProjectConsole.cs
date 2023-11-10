using System;
using PPM.Domain;
using PPM.Model;

namespace PPM.UIConsole
{
    public class DeleteEmployeeToProjectConsole
    {
        DeleteEmployeeToProjectDomain deleteEmployeeToProjectDomain =
            new DeleteEmployeeToProjectDomain();

        public static int DeleteEmployeeToProjectModule()
        {
            System.Console.WriteLine("===========================");
            System.Console.WriteLine("1.Delete Employee From Project");
            System.Console.WriteLine("2.return to Main Menu         ");
            System.Console.WriteLine("===========================");

            System.Console.WriteLine("Please!Choose Your Choice");
            int deleteProjectChoice = int.Parse(Console.ReadLine());
            return deleteProjectChoice;
        }

        public void DeleteEmployeeFromProject()
        {
            //Project projectobj = new Project();

            Console.ForegroundColor = ConsoleColor.Green;
            projectid:
            Console.WriteLine("Enter Project Id to delete employee to project");
            int projectid = int.Parse(Console.ReadLine());

            if (deleteEmployeeToProjectDomain.CheckProjectId(projectid))
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Entered Project Id is not exist");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Enter exist project Id again");
                goto projectid;
            }
            Console.ForegroundColor = ConsoleColor.Magenta;
            employeeid:
            Console.WriteLine("Enter Employee Id to delete employee to project");
            int employeeid = int.Parse(Console.ReadLine());

            if (deleteEmployeeToProjectDomain.CheckEmployeeId(employeeid))
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Entered employee Id is not exist");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Enter exist employee Id again");
                goto employeeid;
            }

            bool result = deleteEmployeeToProjectDomain.DeleteEmployeeFromProjects(
                projectid,
                employeeid
            );
            if (result)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(
                    $"EmployeeId:{employeeid} removed from Project:{projectid} Successfully"
                );
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                System.Console.WriteLine("Deletion was not successful");
            }
        }
    }
}
