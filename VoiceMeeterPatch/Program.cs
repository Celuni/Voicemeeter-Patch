using System;

namespace VoiceMeeterPatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            patchVoiceMeterBytes(@"C:\Program Files (x86)\VB\Voicemeeter\voicemeeter8x64.exe");

            Console.WriteLine("Voicemeeter cracked! press any key to leave");
            Console.ReadLine();
        }

        public static void patchVoiceMeterBytes(string path)
        {
            if (System.IO.File.Exists(path) == false)
                return;
            byte[] fileBytes = System.IO.File.ReadAllBytes(path);
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

            System.IO.File.WriteAllBytes(path, fileBytes);
        }
    }
}
