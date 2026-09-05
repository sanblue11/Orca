namespace Orca.System
{
    internal static class Function
    {
        public static void FN_help(string? args)
        {
            if (args == null)
            {
                Console.WriteLine("""
                -HELP-  Show help on Orca commands.
                -WIPE-  Wipe the screen.

                For more information, type 'help <command>'.
                """);
                return;
            }
            Command type = args switch
            {
                "help" => Command.HELP,
                "wipe" => Command.WIPE,
                _ => Command.UNKNOWN
            };
            switch (type)
            {
                case Command.HELP:
                    Console.WriteLine("""
                    -HELP-  Show help on Orca commands.

                    Usage1: help
                    Usage2: help <Command>
                    """);
                    break;
                case Command.WIPE:
                    Console.WriteLine("""
                    -WIPE-  Wipe the screen.

                    Usage:  wipe
                    """);
                    break;
                case Command.UNKNOWN:
                    Console.WriteLine($"[Orca] Unknown Command -> '{args}'");
                    break;
            }
        }

        public static void FN_wipe()
        {
            Console.Clear();
        }
    }
}
