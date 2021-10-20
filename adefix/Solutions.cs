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
            if (Directory.Exists(AdobeSystemsLocalDataDirectory))
            {
                Console.WriteLine($"Searching Adobe local app data directory for \"{AdobeDigitalEditionsExeSearchPattern}\":");
                Console.WriteLine(AdobeSystemsLocalDataDirectory);

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
            Console.WriteLine("Finding Adobe Adept registry key");

            if (Registry.CurrentUser.GetValue("Software\\Adobe") == null)
            {
                Console.WriteLine("Cannot find Adobe Adept registry key");

                return;
            }

            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Adobe", true);

            if (registryKey != null)
            {
                registryKey.DeleteSubKey("Adept\\Device");
                registryKey.DeleteSubKey("Adept");
                Console.WriteLine("Adobe Adept registry key deleted");
            }
            else
            {
                Console.WriteLine("Cannot find Adobe Adept registry key");
            }
        }
    }
}
