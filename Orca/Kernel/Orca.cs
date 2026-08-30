using Orca.AAS;
using Orca.Shell;

namespace Orca.Kernel
{
    static class Orca
    {
        public static void Entry()
        {
            OrcaAAS.RenewCurrentDrive();
            OrcaAAS.RenewCurrentPath();

            Console.WriteLine("Orca Kernel [Version 0.0.1]\n");
            while (true)
            {
                string[]? tokens = OrcaShell.Entry();
                if (tokens == null)
                    continue;
                else if (tokens[0] == "exit")
                    break;

                CommandType type = Parse(tokens);
                Execute(type, tokens);
            }
        }

        private static CommandType Parse(string[] tokens)
        {
            CommandType type = tokens[0] switch
            {
                "dir" => CommandType.DIR,
                "dv" => CommandType.DIVERT,
                "help" => CommandType.HELP,
                "wipe" => CommandType.WIPE,
                _ => CommandType.UNKNOWN
            };
            return type;
        }

        private static void Execute(CommandType type, string[] tokens)
        {
            switch (type)
            {
                case CommandType.HELP:
                    Function.FN_help(tokens.Length > 1 ? tokens[1] : null);
                    break;
                case CommandType.WIPE:
                    Function.FN_wipe();
                    break;
                case CommandType.UNKNOWN:
                    Console.WriteLine($"[Orca] Unknown Command -> '{tokens[0]}'");
                    break;
            }
            Console.WriteLine();
        }

        public enum CommandType
        {
            DIR,
            DIVERT,
            HELP,
            WIPE,
            UNKNOWN
        }
    }
}