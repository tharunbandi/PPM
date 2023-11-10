using System.Xml.Serialization;
using PPM.Model;

namespace PPM.Domain
{

public class SerializeData
{
    // readonly Project projectobj = new();
    public static void SaveState()
    {
        string projectFile =
            @"C:\Users\TBandi\Desktop\New Prolifics Project Manager\PPM.XML\ProjectData.xml";
        string roleFile =
            @"C:\Users\TBandi\Desktop\New Prolifics Project Manager\PPM.XML\RoleData.xml";
        string employeeFile =
            @"C:\Users\TBandi\Desktop\New Prolifics Project Manager\PPM.XML\EmployeeData.xml";

        using (TextWriter projectWriter = new StreamWriter(projectFile))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Project>));
            serializer.Serialize(projectWriter, ProjectDomain.projects);
        }

        using (TextWriter employeeWriter = new StreamWriter(employeeFile))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Employee>));
            serializer.Serialize(employeeWriter, EmployeeDomain.employees);
        }

        using (TextWriter roleWriter = new StreamWriter(roleFile))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Role>));
            serializer.Serialize(roleWriter, RoleDomain.roles);
        }

        
    }
}
}
