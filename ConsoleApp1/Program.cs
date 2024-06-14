public class Position
{
    public int X { get; set; }
    public int Y { get; set; }

    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }
}
public class Player
{
    public string Name { get; set; }
    public Position Position { get; set; }
    public int GemCount { get; set; }

    public Player(string name, Position position)
    {
        Name = name;
        Position = position;
        GemCount = 0;
    }

    public void Move(char direction)
    {
        switch (direction)
        {
            case 'U':
                Position.Y--;
                break;
            case 'D':
                Position.Y++;
                break;
            case 'L':
                Position.X--;
                break;
            case 'R':
                Position.X++;
                break;
        }
    }
}
public class Cell
{
    public string Occupant { get; set; }

    public Cell()
    {
        Occupant = "-";
    }
}

public class Board
{
    private static Random random = new Random();
    public Cell[,] Grid { get; set; }

    public Board()
    {
        Grid = new Cell[6, 6];
        for (int y = 0; y < 6; y++)
        {
            for (int x = 0; x < 6; x++)
            {
                Grid[y, x] = new Cell();
            }
        }
        InitBoard();
    }

    private void InitBoard()
    {
        // Place obstacles
        int numObstacles = 5;
        for (int i = 0; i < numObstacles; i++)
        {
            PlaceRandom("O");
        }

        // Place gems
        int numGems = 5;
        for (int i = 0; i < numGems; i++)
        {
            PlaceRandom("G");
        }
    }

    private void PlaceRandom(string occupant)
    {
        int x, y;
        do
        {
            x = random.Next(0, 6);
            y = random.Next(0, 6);
        } while (Grid[y, x].Occupant != "-");

        Grid[y, x].Occupant = occupant;
    }

    public void Display(Player player1, Player player2)
    {
        for (int y = 0; y < 6; y++)
        {
            for (int x = 0; x < 6; x++)
            {
                if (player1.Position.X == x && player1.Position.Y == y)
                {
                    Console.Write("P1 ");
                }
                else if (player2.Position.X == x && player2.Position.Y == y)
                {
                    Console.Write("P2 ");
                }
                else
                {
                    Console.Write(Grid[y, x].Occupant + " ");
                }
            }
            Console.WriteLine();
        }

    }
}