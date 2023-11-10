using PPM.Domain;
using PPM.UIConsole;

namespace PPM.Main
{
    public class MainConsole
    {
        public static void Title()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine("***************************************************");
            System.Console.WriteLine("******WELCOME TO PROLIFICS PROJECT MANAGER*********");
            System.Console.WriteLine("***************************************************");
        }

        public static int Menu()
        {
            System.Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("╔════════════════════════════════════╗");
            Console.WriteLine("║**********Main Menu ****************║");
            Console.WriteLine("║ 1. Role Module                     ║");
            Console.WriteLine("║ 2. Project Module                  ║");
            Console.WriteLine("║ 3. Employee Module                 ║");
            Console.WriteLine("║ 4. Add Employee To Project Module  ║");
            Console.WriteLine("║ 5. DeleteEmployeeFromProjectModule ║");
            Console.WriteLine("║ 6. CheckEmployeeAssignedToWhichRole║");
            Console.WriteLine("| 7. Save                            |");
            Console.WriteLine("║ 8. Exit                            ║");
            Console.WriteLine("╚════════════════════════════════════╝");

            Console.WriteLine("Choose Your Option Here!");
            int choice = int.Parse(Console.ReadLine());
            return choice;
        }

        public static void MenuExit()
        {
            System.Console.WriteLine("---------------------------");
            System.Console.WriteLine("Exiting the Project Manager");
            System.Console.WriteLine("---------------------------");
        }

        public static void Invalid()
        {
            System.Console.WriteLine("--------------------------");
            System.Console.WriteLine("Please!Choose Valid choice");
            System.Console.WriteLine("--------------------------");
        }
        public static void SaveAppState()
        {
            SerializeData.SaveState();
            System.Console.WriteLine("The data is saved");
        }
    }
}
