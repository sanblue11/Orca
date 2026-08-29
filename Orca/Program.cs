class Program
{
    public static int Main()
    {
        Console.WriteLine("Orca Shell [Version 0.0.1]\n");
        Shell.Entry();
        return 0;
    }
}

static class Shell
{
    public static void Entry()
    {
        if(Status.current_drive == null && Status.current_path == null)
        {
            Status.current_drive = "Drive";
            Status.current_path = ["User", "San"];
        }
        while (true)
        {
            Console.Write($"{Status.current_drive}:{string.Join(">", Status.current_path ?? [])}$ ");
            string? command = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(command))
            {
                continue;
            }
            else if (command == "exit")
            {
                break;
            }
            else 
            {
                string[] tokens = Lexer(command);
                Orca.Entry(tokens);
                Console.WriteLine();
            }
        }
    }

    private static string[] Lexer(string command)
    {
        return command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    }
}