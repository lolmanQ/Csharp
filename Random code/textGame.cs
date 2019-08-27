
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	class MainClass
	{
		character character = new character();
		actions actions = new actions();
		public int[,] gameArray2D = new int[5, 5] {
		{ 1, 1, 1, 1, 1 },
		{ 1, 0, 3, 0, 1 },
		{ 1, 0, 2, 0, 1 },
		{ 1, 0, 0, 0, 1 },
		{ 1, 1, 1, 1, 1 }
		};
		public bool exit = false;
		public int playerRow;
		public int playerColumn;


		public static void Main()
		{
			MainClass MainClass = new MainClass();
			MainClass.RenderWorld();
			SearchArray(2, MainClass.gameArray2D, out MainClass.playerRow, out MainClass.playerColumn);
			Console.WriteLine("Row: " + MainClass.playerRow + " Column:" + MainClass.playerColumn);
			MainClass.GameLoop();
		}

		public static bool SearchArray(int searchedNum, int[,] rArray, out int indexOfRow, out int indexOfColumn)
		{
			indexOfRow = -1;
			indexOfColumn = -1;


			for (int c = 0; c < rArray.GetLength(0); c++)
			{
				for (int r = 0; r < rArray.GetLength(1); r++)
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
				inputAction = inputMethod();
				if (inputAction != "exit")
				{
					DoAction(inputAction);
				}
			}
		}

		public void outputText()
		{
			Console.WriteLine(gameArray2D[1, 2]);
		}

		public string inputMethod()
		{
			bool Valid = false;
			while (!Valid)
			{
				string lineInput = Console.ReadLine();
				lineInput = lineInput.ToLower();
				if (lineInput == "up")
				{
					Valid = true;
					return "up";
				}
				else if (lineInput == "down")
				{
					Valid = true;
					return "down";
				}
				else if (lineInput == "left")
				{
					Valid = true;
					return "left";
				}
				else if (lineInput == "right")
				{
					Valid = true;
					return "right";
				}
				else if (lineInput == "stats")
				{
					Valid = true;
					return "stats";
				}
				else if (lineInput == "inv")
				{
					Valid = true;
					return "inv";
				}
				else if (lineInput == "exit")
				{
					Valid = true;
					exit = true;
					return "exit";
				}
				else
				{
					Console.WriteLine("Invalid retry");
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
			if (MakeAction(gameArray2D[playerRow - 1, playerColumn], playerRow - 1, playerColumn))
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
			if (MakeAction(gameArray2D[playerRow + 1, playerColumn], playerRow + 1, playerColumn))
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
			if (MakeAction(gameArray2D[playerRow, playerColumn - 1], playerRow, playerColumn - 1))
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
			if (MakeAction(gameArray2D[playerRow, playerColumn + 1], playerRow, playerColumn + 1))
			{
				gameArray2D[playerRow, playerColumn + 1] = 2;
				gameArray2D[playerRow, playerColumn] = 0;
			}
			else
			{
				Console.WriteLine("Something is in the way");
			}
		}

		public bool MakeAction(int obj, int objRow, int objColumn)
		{
			switch (obj)
			{
				case 0:
					return true;
				case 1:
					return false;
				case 3:
					actions.OpenChest(objRow, objColumn);
					return true;
			}
			return false;
		}

		public void FindPlayer()
		{
			SearchArray(2, gameArray2D, out playerRow, out playerColumn);
		}

		public void RenderWorld()
		{
			Console.WriteLine("------");
			string bufferText = "";
			for (int r = 0; r < gameArray2D.GetLength(1); r++)
			{
				for (int c = 0; c < gameArray2D.GetLength(0); c++)
				{
					if (c == 0)
					{
						switch (gameArray2D[r, c])
						{
							case 0:
								bufferText = " ";
								break;
							case 1:
								bufferText = "#";
								break;
							case 2:
								bufferText = "M";
								break;
							case 3:
								bufferText = "c";
								break;
						}
					}
					else
					{
						switch (gameArray2D[r, c])
						{
							case 0:
								bufferText += " ";
								break;
							case 1:
								bufferText += "#";
								break;
							case 2:
								bufferText += "M";
								break;
							case 3:
								bufferText += "c";
								break;
						}
					}
					bufferText += " ";
					if (c == gameArray2D.GetLength(0) - 1)
					{
						Console.WriteLine(bufferText);
					}
				}
			}
			Console.WriteLine("-----");
		}
	}

	class character
	{
		register register = new register();
		public int health = 100;
		public int attack = 10;
		public string[] inventory = new string[]{};
		


		public void statReset()
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
			foreach(string ItemId in inventory){
				if(DisplayBufferInventory == ""){
					DisplayBufferInventory = register.GetName(ItemId);
				}
				else{
					DisplayBufferInventory += " ," + register.GetName(ItemId);
				}
			}
			
			Console.WriteLine("Your inventory contains: " + DisplayBufferInventory);
		}

		public void addToInv(string item){
			if(inventory.GetLength(0) == 0){
				inventory[0] = item;
			}
			else{
				inventory[inventory.GetLength(0)] = item;
			}
		}
	}

	class actions
	{
        register register = new register();
        character character = new character();
		public void OpenChest(int Row, int Column)
		{
            string Itemid = register.GetId(FindChestItem(Row, Column));
            character.addToInv(Itemid);
						Console.WriteLine("You found: " + register.GetName(Itemid));
		}
        public string FindChestItem(int Row, int Column){
            string ChestPos = Row +", "+ Column;
            for(int i = 0;i<register.chestMemory.GetLength(0);i++){
                if(ChestPos == register.chestMemory[i, 0]){
                    return register.chestMemory[i, 1];
                }
            }
					return "error";
        }
	}

	class register
	{
		public string[,] chestMemory = new string[,]
		{
			{"1, 2", "Sword"}
		};

		public string[,] IdList = new string[,]
		{
			{"0000", "error"},
			{"0001", "Sword" },
			{"0002", "Backpack" }
		};

        public string GetId(string name){
           for(int i = 0;i<IdList.GetLength(0);i++){
                if(name == IdList[i, 1]){
                    return IdList[i, 0];
                }
            }
					return "0000";
        }

		public string GetName(string Id){
        for(int i = 0;i<IdList.GetLength(0);i++){
          if(Id == IdList[i, 0]){
            return IdList[i, 1];
  	        }
          }
				Console.WriteLine("id" + Id);
				return "error";
    }
	}
