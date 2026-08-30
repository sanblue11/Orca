namespace Orca.Shell
{
    static class OrcaShell
    {
        public static string[]? Entry()
        {
            return Shell();
        }

        private static string[]? Shell()
        {
            Console.Write($"{Status.current_drive}:{string.Join(">", Status.current_path ?? [])}$ ");
            string? command = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(command))
            {
                return Lexer(command);
            }
            return null;
        }

        private static string[] Lexer(string command)
        {
            return command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
