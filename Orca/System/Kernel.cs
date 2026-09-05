namespace Orca.System
{
    internal static class Kernel
    {
        public static void Entry()
        {
            while (true)
            {
                Console.Write("A:/$ ");

                string[]? command = Shell.Interface();
                if (command == null)
                    continue;
                if (command[0] == "exit")
                    break;

                Command type = ParseCommand(command);
                ExecuteCommand(type, command);
                Console.WriteLine();
            }
        }

        private static Command ParseCommand(string[] command)
        {
            return command[0] switch
            {
                "help" => Command.HELP,
                "wipe" => Command.WIPE,
                _ => Command.UNKNOWN
            };
        }

        private static void ExecuteCommand(Command type, string[] command)
        {
            switch (type)
            {
                case Command.HELP:
                    Function.FN_help(command.Length > 1 ? command[1] : null);
                    break;
                case Command.WIPE:
                    Function.FN_wipe();
                    break;
                case Command.UNKNOWN:
                    Console.WriteLine($"[Orca] Unknown Command -> '{command[0]}'");
                    break;
            }
        }
    }

    internal enum Command
    {
        HELP,
        WIPE,
        UNKNOWN
    }
}
