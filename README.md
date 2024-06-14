# ASSIGNMENT_2
 Overview
This is a simple console-based game written in C#. The game is played on a 6x6 grid where two players, P1 and P2, take turns moving around the board, collecting gems (G) and avoiding obstacles (O). The game ends after 30 turns, and the player with the most gems wins.
Represents a player with a name, position, and gem count. The player can move in four directions: up (U), down (D), left (L), and right (R).
Represents a cell on the board, which can be empty ("-"), contain an obstacle ("O"), or contain a gem ("G").
Represents the game board, a 6x6 grid with methods to place obstacles and gems randomly, display the board, check if a move is valid, and collect gems.
Manages the overall game, including turn-taking, checking game-over conditions, and announcing the winner.
How to Run
Clone the repository or download the code.

Open the project in your preferred C# development environment (e.g., Visual Studio).

Build the project to ensure all dependencies are correctly set up.

Run the Program class to start the game.

Follow the on-screen instructions to move the players around the board using the keys:

U for up
D for down
L for left
R for right
The game will end after 30 turns. The player with the most gems collected will be declared the winner. If both players collect the same number of gems, it will be a tie.

Notes
The board is initialized with 5 obstacles and 5 gems placed randomly.
Players start at opposite corners of the board.
Players take turns to move, and they cannot move into cells occupied by obstacles.
If a player moves onto a cell with a gem, they collect it and the gem is removed from the board.
The game ends after 30 turns.
Enjoy the game!
