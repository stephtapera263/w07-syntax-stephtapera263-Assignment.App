public static class Extensions
{
    public static void Write(this string str, int x, int y, ConsoleColor foreground, ConsoleColor background)
    {
        Console.ForegroundColor = foreground;
        Console.BackgroundColor = background;
        Console.SetCursorPosition(x, y);
        Console.Write(str);
        Console.ResetColor();
    }
    public static void Write(this char c, int x, int y, ConsoleColor foreground, ConsoleColor background)
    {
        Write(c.ToString(), x, y, foreground, background);
    }
}
