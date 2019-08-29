using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


	class MainClass
	{
		public static void Main()
		{
			TextGameCode textGameCode = new TextGameCode();
			textGameCode.GameLoop();
		}
	}

	class TextGameCode
	{
		Character character = new Character();
		GameActions gameActions = new GameActions();
		World world = new World();
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

		public bool MakeAction(int obj, int objRow, int objColumn, string World)
		{
			switch (obj)
			{
				case 0:
					return true;
				case 1:
					return false;
				case 3:
					gameActions.OpenChest(World, objRow, objColumn);
					return true;
				case 4:
					return gameActions.AttackEnemy();
				case 9:

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
			else
			{
				Console.WriteLine("Something is in the way");
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
			else
			{
				Console.WriteLine("Something is in the way");
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
			else
			{
				Console.WriteLine("Something is in the way");
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

		public void OpenDoor()
		{

		}

		public void FindDoor()
	{

	}
}

	class Character
	{
		Register register = new Register();
		public static int health = 100;
		public static int attack = 10;
		public static List<string> inventory = new List<string>();



		public void StatReset()
		{
			health = 100;
			attack = 10;
		}

		public void DisplayStats()
		{
			Console.WriteLine("Health: " + health);
			Console.WriteLine("atk: " + attack);
		}

		public void DisplayInventory()
		{
			string DisplayBufferInventory = "";
			foreach (string ItemId in inventory)
			{
				if (DisplayBufferInventory == "")
				{
					DisplayBufferInventory = register.GetName(ItemId);
				}
				else
				{
					DisplayBufferInventory += ", " + register.GetName(ItemId);
				}
			}
			Console.WriteLine("Your inventory contains: " + DisplayBufferInventory);
		}

		public void AddToInv(string item)
		{
			inventory.Add(item);
		}

		public List<string> GetInventory()
		{
			return inventory;
		}

		public void ChangeStats(string Stat, int Amount)
		{
			switch (Stat)
			{
				case "hp":
					health = health + Amount;
					break;
				case "atk":
					attack = attack + Amount;
					break;
			}
		}
	}

	class GameActions
	{
		Register register = new Register();
		Character character = new Character();

		public void OpenChest(string World, int Row, int Column)
		{
			string Itemid = register.GetId(FindChestItem(World, Row, Column));
			character.AddToInv(Itemid);
			Console.WriteLine("You found: " + register.GetName(Itemid));
		}

		public string FindChestItem(string World, int Row, int Column)
		{
			string ChestPos = Row + ", " + Column;
			for (int i = 0; i < register.chestMemory.GetLength(1); i++)
			{
					if (ChestPos == register.chestMemory[i, 1] && World == register.chestMemory[i, 0])
				{
					return register.chestMemory[i, 2];
				}
			}
			return "error";
		}

		public bool AttackEnemy()
		{
			int ItemIndex = character.GetInventory().IndexOf("0001");
			if(ItemIndex >= 0)
			{
				string loot = "0003";
				character.AddToInv(loot);
				Console.WriteLine("The monster dropt: " + register.GetName(loot));
				return true;
			}
			else
			{
				character.ChangeStats("hp", -10);
				Console.WriteLine("You took 10 damage, you have nothing to fight with!");
				return false;
			}
		}


	}

	class Register
	{
		public string[,] chestMemory = new string[,]
		{
			{"W1", "1, 2", "Sword"},
			{"W1", "4, 5", "Backpack"}
		};
		public string[,] doorMemory = new string[,]
		{
			{"W1", "3, 7", "W2"},
			{"W2", "0, 3", "W1"}
		};

		public string[,] IdList = new string[,]
		{
			{"0000", "error"},
			{"0001", "Sword" },
			{"0002", "Backpack" },
			{"0003", "Enemy flesh" }
		};

		public string GetId(string name)
		{
			for (int i = 0; i < IdList.GetLength(0); i++)
			{
				if (name == IdList[i, 1])
				{
					return IdList[i, 0];
				}
			}
			return "0000";
		}

		public string GetName(string Id)
		{
			for (int i = 0; i < IdList.GetLength(0); i++)
			{
				if (Id == IdList[i, 0])
				{
					return IdList[i, 1];
				}
			}
			Console.WriteLine("id" + Id);
			return "error";
		}
	}

	class World
	{
		public string CurrentMap = "W1";
		public int[,] Map = new int[,] {
		{ 1, 1, 1, 1, 1, 1, 1, 0 },
		{ 1, 0, 3, 0, 0, 0, 1, 0 },
		{ 1, 0, 0, 0, 0, 0, 1, 1 },
		{ 1, 0, 0, 2, 0, 0, 0, 9 },
		{ 1, 4, 0, 0, 0, 3, 1, 1 },
		{ 1, 1, 1, 1, 1, 1, 1, 0 }
		};

		public int[,] W1 = new int[,] {
		{ 1, 1, 1, 1, 1, 1, 1, 0 },
		{ 1, 0, 3, 0, 0, 0, 1, 0 },
		{ 1, 0, 0, 0, 0, 0, 1, 1 },
		{ 1, 0, 0, 2, 0, 0, 0, 9 },
		{ 1, 4, 0, 0, 0, 3, 1, 1 },
		{ 1, 1, 1, 1, 1, 1, 1, 0 }
		};

		public int[,] W2 = new int[,] {
		{ 0, 1, 1, 1, 1, 1, 1 },
		{ 0, 1, 3, 0, 0, 0, 1 },
		{ 1, 1, 0, 0, 0, 0, 1 },
		{ 9, 0, 0, 2, 0, 0, 1 },
		{ 1, 1, 0, 0, 0, 4, 1 },
		{ 0, 1, 1, 1, 1, 1, 1 }
		};


		public void UpdateMap(int[,] NewMap)
		{
			Map = NewMap;
		}

		public void SetMap(string MapName)
		{
			switch (CurrentMap)
			{
				case "W1":
					W1 = Map;
					break;
				case "W2":
					W2 = Map;
					break;
			}
			switch (MapName)
			{
				case "W1":
					Map = W1;
					CurrentMap = "W1";
					break;
				case "W2":
					Map = W2;
					CurrentMap = "W2";
					break;
			}
		}
	}
