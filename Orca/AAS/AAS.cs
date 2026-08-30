namespace Orca.AAS
{
    public static class OrcaAAS 
    { 
        public static void Entry()
        {
            string diskPath = ".\\DISK";
            if (!Directory.Exists(diskPath))
            {
                Console.WriteLine("DISK directory not found.");
                return;
            }
            foreach (string file in Directory.EnumerateFiles(diskPath, "*.odf"))
            {
                Parse(file);
            }
        }

        private static void Parse(string filePath)
        {
            using FileStream stream = File.OpenRead(filePath);
            int raw;
            while ((raw = stream.ReadByte()) != -1)
            {
                byte value = (byte)raw;

                if (Enum.IsDefined(typeof(AASToken), value))
                {
                    AASToken token = (AASToken)value;

                    Console.WriteLine($"Token: {token}");
                }
                else
                {
                    Console.WriteLine($"Data: 0x{value:X2}");
                }
            }
        }
    }

    enum AASToken : byte
    {
        PART = 0xF0,
        DRIVE = 0xF1,
        DIR = 0xF2,
        FILE = 0xF3,
        END = 0xFF
    }
}