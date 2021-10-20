namespace adefix
{
    using System;

    public class Program
    {
        public static void Main()
        {
            try
            {
                ShowMenu();
            }
            catch
            {
                Console.WriteLine("An error was encountered");
            }
        }

        private static void Continue()
        {
            Console.WriteLine("\nPress Enter to continue ...");
            Console.ReadLine();
        }

        private static void ShowMenu()
        {
            ConsoleKey key;

            do
            {
                Console.Clear();

                Console.WriteLine("Adobe Digital Editions Fix (v1.1)");
                Console.WriteLine("Developed by Gavin Kendall");
                Console.WriteLine("==============================================");

                Console.WriteLine("\nPlease select an option.");

                Console.WriteLine("\n1) Fix issues with the application freezing");
                Console.WriteLine("2) Fix issues with books that cannot open");
                Console.WriteLine("3) Fix issues with authorization/de-authorization");
                Console.WriteLine("4) All of the above");

                Console.WriteLine("\nPress Esc to exit");

                key = Console.ReadKey().Key;

                Fix(key);

            } while (!key.Equals(ConsoleKey.Escape));
        }

        private static void Fix(ConsoleKey key)
        {
            try
            {
                switch (key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.NumPad2:
                        Console.Clear();
                        Solutions.DeleteAdobeLocalAppDirectorySubfolders();
                        Continue();
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        Console.Clear();
                        Solutions.DeleteAdobeAdeptRegistryKey();
                        Continue();
                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        Console.Clear();
                        Solutions.DeleteAdobeLocalAppDirectorySubfolders();
                        Solutions.DeleteAdobeAdeptRegistryKey();
                        Continue();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.Clear();

                Console.WriteLine("Exception error encountered");
                Console.WriteLine(ex.ToString());

                Continue();
                ShowMenu();
            }
        }
    }
}
