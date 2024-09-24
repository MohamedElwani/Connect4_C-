using System;

namespace Connect__4
{
	internal class Program
	{
		static char[,] Connects = new char[8, 8];
		static char player = 'X';
		static bool[] Taken_columns = new bool[8];
		static int counter = 0;

		static void Main(string[] args)
		{
			short? playing = 1, choice = 0, more;

			do
			{
				Console.BackgroundColor = ConsoleColor.Yellow;
				Console.ForegroundColor = ConsoleColor.Black;
				Console.WriteLine("//////////////////////////HELLO//////////////////////////");
				Console.WriteLine("what type of games are you looking for :)                ");
				Console.WriteLine("//////////////////////////HELLO//////////////////////////");
				Console.BackgroundColor = ConsoleColor.Black;
				Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine("1- player vs player");
				Console.WriteLine("2- player vs AI");
				Console.WriteLine("3- Exit");

				while (choice < 1 || choice > 3)
				{
					Console.Write("Your Answer ========>>>> ");
					choice = short.Parse(Console.ReadLine());
				}

				if (choice == 3) return;

				InitializeBoard();
				if (choice == 1)
				{
					while (Winner() == 'C')
					{
						Console.Clear();
						display();
						Play_two_Players();
					}
				}
				else if (choice == 2)
				{
					while (Winner() == 'C')
					{
						Console.Clear();
						display();
						Play_vs_AI();
					}
				}
				Console.Clear();
				display();
				switch (Winner())
				{
					case 'X':
						Console.WriteLine("Player X Wins :)");
						break;
					case 'O':
						Console.WriteLine("Player O Wins :)");
						break;
					case 'D':
						Console.WriteLine("It's a Draw :(");
						break;
				}
				Console.Write("Do you want to Play again ? \n 1-Yes,Please \n 2-No,thanks\nAnswer=====>>> ");
				more = short.Parse(Console.ReadLine());
				while (more < 1 || more > 2)
				{
					Console.Clear();
					Console.WriteLine("Invalid choice :( press [1,2] \n 1-Yes,Please \n 2-No,thanks\nAnswer=====>>> ");
					more = short.Parse(Console.ReadLine());
				}
				Console.Clear();
			} while (more == 1);
			Console.Clear();
			Console.WriteLine("//////////////////////////BBBYEEEEE//////////////////////////");
			Console.WriteLine("Thanks for playing our Game :)");
			Console.WriteLine("//////////////////////////BBBYEEEEE//////////////////////////");
		}

		static void InitializeBoard()
		{
			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					Connects[i, j] = ' ';
				}
			}
		}

		static void display()
		{
			Console.WriteLine("");
			Console.WriteLine("");
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Columns : ");
			for (int i = 0; i < 8; i++)
			{
				Console.Write($"-- {i + 1} --");
			}
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("");
			for (int i = 0; i < 8; i++)
			{
				Console.Write("-------");
			}
			Console.WriteLine("");

			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					if (Connects[i, j] == 'X')
					{
						Console.ForegroundColor = ConsoleColor.Red;
					}
					else if (Connects[i, j] == 'O')
					{
						Console.ForegroundColor = ConsoleColor.Blue;
					}
					else
					{
						Console.ForegroundColor = ConsoleColor.Yellow;
					}
					Console.Write($"|  {Connects[i, j]}  |");
				}
				Console.WriteLine("");
			}

			for (int i = 0; i < 8; i++)
			{
				Console.Write("-------");
			}
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("");
		}

		static void Play_two_Players()
		{
			Console.WriteLine($"Select Column to play in turn of Player {player}");
			int playing_place = int.Parse(Console.ReadLine()) - 1;

			bool all_fine = true;

			while (all_fine)
			{
				if (playing_place < 0 || playing_place > 7)
				{
					Console.WriteLine("Sorry, invalid choice. Please enter a number from 1 to 8 :)");
					playing_place = int.Parse(Console.ReadLine()) - 1;
				}
				else if (Taken_columns[playing_place])
				{
					Console.WriteLine("Sorry, this column is full. Try another column :)");
					playing_place = int.Parse(Console.ReadLine()) - 1;
				}
				else
				{
					break;
				}
			}

			for (int i = 7; i >= 0; i--)
			{
				if (Connects[i, playing_place] == ' ')
				{
					Connects[i, playing_place] = player;
					if (i == 0)
					{
						Taken_columns[playing_place] = true;
					}
					break;
				}
			}

			if (player == 'X')
			{
				player = 'O';
			}
			else
			{
				player = 'X';
			}
			++counter;
		}

		static char Winner()
		{
			for (int i = 0; i <= 7; i++)//rows
			{
				for (int j = 0; j <= 4; j++)
				{
					if (Connects[i, j] == Connects[i, j + 1] &&
						Connects[i, j + 1] == Connects[i, j + 2] &&
						Connects[i, j + 2] == Connects[i, j + 3] &&
						Connects[i, j] != ' ')
					{
						return Connects[i, j];
					}
				}
			}

			for (int i = 0; i <= 4; i++)//columns
			{
				for (int j = 0; j <= 7; j++)
				{
					if (Connects[i, j] == Connects[i + 1, j] &&
						Connects[i + 1, j] == Connects[i + 2, j] &&
						Connects[i + 2, j] == Connects[i + 3, j] &&
						Connects[i, j] != ' ')
					{
						return Connects[i, j];
					}
				}
			}

			for (int i = 0; i <= 4; i++)// Main Diagonal
			{
				for (int j = 0; j <= 4; j++)
				{
					if (Connects[i, j] == Connects[i + 1, j + 1] &&
						Connects[i + 1, j + 1] == Connects[i + 2, j + 2] &&
						Connects[i + 2, j + 2] == Connects[i + 3, j + 3] &&
						Connects[i, j] != ' ')
					{
						return Connects[i, j];
					}
				}
			}

			for (int i = 0; i <= 4; i++)// Secondry Diagonal
			{
				for (int j = 3; j <= 7; j++)
				{
					if (Connects[i, j] == Connects[i + 1, j - 1] &&
						Connects[i + 1, j - 1] == Connects[i + 2, j - 2] &&
						Connects[i + 2, j - 2] == Connects[i + 3, j - 3] &&
						Connects[i, j] != ' ')
					{
						return Connects[i, j];
					}
				}
			}

			if (counter == 64)
				return 'D';
			else
				return 'C';
		}

		static void Play_vs_AI()
		{
			if (player == 'X')
			{
				Play_two_Players();
			}
			else
			{
				int bestMove = AI_Play();
				for (int i = 7; i >= 0; i--)
				{
					if (Connects[i, bestMove] == ' ')
					{
						Connects[i, bestMove] = player;
						if (i == 0)
						{
							Taken_columns[bestMove] = true;
						}
						break;
					}
				}
				player = 'X';
				++counter;
			}
		}

		static int AI_Play()
		{
			Random random = new Random();
			int move = random.Next(0, 7);
			while (Taken_columns[move])
			{
				move = random.Next(0, 7);
			}
			return move;
		}
	}
}
