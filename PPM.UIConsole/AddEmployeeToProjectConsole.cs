using System;
using PPM.Domain;
using PPM.Model;

namespace PPM.UIConsole
{
    public class AddEmployeeToProjectConsole
    {
        AddEmployeeToProjectDomain addEmployeeToProjectDomain=new AddEmployeeToProjectDomain();
        public static int AddEmployeeToProjectModule()
        {
            System.Console.WriteLine("========================");
            System.Console.WriteLine("1.Add Employee To Project");
            System.Console.WriteLine("2.Return To Main Menu");
            System.Console.WriteLine("=========================");

            System.Console.WriteLine("Please! Choose Your Choice");
            int addProjectChoice=int.Parse(Console.ReadLine());
            return addProjectChoice;
        }
        public  void AddEmployeeToProject()
        {
            //List<Employee>employees=new List<Employee>();
            //Project projectobj = new Project();

            Console.ForegroundColor = ConsoleColor.Green;
        projectid:
            Console.WriteLine("Enter Project Id to add employee to project");
            int projectid = int.Parse(Console.ReadLine());

            if (addEmployeeToProjectDomain.CheckProjectId(projectid))
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Entered Project Id is not found");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Enter exist project Id again");
                goto projectid;
            }
            Console.ForegroundColor = ConsoleColor.Magenta;
        employeeid:
            Console.WriteLine("Enter Employee Id to add employee to project");
            int employeeid = int.Parse(Console.ReadLine());

            if (addEmployeeToProjectDomain.CheckEmployeeId(employeeid))
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Entered employee Id is not exist");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Enter exist employee Id again");
                goto employeeid;
            }


            bool result = addEmployeeToProjectDomain.AddEmpToProject(projectid, employeeid);

            if (result)
            {

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"EmployeeId:{employeeid} Added To Project:{projectid} Successfully");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"EmployeeId:{employeeid} is already part of Project:{projectid}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            

        }


    }
}
