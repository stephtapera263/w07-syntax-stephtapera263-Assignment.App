using System.Drawing;

public class Ship
{
    public Point Location { get; set; } = default!;

    public void MoveThenDraw(Direction direction, Rectangle boundary, ConsoleColor foreground = ConsoleColor.White, ConsoleColor background = ConsoleColor.Black)
    {
        eraseShip();

        updateNewLocation();

        drawShip();

        void eraseShip() => " ".Write(Location.X, Location.Y, foreground, background);

        void drawShip() => determineShipCharacter().Write(Location.X, Location.Y, foreground, background);

        void updateNewLocation()
        {
            var box = new Rectangle(boundary.Left + 1, boundary.Top + 1, boundary.Width - 1, boundary.Height - 1);

            Location = direction switch
            {
                Direction.Left => box.Contains(newLoc(x: -1)) ? newLoc(x: -1) : newLoc(x: +boundary.Width - 2),
                Direction.Right => box.Contains(newLoc(x: +1)) ? newLoc(x: +1) : newLoc(x: -boundary.Width + 2),
                Direction.Up => box.Contains(newLoc(y: -1)) ? newLoc(y: -1) : newLoc(y: +boundary.Height - 2),
                Direction.Down => box.Contains(newLoc(y: +1)) ? newLoc(y: +1) : newLoc(y: -boundary.Height + 2),
                _ => Location,
            };

            Point newLoc(int x = 0, int y = 0) => new Point(Location.X + x, Location.Y + y);
        }

        char determineShipCharacter()
        {
            return direction switch
            {
                Direction.Up => '▲',
                Direction.Down => '▼',
                Direction.Left => '◄',
                Direction.Right => '►',
                _ => '■',
            };
        }
    }
}
