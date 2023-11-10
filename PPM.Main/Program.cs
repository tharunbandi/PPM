using System;
using PPM.UIConsole;

namespace PPM.Main
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MainConsole.Title();
            int choice;
            bool returnToMainMenu;

            ProjectConsole projectConsole = new ProjectConsole();
            RoleConsole roleConsole = new RoleConsole();
            EmployeeConsole employeeConsole = new EmployeeConsole();
            AddEmployeeToProjectConsole addEmployeeToProjectConsole =
                new AddEmployeeToProjectConsole();
            DeleteEmployeeToProjectConsole deleteEmployeeToProjectConsole =
                new DeleteEmployeeToProjectConsole();
            CheckEmployeeAssignedToWhichRoleConsole checkEmployeeAssignedToWhichRoleConsole =
                new CheckEmployeeAssignedToWhichRoleConsole(); //creating object for ProjectConsole class

            do
            {
                choice = MainConsole.Menu();
                returnToMainMenu = false;

                switch (choice)
                {
                    case 1:
                        do
                        {
                            int subChoice = RoleConsole.RoleModule();
                            switch (subChoice)
                            {
                                case 1:
                                    roleConsole.AddRole();
                                    break;
                                case 2:
                                    roleConsole.ViewRoleDetails();
                                    break;
                                case 3:
                                    roleConsole.GetRoleById();
                                    break;
                                case 4:
                                    roleConsole.DeleteRole();
                                    break;
                                case 5:
                                    returnToMainMenu = true;
                                    break;
                                default:
                                    MainConsole.Invalid();
                                    break;
                            }
                        } while (!returnToMainMenu);
                        break;

                    case 2:
                        do
                        {
                            int projectChoice = ProjectConsole.ProjectModule();
                            switch (projectChoice)
                            {
                                case 1:
                                    projectConsole.AddProject();
                                    break;
                                case 2:
                                    projectConsole.ViewProjectDetails();
                                    break;
                                case 3:
                                    projectConsole.GetByProjectId();
                                    break;
                                case 4:
                                    projectConsole.DeleteProjectById();
                                    break;

                                case 5:
                                    returnToMainMenu = true;
                                    break;

                                default:
                                    MainConsole.Invalid();
                                    break;
                            }
                        } while (!returnToMainMenu);
                        break;

                    case 3:
                        do
                        {
                            int employeeChoice = EmployeeConsole.EmployeeModule();
                            switch (employeeChoice)
                            {
                                case 1:
                                    employeeConsole.AddEmployee();
                                    break;
                                case 2:
                                    employeeConsole.ViewEmployeeDetails();
                                    break;
                                case 3:
                                    employeeConsole.GetEmployeeById();
                                    break;

                                case 4:
                                    employeeConsole.DeleteEmployee();

                                    break;

                                case 5:
                                    returnToMainMenu = true;
                                    break;

                                default:
                                    MainConsole.Invalid();
                                    break;
                            }
                        } while (!returnToMainMenu);
                        break;

                    case 4:
                        do
                        {
                            int addProjectChoice =
                                AddEmployeeToProjectConsole.AddEmployeeToProjectModule();
                            switch (addProjectChoice)
                            {
                                case 1:
                                    addEmployeeToProjectConsole.AddEmployeeToProject();
                                    break;
                                case 2:
                                    returnToMainMenu = true;
                                    break;

                                default:
                                    MainConsole.Invalid();
                                    break;
                            }
                        } while (!returnToMainMenu);
                        break;

                    case 5:
                        do
                        {
                            int deleteProjectChoice =
                                DeleteEmployeeToProjectConsole.DeleteEmployeeToProjectModule();
                            switch (deleteProjectChoice)
                            {
                                case 1:
                                    deleteEmployeeToProjectConsole.DeleteEmployeeFromProject();
                                    break;

                                case 2:
                                    returnToMainMenu = true;
                                    break;

                                default:
                                    MainConsole.Invalid();
                                    break;
                            }
                        } while (!returnToMainMenu);
                        break;

                    case 6:
                        do
                        {
                            int checkChoice =
                                CheckEmployeeAssignedToWhichRoleConsole.CheckEmployeeAssignedToWhichRoleModule();
                            switch (checkChoice)
                            {
                                case 1:
                                    checkEmployeeAssignedToWhichRoleConsole.ViewEmployeeAssignedToWhichRole();
                                    break;

                                case 2:
                                    returnToMainMenu = true;
                                    break;

                                default:
                                    MainConsole.Invalid();
                                    break;
                            }
                        } while (!returnToMainMenu);
                        break;

                    case 7:
                    MainConsole.SaveAppState();
                    break;
                    case 8:
                        MainConsole.MenuExit();
                        break;
                    default:
                        MainConsole.Invalid();
                        break;
                }
            } while (choice != 8);
        }
    }
}
