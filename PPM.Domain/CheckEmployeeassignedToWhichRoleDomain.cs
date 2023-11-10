using System.Linq;
using PPM.Model;


namespace PPM.Domain
{
    public class ViewEmployeeAssignedToWhichRoleDomain
    {
        public  Project GetProjectById(int projectId)
        {
            return ProjectDomain.projects.FirstOrDefault(p => p.ProjectId == projectId);
        }
    }
}
