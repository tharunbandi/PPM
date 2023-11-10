using System;
using PPM.Model;
using PPM.Domain;

namespace PPM.UIConsole
{
    public class RoleConsole
    {
        RoleDomain roleDomain = new RoleDomain();

        public static int RoleModule()
        {
            System.Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.WriteLine("=============================");
            Console.WriteLine("╔══════════ Role Module ═════════╗");
            Console.WriteLine("║ Choose the required Option     ║");
            Console.WriteLine("║ 1. Add Role                    ║");
            Console.WriteLine("║ 2. View Role Details           ║");
            Console.WriteLine("║ 3. View By RoleId              ║");
            Console.WriteLine("║ 4. Delete Role By Id           ║");
            Console.WriteLine("║ 5. Return To Main Menu         ║");
            Console.WriteLine("╚════════════════════════════════╝");

            System.Console.WriteLine("Choose Your Option Here");
            int roleOption = int.Parse(Console.ReadLine());
            return roleOption;
        }

        public void AddRole()
        {
            while (true)
            {
                RoleId:
                Console.WriteLine("Enter Your RoleId:");
                int roleId = int.Parse(Console.ReadLine());
                if (RoleDomain.roles.Exists(role => role.RoleId == roleId))
                {
                    System.Console.WriteLine("This RoleId Is Already Exists");
                    goto RoleId;
                }
                RoleName:
                Console.WriteLine("Enter Your RoleName:");
                string roleName = Console.ReadLine();

                if (roleName.Any(char.IsDigit))
                {
                    System.Console.WriteLine("Please!Enter Proper Name");
                    goto RoleName;
                }

                Role role = new Role { RoleId = roleId, RoleName = roleName };

                roleDomain.Add(role);
                System.Console.WriteLine(
                    "*********Role Details Are Added Successfully************"
                );
                System.Console.WriteLine("Do You Want to Add One More Role (yes/No)");
                string AddMore = Console.ReadLine().ToLower();
                if (AddMore != "yes")
                {
                    return;
                }
            }
        }

        public void ViewRoleDetails()
        {
            System.Console.WriteLine();
            bool hasRoles = roleDomain.View();

            if (hasRoles)
            {
                System.Console.WriteLine("********** Your Role Details Are *********************");
                foreach (var role in RoleDomain.roles)
                {
                    System.Console.WriteLine($"RoleId: {role.RoleId}, RoleName: {role.RoleName}");
                }
            }
            else
            {
                System.Console.WriteLine("No Data Is Found");
            }
        }

        public void GetRoleById()
        {
            System.Console.WriteLine("Enter RoleId:");
            int roleId = int.Parse(Console.ReadLine());
            var role = roleDomain.GetById(roleId);
            if (role != null)
            {
                Console.WriteLine($"Role Id: {role.RoleId}, Role Name: {role.RoleName}");
            }
            else
            {
                Console.WriteLine("Role not found.");
            }
        }

        // public void DeleteRoleById()
        // {
        //     System.Console.WriteLine("Enter RoleId:");
        //     int roleId = int.Parse(Console.ReadLine());
        //     var roleToDelete = roleDomain.GetRoleById(roleId);
        //     if (roleToDelete != null)
        //     {
        //         roleDomain.DeleteRole(roleToDelete);
        //         Console.WriteLine($"Role with ID {roleId} has been deleted successfully.");
        //     }
        //     else
        //     {
        //         Console.WriteLine($"Role with ID {roleId} not found.");
        //     }
        // }


        public void DeleteRole()
        {
            Console.WriteLine("Enter Role ID:");
            int roleId = int.Parse(Console.ReadLine());

            // Instead of calling DeleteRole directly, call DeleteRoleSafely
            bool success = roleDomain.DeleteRoleSafely(roleId);

            if (success)
            {
                Console.WriteLine($"Role with ID {roleId} has been deleted successfully.");
            }
            else
            {
                Console.WriteLine($"Role with ID {roleId} not found or is mapped to a project.");
            }
        }
    }
}
