using System;
using PPM.Model;
using PPM.Domain;

namespace PPM.UIConsole
{
    public class ProjectConsole
    {
        private ProjectDomain projectDomain = new ProjectDomain();
        private AddEmployeeToProjectDomain addEmployeeToProjectDomain =
            new AddEmployeeToProjectDomain();

        public static int ProjectModule()
        {
            Console.WriteLine();
            Console.WriteLine("==================================");
            Console.WriteLine("╔════════ Project Module ═════════╗");
            Console.WriteLine("║ 1. Add Project                  ║");
            Console.WriteLine("║ 2. View Project Details         ║");
            Console.WriteLine("║ 3. Get Details By ProjectId     ║");
            Console.WriteLine("║ 4. Delete Project By ProjectId  ║");
            Console.WriteLine("║ 5. Return To Main Menu          ║");
            Console.WriteLine("╚═════════════════════════════════╝");

            Console.WriteLine("Choose Your Option Here!");
            int projectChoice = int.Parse(Console.ReadLine());
            return projectChoice;
        }

        public void AddProject()
        {
            while (true)
            {
                Console.WriteLine("Enter Your ProjectId:");
                int projectId = int.Parse(Console.ReadLine());

                if (ProjectDomain.projects.Exists(p => p.ProjectId == projectId))
                {
                    Console.WriteLine(
                        "ProjectId already exists! Please add a different ProjectId."
                    );
                    continue;
                }

                Console.WriteLine("Enter Your ProjectName:");
                string projectName = Console.ReadLine();

                if (projectName.Any(char.IsDigit))
                {
                    Console.WriteLine("Please enter a proper name without any numbers.");
                    continue;
                }

                Console.WriteLine("Enter Your ProjectDescription:");
                string description = Console.ReadLine();

                Console.WriteLine("Enter Your StartDate (YY-MM-DD):");
                DateTime startDate = DateTime.Parse(Console.ReadLine());

                StartAndEndDate:
                Console.WriteLine("Enter Your EndDate (YY-MM-DD):");
                DateTime endDate = DateTime.Parse(Console.ReadLine());

                if (endDate <= startDate)
                {
                    Console.WriteLine("EndDate should not be less than or equal to StartDate.");
                    goto StartAndEndDate;
                }

                Project project = new Project
                {
                    ProjectId = projectId,
                    ProjectName = projectName,
                    Description = description,
                    StartDate = startDate,
                    EndDate = endDate
                };

                projectDomain.Add(project);
                System.Console.WriteLine("Project Details Are Added Successfully");

                Console.WriteLine("Do you want to add one more Project (yes/No)");
                string AddMore = Console.ReadLine().ToLower();
                if (AddMore != "yes")
                {
                    break;
                }
            }

            Console.WriteLine("Do you want to add an Employee with a Role (yes/No):");
            string addEmployee = Console.ReadLine().ToLower();

            if (addEmployee == "yes")
            {
                while (true)
                {
                    Console.WriteLine("Enter Project Id to add an employee to the project");
                    int projectid = int.Parse(Console.ReadLine());

                    if (addEmployeeToProjectDomain.CheckProjectId(projectid))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Entered Project Id is not found");
                        Console.ForegroundColor = ConsoleColor.White;
                        return;
                    }

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    EmployeeId:
                    Console.WriteLine("Enter Employee Id to add an employee to the project");
                    int employeeid = int.Parse(Console.ReadLine());

                    if (addEmployeeToProjectDomain.CheckEmployeeId(employeeid))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Entered employee Id does not exist");
                        Console.ForegroundColor = ConsoleColor.White;
                        goto EmployeeId;
                    }

                    bool result = addEmployeeToProjectDomain.AddEmpToProject(projectid, employeeid);

                    if (result)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine(
                            $"EmployeeId:{employeeid} Added To Project:{projectid} Successfully"
                        );
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine(
                            $"EmployeeId:{employeeid} is already part of Project:{projectid}"
                        );
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.WriteLine("Do you want to add one more Employee To project(yes/No)");
                    string AddMore = Console.ReadLine().ToLower();
                    if (AddMore != "yes")
                    {
                        break;
                    }
                }
            }
        }

        public void ViewProjectDetails()
        {
            System.Console.WriteLine();
            bool hasProject = projectDomain.View();

            if (hasProject)
            {
                System.Console.WriteLine("********** Your Role Details Are *********************");
                foreach (var projectList in ProjectDomain.projects)
                {
                    System.Console.WriteLine(
                        $"ProjectId: {projectList.ProjectId}, ProjectName: {projectList.ProjectName}, Description: {projectList.Description}, StartDate: {projectList.StartDate}, EndDate: {projectList.EndDate}"
                    );
                }
            }
            else
            {
                System.Console.WriteLine("No Data Is Found");
            }
        }

        public Project GetByProjectId()
        {
            Console.WriteLine("Enter Your ProjectId:");
            int projectId = int.Parse(Console.ReadLine());

            var ProjectDetailsToGet = projectDomain.GetById(projectId);
            if (ProjectDetailsToGet != null)
            {
                System.Console.WriteLine("Project Details:");
                System.Console.WriteLine(
                    $"ProjectId: {ProjectDetailsToGet.ProjectId}, ProjectName: {ProjectDetailsToGet.ProjectName}, Description: {ProjectDetailsToGet.Description}, StartDate: {ProjectDetailsToGet.StartDate}, EndDate: {ProjectDetailsToGet.EndDate}"
                );
            }
            else
            {
                System.Console.WriteLine("No Project Data Is Found");
            }
            return ProjectDetailsToGet;
        }

        public Project DeleteProjectById()
        {
            System.Console.WriteLine("Enter Your ProjectId");
            int projectId = int.Parse(Console.ReadLine());

            var projectToDelete = projectDomain.GetById(projectId);
            if (projectToDelete != null)
            {
                projectDomain.Delete(projectToDelete);
                System.Console.WriteLine(
                    $"ProjectId:{projectToDelete.ProjectId} has been deleted successfully"
                );
            }
            else
            {
                System.Console.WriteLine($"ProjectId with {projectId} Not Found");
            }
            return projectToDelete;
        }
    }
}
