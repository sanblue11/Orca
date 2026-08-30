namespace Orca.Kernel
{
    static class Function
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
            Orca.CommandType type = args switch
            {
                "help" => Orca.CommandType.HELP,
                "wipe" => Orca.CommandType.WIPE,
                _ => Orca.CommandType.UNKNOWN
            };
            switch (type)
            {
                case Orca.CommandType.HELP:
                    Console.WriteLine("""
                    -HELP-  Show help on Orca commands.

                    Usage1: help
                    Usage2: help <Command>
                    """);
                    break;
                case Orca.CommandType.WIPE:
                    Console.WriteLine("""
                    -WIPE-  Wipe the screen.

                    Usage:  wipe
                    """);
                    break;
                case Orca.CommandType.UNKNOWN:
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