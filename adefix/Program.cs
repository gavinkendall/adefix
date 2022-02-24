//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="Gavin Kendall">
//     Copyright (c) 2017-2022 Gavin Kendall
// </copyright>
// <author>Gavin Kendall</author>
// <summary>The main entry for Adobe Digital Editions Fix (adefix.exe).</summary>
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program. If not, see <https://www.gnu.org/licenses/>.
//-----------------------------------------------------------------------
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

                Console.WriteLine("Adobe Digital Editions Fix (v1.2)");
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
