
using System.Drawing;

public class Game
{
    public Game()
    {
        Box.Boundary = new Rectangle(5, 5, 50, 20);

        Ship.Location = Box.GetRandomPointInside();

        PlaceReward();

        Box.Draw();
    }

    public int Fuel { get; set; } = 100;

    public DateTime Started { get; } = DateTime.Now;

    public TimeSpan Duration => DateTime.Now - Started;

    public Reward Reward { get; } = new Reward();

    public Ship Ship { get; } = new Ship();

    public Box Box { get; } = new Box();

    public int Score { get; set; } = 0;

    public Direction CurrentDirection { get; private set; } = Direction.Stop;

    public void PlaceReward()
    {
        Reward.Location = Box.GetRandomPointInside();
        while (Reward.Location == Ship.Location)
        {
            Reward.Location = Box.GetRandomPointInside();
        }
    }

    public void Update(Direction direction)
    {
        if (gameIsOver())
        {
            return;
        }

        CurrentDirection = direction;

        Box.Draw();

        Reward.Draw(ConsoleColor.Black, ConsoleColor.Yellow);

        if (scored())
        {
            Box.Draw(ConsoleColor.White, ConsoleColor.Green);
            Score++;
            Fuel = Fuel + 20;
            PlaceReward();
        }
        
        drawScore();

        bool scored() => Ship.Location == Reward.Location;


        void drawScore()
        {
            var x = Box.Boundary.Left + Box.Boundary.Width + 5;
            var y = Box.Boundary.Top + 5;
            $"{Score} Points".Write(x, y, ConsoleColor.Black, ConsoleColor.White);
        }
        updateTime();

        updateFuel();

        if (outOfFuel())
        {
            endGame();
        }
        else
        {
            Ship.MoveThenDraw(direction, Box.Boundary);
        }

        void updateFuel()
        {
            if (CurrentDirection != Direction.Stop && Duration.Milliseconds % 3 == 0)
            {
                Fuel--;
            }

            drawFuel();

            void drawFuel()
            {
                var x = Box.Boundary.Left + Box.Boundary.Width + 5;
                var y = Box.Boundary.Top + Box.Boundary.Height - 1;
                $"Fuel left: {Fuel:0000000}".Write(x, y, ConsoleColor.White, ConsoleColor.Black);
            }
        }

        void updateTime()
        {
            var x = Box.Boundary.Left + Box.Boundary.Width + 5;
            var y = Box.Boundary.Top + Box.Boundary.Height;
            $"Game time: {Duration:h':'mm':'ss}".Write(x, y, ConsoleColor.White, ConsoleColor.Black);
        }

        void endGame()
        {
            CurrentDirection = Direction.GameOver;
            Box.Draw(ConsoleColor.White, ConsoleColor.Red);
        }

        bool gameIsOver()
        {
            return CurrentDirection == Direction.GameOver;
        }

        bool outOfFuel()
        {
            return Fuel == 0;
        }
    }
}
