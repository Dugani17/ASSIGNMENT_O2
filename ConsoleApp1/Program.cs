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
    public bool IsValidMove(Player player, char direction)
    {
        int newX = player.Position.X;
        int newY = player.Position.Y;

        switch (direction)
        {
            case 'U':
                newY--;
                break;
            case 'D':
                newY++;
                break;
            case 'L':
                newX--;
                break;
            case 'R':
                newX++;
                break;
        }

        return newX >= 0 && newX < 6 && newY >= 0 && newY < 6 && Grid[newY, newX].Occupant != "O";
    }

    public void CollectGem(Player player)
    {
        if (Grid[player.Position.Y, player.Position.X].Occupant == "G")
        {
            player.GemCount++;
            Grid[player.Position.Y, player.Position.X].Occupant = "-";
        }
    }
}

public class Game
{
    private Board board;
    private Player player1;
    private Player player2;
    private Player currentTurn;
    private int totalTurns;

    public Game()
    {
        board = new Board();
        player1 = new Player("P1", new Position(0, 0));
        player2 = new Player("P2", new Position(5, 5));
        currentTurn = player1;
        totalTurns = 0;
    }

    public void Start()
    {
        while (!IsGameOver())
        {
            board.Display(player1, player2);
            Console.Write($"{currentTurn.Name}'s turn (U, D, L, R): ");
            char move = Console.ReadKey().KeyChar;
            Console.WriteLine();

            if (board.IsValidMove(currentTurn, move))
            {
                currentTurn.Move(move);
                board.CollectGem(currentTurn);
                SwitchTurn();
                totalTurns++;
            }
            else
            {
                Console.WriteLine("Invalid move. Try again.");
            }
        }
        AnnounceWinner();
    }

    private void SwitchTurn()
    {
        currentTurn = (currentTurn == player1) ? player2 : player1;
    }

    private bool IsGameOver()
    {
        return totalTurns >= 30;
    }

    private void AnnounceWinner()
    {
        if (player1.GemCount > player2.GemCount)
        {
            Console.WriteLine("Player 1 wins!");
        }
        else if (player2.GemCount > player1.GemCount)
        {
            Console.WriteLine("Player 2 wins!");
        }
        else
        {
            Console.WriteLine("It's a tie!");
        }
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        Game game = new Game();
        game.Start();
    }
}
