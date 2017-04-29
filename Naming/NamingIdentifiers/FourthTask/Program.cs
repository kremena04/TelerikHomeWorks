using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThirdTask;

namespace mini4ki
{
    public class minite
    {
        static void Main()
        {
            string command = string.Empty;
            char[,] field = CreatePlayField();
            char[,] bombs = SetBombs();
            int bombsHitted = 0;
            bool hasPlayerDied = false;
            List<Score> champions = new List<Score>(6);
            int currentRow = 0;
            int currentCol = 0;
            bool startNewGame = true;
            const int maxBombsHitted = 35;
            bool hasPlayerWon = false;

            do
            {
                if (startNewGame)
                {
                    Console.WriteLine("Hajde da igraem na “Mini4KI”. Probvaj si kasmeta da otkriesh poleteta bez mini4ki." +
                    " Komanda 'top' pokazva klasiraneto, 'restart' po4va nova igra, 'exit' izliza i hajde 4ao!");
                    PrintField(field);
                    startNewGame = false;
                }
                Console.Write("Daj red i kolona : ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out currentRow) &&
                    int.TryParse(command[2].ToString(), out currentCol) &&
                        currentRow <= field.GetLength(0) && currentCol <= field.GetLength(1))
                    {
                        command = "turn";
                    }
                }
                switch (command)
                {
                    case "top":
                        GetRaiting(champions);
                        break;
                    case "restart":
                        field = CreatePlayField();
                        bombs = SetBombs();
                        PrintField(field);
                        hasPlayerDied = false;
                        startNewGame = false;
                        break;
                    case "exit":
                        Console.WriteLine("Bye, Bye, Bye!");
                        break;
                    case "turn":
                        if (bombs[currentRow, currentCol] != '*')
                        {
                            if (bombs[currentRow, currentCol] == '-')
                            {
                                NewMove(field, bombs, currentRow, currentCol);
                                bombsHitted++;
                            }
                            if (maxBombsHitted == bombsHitted)
                            {
                                hasPlayerWon = true;
                            }
                            else
                            {
                                PrintField(field);
                            }
                        }
                        else
                        {
                            hasPlayerDied = true;
                        }
                        break;
                    default:
                        Console.WriteLine("\nGreshka! nevalidna Komanda\n");
                        break;
                }
                if (hasPlayerDied)
                {
                    PrintField(bombs);
                    Console.Write("\nHrrrrrr! Umria gerojski s {0} to4ki. " +
                        "Daj si niknejm: ", bombsHitted);
                    string nickname = Console.ReadLine();
                    Score t = new Score(nickname, bombsHitted);
                    if (champions.Count < 5)
                    {
                        champions.Add(t);
                    }
                    else
                    {
                        for (int i = 0; i < champions.Count; i++)
                        {
                            if (champions[i].Points < t.Points)
                            {
                                champions.Insert(i, t);
                                champions.RemoveAt(champions.Count - 1);
                                break;
                            }
                        }
                    }
                    champions.Sort((Score r1, Score r2) => r2.Name.CompareTo(r1.Name));
                    champions.Sort((Score r1, Score r2) => r2.Points.CompareTo(r1.Points));
                    GetRaiting(champions);

                    field = CreatePlayField();
                    bombs = SetBombs();
                    bombsHitted = 0;
                    hasPlayerDied = false;
                    startNewGame = true;
                }
                if (hasPlayerWon)
                {
                    Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
                    PrintField(bombs);
                    Console.WriteLine("Daj si imeto, batka: ");
                    string playerName = Console.ReadLine();
                    Score playerScore = new Score(playerName, bombsHitted);
                    champions.Add(playerScore);
                    GetRaiting(champions);
                    field = CreatePlayField();
                    bombs = SetBombs();
                    bombsHitted = 0;
                    hasPlayerWon = false;
                    startNewGame = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("AREEEEEEeeeeeee.");
            Console.Read();
        }

        private static void GetRaiting(List<Score> points)
        {
            Console.WriteLine("\nTo4KI:");
            if (points.Count > 0)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} kutii",
                        i + 1, points[i].Name, points[i].Points);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("prazna klasaciq!\n");
            }
        }

        private static void NewMove(char[,] field,
            char[,] bombs, int row, int col)
        {
            char bombsCount = CountBombsAroundPosition(bombs, row, col);
            bombs[row, col] = bombsCount;
            field[row, col] = bombsCount;
        }

        private static void PrintField(char[,] board)
        {
            int boardRows = board.GetLength(0);
            int boardColumns = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int currentRow = 0; currentRow < boardRows; currentRow++)
            {
                Console.Write("{0} | ", currentRow);
                for (int currentCol = 0; currentCol < boardColumns; currentCol++)
                {
                    Console.Write(string.Format("{0} ", board[currentRow, currentCol]));
                }
                Console.Write("|");
                Console.WriteLine();
            }
            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreatePlayField()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int currentRow = 0; currentRow < boardRows; currentRow++)
            {
                for (int currentCol = 0; currentCol < boardColumns; currentCol++)
                {
                    board[currentRow, currentCol] = '?';
                }
            }

            return board;
        }

        private static char[,] SetBombs()
        {
            int fieldRows = 5;
            int fieldCols = 10;
            char[,] playField = new char[fieldRows, fieldCols];

            for (int currentRow = 0; currentRow < fieldRows; currentRow++)
            {
                for (int currentCol = 0; currentCol < fieldCols; currentCol++)
                {
                    playField[currentRow, currentCol] = '-';
                }
            }

            List<int> bombs = new List<int>();
            while (bombs.Count < 15)
            {
                Random random = new Random();
                int newBomb = random.Next(50);
                if (!bombs.Contains(newBomb))
                {
                    bombs.Add(newBomb);
                }
            }

            foreach (int bomb in bombs)
            {
                int col = (bomb / fieldCols);
                int row = (bomb % fieldCols);
                if (row == 0 && bomb != 0)
                {
                    col--;
                    row = fieldCols;
                }
                else
                {
                    row++;
                }
                playField[col, row - 1] = '*';
            }

            return playField;
        }

        private static void CalculateNearBombsCounts(char[,] field)
        {
            int cols = field.GetLength(0);
            int rows = field.GetLength(1);

            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if (field[i, j] != '*')
                    {
                        char bombsCount = CountBombsAroundPosition(field, i, j);
                        field[i, j] = bombsCount;
                    }
                }
            }
        }

        private static char CountBombsAroundPosition(char[,] board, int currentRow, int currentCol)
        {
            int count = 0;
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);

            if (currentRow - 1 >= 0)
            {
                if (board[currentRow - 1, currentCol] == '*')
                {
                    count++;
                }
            }
            if (currentRow + 1 < rows)
            {
                if (board[currentRow + 1, currentCol] == '*')
                {
                    count++;
                }
            }
            if (currentCol - 1 >= 0)
            {
                if (board[currentRow, currentCol - 1] == '*')
                {
                    count++;
                }
            }
            if (currentCol + 1 < cols)
            {
                if (board[currentRow, currentCol + 1] == '*')
                {
                    count++;
                }
            }
            if ((currentRow - 1 >= 0) && (currentCol - 1 >= 0))
            {
                if (board[currentRow - 1, currentCol - 1] == '*')
                {
                    count++;
                }
            }
            if ((currentRow - 1 >= 0) && (currentCol + 1 < cols))
            {
                if (board[currentRow - 1, currentCol + 1] == '*')
                {
                    count++;
                }
            }
            if ((currentRow + 1 < rows) && (currentCol - 1 >= 0))
            {
                if (board[currentRow + 1, currentCol - 1] == '*')
                {
                    count++;
                }
            }
            if ((currentRow + 1 < rows) && (currentCol + 1 < cols))
            {
                if (board[currentRow + 1, currentCol + 1] == '*')
                {
                    count++;
                }
            }

            return char.Parse(count.ToString());
        }
    }
}
