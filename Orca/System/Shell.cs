namespace Orca.System
{
    internal static class Shell
    {
        public static string[]? Interface()
        {
            string? input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
                return Lexer(input);
            return null;
        }

        private static string[] Lexer(string input)
        {
            return input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        }
    }
}