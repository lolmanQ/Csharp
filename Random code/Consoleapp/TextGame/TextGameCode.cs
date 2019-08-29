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
		World world = new World();
		Register register = new Register();
		public int[,] gameArray2D = new int[,]{};
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
			currentWorld = world.CurrentMap;
			gameArray2D = world.Map;
			RenderWorld();
			string inputAction;
			while (!exit)
			{
				inputAction = InputMethod();
				if (inputAction != "exit")
				{
					gameArray2D = world.Map;
					DoAction(inputAction);
					world.UpdateMap(gameArray2D);
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
					case "die":
						return "exit";
					case "w1":
						return "w1";
					case "w2":
						return "w2";
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
			else if (inputAction == "w1")
			{
				world.SetMap("W1");
				gameArray2D = world.Map;
				RenderWorld();
			}
			else if (inputAction == "w2")
			{
				world.SetMap("W2");
				gameArray2D = world.Map;
				RenderWorld();
			}
			else
			{
				RenderWorld();
			}
		}

		public bool MakeAction(int obj, int objRow, int objColumn, string CurrentMap)
		{
			switch (obj)
			{
				case 0:
					return true;
				case 1:
					Console.WriteLine("A wall is in the way");
					return false;
				case 3:
					gameActions.OpenChest(CurrentMap, objRow, objColumn);
					return true;
				case 4:
					return gameActions.AttackEnemy();
				case 9:
					OpenDoor(CurrentMap, objRow, objColumn);
					return false;
			}
			return false;
		}

		public void DoUp()
		{
			FindPlayer();
			if (MakeAction(gameArray2D[playerRow - 1, playerColumn], playerRow - 1, playerColumn, currentWorld))
			{
				gameArray2D[playerRow - 1, playerColumn] = 2;
				gameArray2D[playerRow, playerColumn] = 0;
			}
		}

		public void DoDown()
		{
			FindPlayer();
			if (MakeAction(gameArray2D[playerRow + 1, playerColumn], playerRow + 1, playerColumn, currentWorld))
			{
				gameArray2D[playerRow + 1, playerColumn] = 2;
				gameArray2D[playerRow, playerColumn] = 0;
			}
		}

		public void DoLeft()
		{
			FindPlayer();
			if (MakeAction(gameArray2D[playerRow, playerColumn - 1], playerRow, playerColumn - 1, currentWorld))
			{
				gameArray2D[playerRow, playerColumn - 1] = 2;
				gameArray2D[playerRow, playerColumn] = 0;
			}
		}

		public void DoRight()
		{
			FindPlayer();
			if (MakeAction(gameArray2D[playerRow, playerColumn + 1], playerRow, playerColumn + 1, currentWorld))
			{
				gameArray2D[playerRow, playerColumn + 1] = 2;
				gameArray2D[playerRow, playerColumn] = 0;
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

		public void OpenDoor(string CurrentMap, int DoorRow, int DoorColumn)
		{
			FindDoorPos(CurrentMap, DoorRow, DoorColumn, out string DoorWantToBeOpen, out string DoorWantToComeOut);
			FindDoorID(DoorWantToComeOut, "World", "Player", out string ChangeToMap, out int PointPosRow, out int PointPosColumn);
			world.SetMap(ChangeToMap);
			gameArray2D = world.Map;
			currentWorld = ChangeToMap;
			FindPlayer();
			gameArray2D[playerRow, playerColumn] = 0;
			gameArray2D[PointPosRow, PointPosColumn] = 2;
			
		}

		public void FindDoorPos(string CurrentMap, int DoorRow, int DoorColumn, out string DoorCurrent, out string DoorPoint)
		{
			DoorCurrent = "";
			DoorPoint = "";
			string DoorPos = DoorRow + ", " + DoorColumn;
			for (int i = 0; i < register.doorMemory.GetLength(0); i++)
			{
				if (DoorPos == register.doorMemory[i, 1] && CurrentMap == register.doorMemory[i, 0])
				{
					DoorCurrent = register.doorMemory[i, 2];
					DoorPoint = register.doorMemory[i, 3];
				}
			}
		}

		public void FindDoorID(string DoorID, string WantToGetVar, string WantToGetPos, out string output, out int outputRow, out int outputColumn)
		{
			output = "";
			outputRow = 0;
			outputColumn = 0;
			for (int i = 0; i < register.doorMemory.GetLength(0); i++)
			{
				if (DoorID == register.doorMemory[i, 2])
				{
					string[] CharacterPos = register.doorMemory[i, 4].Split(new Char[] { ',', ' '}, StringSplitOptions.RemoveEmptyEntries);
					string[] DoorPos = register.doorMemory[i, 1].Split(new Char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
					switch (WantToGetPos)
					{
						case "Door":
							outputRow = int.Parse(DoorPos[0]);
							outputColumn = int.Parse(DoorPos[1]);
							break;
						case "Player":
							outputRow = int.Parse(CharacterPos[0]);
							outputColumn = int.Parse(CharacterPos[1]);
							break;
					}

					switch (WantToGetVar)
					{
						case "World":
							output = register.doorMemory[i, 0];
							break;
						case "ID":
							output = register.doorMemory[i, 2];
							break;
						case "Point":
							output = register.doorMemory[i, 3];
							break;
					}
				}
			}
		}
	}
}
