//-----------------------------------------------------------------------
// <copyright file="Solutions.cs" company="Gavin Kendall">
//     Copyright (c) 2017-2022 Gavin Kendall
// </copyright>
// <author>Gavin Kendall</author>
// <summary>The solutions for Adobe Digital Editions Fix (adefix.exe).</summary>
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
    using System.IO;
    using Microsoft.Win32;

    public static class Solutions
    {
        private static readonly string AdobeDigitalEditionsExeSearchPattern = "DigitalEditions.exe*";
        private static readonly string AdobeSystemsLocalDataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Adobe_Systems_Incorporate";

        public static void DeleteAdobeLocalAppDirectorySubfolders()
        {
            Console.WriteLine($"Searching Adobe local app data directory for \"{AdobeDigitalEditionsExeSearchPattern}\":");
            Console.WriteLine(AdobeSystemsLocalDataDirectory);

            if (Directory.Exists(AdobeSystemsLocalDataDirectory))
            {
                string[] dirs = Directory.GetDirectories(AdobeSystemsLocalDataDirectory, AdobeDigitalEditionsExeSearchPattern);

                Console.WriteLine($"{dirs.Length} subfolder entries found");

                foreach (string dir in dirs)
                {
                    Directory.Delete(dir, true);
                    Console.WriteLine($"Deleted \"{dir}\"");
                }
            }
            else
            {
                Console.WriteLine($"Cannot find Adobe local app data directory \"{AdobeSystemsLocalDataDirectory}\"");
            }
        }

        public static void DeleteAdobeAdeptRegistryKey()
        {
            Console.WriteLine("Finding Adobe registry keys");

            Console.WriteLine(@"Finding HKEY_CURRENT_USER\Software\Adobe");

            if (Registry.CurrentUser.OpenSubKey("Software\\Adobe") == null)
            {
                Console.WriteLine("Cannot find Adobe registry key");

                return;
            }

            Console.WriteLine(@"Finding HKEY_CURRENT_USER\Software\Adobe\Adept");

            if (Registry.CurrentUser.OpenSubKey("Software\\Adobe\\Adept") == null)
            {
                Console.WriteLine("Cannot find Adobe Adept registry key");

                return;
            }

            Console.WriteLine(@"Finding HKEY_CURRENT_USER\Software\Adobe\Adept\Device");

            if (Registry.CurrentUser.OpenSubKey("Software\\Adobe\\Adept\\Device") == null)
            {
                Console.WriteLine("Cannot find Adobe Adept Device registry key");

                return;
            }

            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Adobe", true);

            if (registryKey != null)
            {
                Console.WriteLine(@"HKEY_CURRENT_USER\Software\Adobe\Adept\Device deleted");
                registryKey.DeleteSubKey("Adept\\Device");

                registryKey.DeleteSubKey("Adept");
                Console.WriteLine(@"HKEY_CURRENT_USER\Software\Adobe\Adept deleted");
            }
            else
            {
                Console.WriteLine("Cannot find Adobe Adept registry key");
            }
        }
    }
}
