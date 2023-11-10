using System.Linq;
using PPM.Model;
using System.Collections.Generic;

namespace PPM.Domain
{
    public class DeleteEmployeeToProjectDomain
    {
        // Define a list of projects
        public static List<Project> projects = new List<Project>();

        public  bool CheckProjectId(int pId)
        {
            var pidexist = ProjectDomain.projects.Find(item => item.ProjectId == pId);
            if (pidexist != null)
            {
                return false;
            }
            return true;
        }
        public  bool CheckEmployeeId(int eId)
        {
            var eidexist = EmployeeDomain.employees.Find(item => item.EmployeeId == eId);
            if (eidexist != null)
            {
                return false;
            }
            return true;
        }


        public  bool DeleteEmployeeFromProjects(int pId, int eId)
        {
            var project = ProjectDomain.projects.SingleOrDefault(p => p.ProjectId == pId);
            if (project != null && project.EmployeeIds.Remove(eId)) 
            {
                return true;
            }
            else
            {
                return false; 
            }

        }
    }
}
