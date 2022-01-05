using System;
using System.Diagnostics;


namespace VoiceMeeterPatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            killProcess("voicemeeter8x64");
            killProcess("voicemeeter8");

            patchVoiceMeterBytesX64(@"C:\Program Files (x86)\VB\Voicemeeter\voicemeeter8x64.exe");
            patchVoiceMeterBytesX32(@"C:\Program Files (x86)\VB\Voicemeeter\voicemeeter8.exe");

            Console.WriteLine("Voicemeeter Patched! You can start Voicemeeter now! >>> press any key to leave");
            Console.ReadLine();
        }

        public static void killProcess(string name)
        {
            foreach (Process process in Process.GetProcessesByName(name))
            {
                if (process == null || process.MainWindowHandle == IntPtr.Zero)
                    continue;

                try
                {
                    process.Kill();
                    process.WaitForExit(5000);
                }
                catch { }
            }
        }

        public static void patchVoiceMeterBytesX32(string pathx32)
        {
            if (System.IO.File.Exists(pathx32) == false)
                return;

            byte[] fileBytes = System.IO.File.ReadAllBytes(pathx32);
            fileBytes[0x8687C] = 0xC7;

            fileBytes[0x86882] = 0x13;
            fileBytes[0x86883] = 0x0;
            fileBytes[0x86884] = 0x0;
            fileBytes[0x86885] = 0x0;
            fileBytes[0x86886] = 0x0;
            fileBytes[0x86887] = 0x90;
            fileBytes[0x86888] = 0x90;

            fileBytes[0xA67E3] = 0xC7;

            fileBytes[0xA67E9] = 0x13;
            fileBytes[0xA67EA] = 0x0;
            fileBytes[0xA67EB] = 0x0;
            fileBytes[0xA67EC] = 0x0;


            System.IO.File.WriteAllBytes(pathx32, fileBytes);
        }

        public static void patchVoiceMeterBytesX64(string pathx64)
        {
            if (System.IO.File.Exists(pathx64) == false)
                return;

            byte[] fileBytes = System.IO.File.ReadAllBytes(pathx64);
            fileBytes[0x93880] = 0xC7;
            fileBytes[0xB5BCB] = 0xC7;

            fileBytes[0x93886] = 0x13;
            fileBytes[0x93887] = 0x0;
            fileBytes[0x93888] = 0x0;
            fileBytes[0x93889] = 0x0;

            fileBytes[0xB5BD1] = 0x13;
            fileBytes[0xB5BD2] = 0x0;
            fileBytes[0xB5BD3] = 0x0;
            fileBytes[0xB5BD4] = 0x0;
            fileBytes[0xB5BD5] = 0x90;

            System.IO.File.WriteAllBytes(pathx64, fileBytes);
        }
    }
}
