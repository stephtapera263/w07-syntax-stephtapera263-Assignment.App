// See https://aka.ms/new-console-template for more information
Console.Clear();
Console.CursorVisible = false;

var game = new Game();

while (true)
{
    var direction = Input.Listen(game.CurrentDirection);

    game.Update(direction);

    var speed = determineSpeed(direction);
    System.Threading.Thread.Sleep(speed);
}

int determineSpeed(Direction direction)
{
    switch (direction)
    {
        case Direction.Left:
        case Direction.Right:
            return 50;
        default:
            return 100;
    }
}
