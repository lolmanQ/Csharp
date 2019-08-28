using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame
{
	class TextGameCode
	{
		Character character = new Character();
		GameActions gameActions = new GameActions();
		public int[,] gameArray2D = new int[6, 8] {
		{ 1, 1, 1, 1, 1, 1, 1, 0 },
		{ 1, 0, 3, 0, 0, 0, 1, 0 },
		{ 1, 0, 0, 0, 0, 0, 1, 1 },
		{ 1, 0, 0, 2, 0, 0, 0, 9 },
		{ 1, 4, 0, 0, 0, 3, 1, 1 },
		{ 1, 1, 1, 1, 1, 1, 1, 0 }
		};
		public string currentWorld = "W1";
		public bool exit = false;
		public int playerRow;
		public int playerColumn;

		public bool SearchArray(int searchedNum, int[,] rArray, out int indexOfRow, out int indexOfColumn)
		{
			indexOfRow = -1;
			indexOfColumn = -1;


			for (int c = 0; c < rArray.GetLength(1); c++)
			{
				for (int r = 0; r < rArray.GetLength(0); r++)
				{
					indexOfRow = r;
					indexOfColumn = c;

					if (rArray[r, c].Equals(searchedNum))
					{
						return true;
					}

				}

			}
			return false;

		}

		public void GameLoop()
		{
			string inputAction;
			while (!exit)
			{
				inputAction = InputMethod();
				if (inputAction != "exit")
				{
					DoAction(inputAction);
				}
			}
		}

		public string InputMethod()
		{
			bool Valid = false;
			while (!Valid)
			{
				string lineInput = Console.ReadLine();
				lineInput = lineInput.ToLower();
				switch (lineInput)
				{
					case "u":
					case "up":
						return "up";
					case "d":
					case "down":
						return "down";
					case "l":
					case "left":
						return "left";
					case "r":
					case "right":
						return "right";
					case "stats":
						return "stats";
					case "inv":
					case "inventory":
						return "inv";
					case "exit":
						return "exit";
					default:
						Console.WriteLine("Invalid retry");
						break;

				}
			}
			return "exit";
		}

		public void DoAction(string inputAction)
		{
			if (inputAction == "up")
			{
				DoUp();
			}
			else if (inputAction == "down")
			{
				DoDown();
			}
			else if (inputAction == "left")
			{
				DoLeft();
			}
			else if (inputAction == "right")
			{
				DoRight();
			}

			if (inputAction == "stats")
			{
				character.DisplayStats();
			}
			else if (inputAction == "inv")
			{
				character.DisplayInventory();
			}
			else
			{
				RenderWorld();
			}
		}

		public void DoUp()
		{
			FindPlayer();
			if (gameActions.MakeAction(gameArray2D[playerRow - 1, playerColumn], playerRow - 1, playerColumn, currentWorld))
			{
				gameArray2D[playerRow - 1, playerColumn] = 2;
				gameArray2D[playerRow, playerColumn] = 0;
			}
			else
			{
				Console.WriteLine("Something is in the way");
			}
		}

		public void DoDown()
		{
			FindPlayer();
			if (gameActions.MakeAction(gameArray2D[playerRow + 1, playerColumn], playerRow + 1, playerColumn, currentWorld))
			{
				gameArray2D[playerRow + 1, playerColumn] = 2;
				gameArray2D[playerRow, playerColumn] = 0;
			}
			else
			{
				Console.WriteLine("Something is in the way");
			}
		}

		public void DoLeft()
		{
			FindPlayer();
			if (gameActions.MakeAction(gameArray2D[playerRow, playerColumn - 1], playerRow, playerColumn - 1, currentWorld))
			{
				gameArray2D[playerRow, playerColumn - 1] = 2;
				gameArray2D[playerRow, playerColumn] = 0;
			}
			else
			{
				Console.WriteLine("Something is in the way");
			}
		}

		public void DoRight()
		{
			FindPlayer();
			if (gameActions.MakeAction(gameArray2D[playerRow, playerColumn + 1], playerRow, playerColumn + 1, currentWorld))
			{
				gameArray2D[playerRow, playerColumn + 1] = 2;
				gameArray2D[playerRow, playerColumn] = 0;
			}
			else
			{
				Console.WriteLine("Something is in the way");
			}
		}

		public void FindPlayer()
		{
			SearchArray(2, gameArray2D, out playerRow, out playerColumn);
		}


		public void RenderWorld()
		{
			string boxSpace = "";
			for (int i = 0; i < 2 * gameArray2D.GetLength(1); i++)
			{
				boxSpace += "-";
			}
			Console.WriteLine(boxSpace);
			string bufferText = "";

			string emptySpace = " ";
			string wall = "#";
			string player = "M";
			string chest = "c";
			string enemy = "E";
			string door = "D";
			for (int r = 0; r < gameArray2D.GetLength(0); r++)
			{
				for (int c = 0; c < gameArray2D.GetLength(1); c++)
				{
					if (c == 0)
					{
						switch (gameArray2D[r, c])
						{
							case 0:
								bufferText = emptySpace;
								break;
							case 1:
								bufferText = wall;
								break;
							case 2:
								bufferText = player;
								break;
							case 3:
								bufferText = chest;
								break;
							case 4:
								bufferText = enemy;
								break;
							case 9:
								bufferText = door;
								break;
						}
					}
					else
					{
						switch (gameArray2D[r, c])
						{
							case 0:
								bufferText += emptySpace;
								break;
							case 1:
								bufferText += wall;
								break;
							case 2:
								bufferText += player;
								break;
							case 3:
								bufferText += chest;
								break;
							case 4:
								bufferText += enemy;
								break;
							case 9:
								bufferText += door;
								break;
						}
					}
					bufferText += " ";
					if (c == gameArray2D.GetLength(1) - 1)
					{
						Console.WriteLine(bufferText);
					}
				}
			}
			Console.WriteLine(boxSpace);
		}
	}
}
