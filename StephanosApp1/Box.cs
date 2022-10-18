using System.Drawing;

public class Box
{
    public Rectangle Boundary { get; set; } = new Rectangle(0, 0, 20, 50);

    public Point GetRandomPointInside()
    {
        var random = new Random();
        var x = random.Next(Boundary.Left + 1, Boundary.Left + Boundary.Width - 1);
        var y = random.Next(Boundary.Top + 1, Boundary.Top + Boundary.Height - 1);
        return new Point(x, y);
    }

    public void Draw(ConsoleColor foreground = ConsoleColor.White, ConsoleColor background = ConsoleColor.Black)
    {
        drawTop();
        
        drawMiddle();
        
        drawBottom();

        void drawTop()
        {
            var y = Boundary.Top;
            '┌'.Write(Boundary.Left, y, foreground, background);
            new string('─', Boundary.Width).Write(Boundary.Left + 1, y, foreground, background);
            '┐'.Write(Boundary.Left + Boundary.Width + 1, y, foreground, background);
        }

        void drawBottom()
        {
            var y = Boundary.Top + Boundary.Height;
            '└'.Write(Boundary.Left, y, foreground, background);
            new string('─', Boundary.Width).Write(Boundary.Left + 1, y, foreground, background);
            '┘'.Write(Boundary.Left + Boundary.Width + 1, y, foreground, background);
        }

        void drawMiddle()
        {
            for (int i = 1; i <= Boundary.Height; i++)
            {
                '│'.Write(Boundary.Left, i + Boundary.Top, foreground, background);
                '│'.Write(Boundary.Left + Boundary.Width + 1, i + Boundary.Top, foreground, background);
            }
        }
    }
}
