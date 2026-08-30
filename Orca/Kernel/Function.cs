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
            OrcaKernel.CommandType type = args switch
            {
                "help" => OrcaKernel.CommandType.HELP,
                "wipe" => OrcaKernel.CommandType.WIPE,
                _ => OrcaKernel.CommandType.UNKNOWN
            };
            switch (type)
            {
                case OrcaKernel.CommandType.HELP:
                    Console.WriteLine("""
                    -HELP-  Show help on Orca commands.

                    Usage1: help
                    Usage2: help <Command>
                    """);
                    break;
                case OrcaKernel.CommandType.WIPE:
                    Console.WriteLine("""
                    -WIPE-  Wipe the screen.

                    Usage:  wipe
                    """);
                    break;
                case OrcaKernel.CommandType.UNKNOWN:
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