static class Function
{
    public static void FN_help(string? args)
    {
        if (args == null)
        {
            Console.WriteLine("""
                For more information, type 'help <command>'.
                wipe    Wipe the screen.
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
                    Show help on Orca commands.

                    help <Command>
                        <Command>   Show help information for the command.
                    """);
                break;
            case Orca.CommandType.WIPE:
                Console.WriteLine("""
                    Wipe the screen.

                    wipe
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