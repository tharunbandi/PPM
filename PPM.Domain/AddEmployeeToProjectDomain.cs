using System.Linq;
using PPM.Model;
using System.Collections.Generic;

namespace PPM.Domain
{
    public class AddEmployeeToProjectDomain
    {
       
        // Define a list of projects


        public bool CheckProjectId(int pId)
        {
            var pidexist = ProjectDomain.projects.Find(item => item.ProjectId == pId);
            if (pidexist != null)
            {
                return false;
            }
            return true;
        }

        public bool CheckEmployeeId(int eId)
        {
            var eidexist = EmployeeDomain.employees.Find(item => item.EmployeeId == eId);
            if (eidexist != null)
            {
                return false;
            }
            return true;
        }

      
        public  bool AddEmpToProject(int pId, int eId)
        {
            var project = ProjectDomain.projects.SingleOrDefault(p => p.ProjectId == pId);


            if (project!.EmployeeIds.Contains(eId))
            {
                return false;  // Employee is already part of the project.
            }
            else
            {
                project.EmployeeIds.Add(eId);
                return true;  // Employee added to the project successfully.
            }
        }
    }
}
