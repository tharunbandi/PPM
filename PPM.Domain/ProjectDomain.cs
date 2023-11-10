using System.Collections.Generic;
using System;
//using System.Data.SqlClient;

using PPM.Model;

namespace PPM.Domain
{
    public class ProjectDomain : Ioperation<Project>
    {
        //ProjectDomain projectDomain = new ProjectDomain();

        //string ConnectionString ="Server=RHJ-9F-D200\\SQLEXPRESS;DataBase=ProlificsProjectManager;Integrated Security=SSPI";

        public static List<Project> projects = new List<Project>();

        public void Add(Project project)
        {
            projects.Add(project);
            // using (SqlConnection connection = new SqlConnection(ConnectionString))
            // {
            //     connection.Open();
            //     string sqlQuery =
            //         "INSERT INTO Project (ProjectId, ProjectName, Description, StartDate, EndDate) VALUES (@ProjectId, @ProjectName, @Description, @StartDate, @EndDate)";
            //     using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            //     {
            //         command.Parameters.AddWithValue("@ProjectId", project.ProjectId);
            //         command.Parameters.AddWithValue("@ProjectName", project.ProjectName);
            //         command.Parameters.AddWithValue("@Description", project.Description);
            //         command.Parameters.AddWithValue("@StartDate", project.StartDate);
            //         command.Parameters.AddWithValue("@EndDate", project.EndDate);
            //         command.ExecuteNonQuery();
            //     }
            // }
        }

        public Project GetById(int ProjectId)
        {
            var projectDetails = ProjectDomain.projects.FirstOrDefault(
                p => p.ProjectId == ProjectId
            );
            return projectDetails;

            // using (SqlConnection connection = new SqlConnection(ConnectionString))
            // {
            //     connection.Open();
            //     string sqlQuery = "Select * from Project Where ProjectId=@ProjectId";
            //     using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            //     {
            //         command.Parameters.AddWithValue("@ProjectId", ProjectId);
            //         using (SqlDataReader reader = command.GetExecuteReader())
            //         {
            //             while (reader.Read())
            //             {
            //                 command.Parameters.AddWithValue("@ProjectId", ProjectId);
            //                 command.Parameters.AddWithValue("@ProjectName",ProjectName);
            //                 command.Parameters.AddWithValue("@Description",Description);
            //                 command.Parameters.AddWithValue("@StartDate",StartDate);
            //                 command.Parameters.AddWithValue("@EndDate", EndDate);
            //             }
            //         }
            //     }
            // }
        }

        public void Delete(Project project)
        {
            if (projects.Contains(project))
            {
                projects.Remove(project);
            }
        }

        public bool View()
        {
            return projects.Count > 0;
        }
    }
}
