using System.Drawing;

public class Reward
{
    public Point Location { get; set; }
    public void Draw(ConsoleColor forground, ConsoleColor background)
    {
        "$".Write(Location.X, Location.Y, forground, background);
    }
}
