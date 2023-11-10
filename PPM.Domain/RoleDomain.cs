using PPM.Model;
using System.Collections.Generic;
//using System.Data.SqlClient;

namespace PPM.Domain
{
    public class RoleDomain :Ioperation<Role>
    
    {
          //string ConnectionString ="Server=RHJ-9F-D200\\SQLEXPRESS;DataBase=ProlificsProjectManager;Integrated Security=SSPI";
        public static List<Role> roles = new List<Role>();

        public void Add(Role role)
        {
               roles.Add(role);
            //   using (SqlConnection connection = new SqlConnection(ConnectionString))
            // {
            //     connection.Open();
            //     string sqlQuery ="INSERT INTO Role (RoleId,RoleName) VALUES (@RoleId,@RoleName)";
            //     using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            //     {
            //         command.Parameters.AddWithValue("@RoleId", role.RoleId);
            //         command.Parameters.AddWithValue("@RoleName", role.RoleName);
                   
            //         command.ExecuteNonQuery();
            //     }
            // }
        }

        public Role GetById(int roleId)
        {
            var role = RoleDomain.roles.FirstOrDefault(r => r.RoleId == roleId);
            return role;
        }

        public void Delete(Role role)
        {
            if (roles.Contains(role))
            {
                roles.Remove(role);
            }
        }

        public bool IsRoleMappedToProject(int roleId)
        {
            // Check if the role is mapped to any project
            return EmployeeDomain.employees.Any(employee=> employee.RoleId == roleId);
        }

        public bool DeleteRoleSafely(int roleId)
        {
            if (IsRoleMappedToProject(roleId))
            {
                return false;
            }
            else
            {
                // Proceed with the deletion of the role
                Role roleToDelete = GetById(roleId);
                if (roleToDelete != null)
                {
                    Delete(roleToDelete);  //Role deleted Successfully
                    return true;
                }
                else
                {
                    return false;  //Role Not found
                }
            }
        }

        public bool View()
        {
            return roles.Count > 0;
        }
    }
}
