using System;

class MainClass {
	inventory inv = new inventory();
	public int[,] gameArray2D = new int[5,5] {
		{ 1, 1, 1, 1, 1 },
		{ 1, 0, 3, 0, 1 },
		{ 1, 0, 2, 0, 1 },
		{ 1, 0, 0, 0, 1 },
		{ 1, 1, 1, 1, 1 }
	};
	public bool exit = false;
	public int playerRow;
	public int playerColumn;

  public static void Main() {
		MainClass MainClass = new MainClass();
		MainClass.RenderWorld();
		SearchArray(2, MainClass.gameArray2D, out MainClass.playerRow, out MainClass.playerColumn);
		Console.WriteLine("Row: "+MainClass.playerRow+" Column:"+MainClass.playerColumn);
    MainClass.GameLoop();
  }

	public static bool SearchArray(int searchedNum, int [,] rArray, out int indexOfRow, out int indexOfColumn)
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
  
  public void GameLoop() {
  	string inputAction;
  	while(!exit){
  		inputAction = inputMethod();
  		if(inputAction != "exit"){
  			DoAction(inputAction);
  		}
  	}
  }

	public void outputText() {
		Console.WriteLine(gameArray2D[1, 2]);
	}

	public string inputMethod() {
		bool Valid = false;
		while (!Valid) {
			string lineInput = Console.ReadLine();
			lineInput = lineInput.ToLower();
			if(lineInput == "up"){
				Valid = true;
				return "up";
			}
			else if(lineInput == "down"){
				Valid = true;
				return "down";
			}
			else if(lineInput == "left"){
				Valid = true;
				return "left";
			}
			else if(lineInput == "right"){
				Valid = true;
				return "right";
			}
			else if(lineInput == "exit"){
				Valid = true;
				exit = true;
				return "exit";
			}
			else{
				Console.WriteLine("Invalid retry");
			}
		}
		return "exit";
	}
	
	public void DoAction(string inputAction){
		if(inputAction == "up"){
			DoUp();
		}
		else if(inputAction == "down"){
			DoDown();
		}
		else if(inputAction == "left"){
			DoLeft();
		}
		else if(inputAction == "right"){
			DoRight();
		}
		RenderWorld();
	}

	public void DoUp() {
		FindPlayer();
		if(gameArray2D[playerRow - 1, playerColumn] == 0){
			gameArray2D[playerRow - 1, playerColumn] = 2;
			gameArray2D[playerRow, playerColumn] = 0;
		}
		else{
			Console.WriteLine("Something is in the way");
		}
	}

	public void DoDown() {
		FindPlayer();
		if(gameArray2D[playerRow + 1, playerColumn] == 0){
			gameArray2D[playerRow + 1, playerColumn] = 2;
			gameArray2D[playerRow, playerColumn] = 0;
		}
		else{
			Console.WriteLine("Something is in the way");
		}
	}

	public void DoLeft() {
		FindPlayer();
		if(gameArray2D[playerRow, playerColumn - 1] == 0){
			gameArray2D[playerRow, playerColumn - 1] = 2;
			gameArray2D[playerRow, playerColumn] = 0;
		}
		else{
			Console.WriteLine("Something is in the way");
		}
	}

	public void DoRight() {
		FindPlayer();
		if(gameArray2D[playerRow, playerColumn + 1] == 0){
			gameArray2D[playerRow, playerColumn + 1] = 2;
			gameArray2D[playerRow, playerColumn] = 0;
		}
		else{
			Console.WriteLine("Something is in the way");
		}
	}

	public void FindPlayer(){
		SearchArray(2, gameArray2D, out playerRow, out playerColumn);
	}

	public void RenderWorld() {
		Console.WriteLine("―――――");
		string bufferText = "";
		for(int r = 0; r < gameArray2D.GetLength(1); r++){
			for(int c = 0; c < gameArray2D.GetLength(0); c++){
				if(c == 0){
					switch(gameArray2D[r, c])
					{
						case 0:
							bufferText = " ";
							break;
						case 1:
							bufferText = "☐";
						case 2:
							bufferText = "웃";
						case 3:
							bufferText = "⊡";
					}
				}
				else{
					bufferText += gameArray2D[r, c].ToString();
				}
				if(c == gameArray2D.GetLength(0)-1){
					Console.WriteLine(bufferText);
				}
			}
		}
		Console.WriteLine("――――――");
	}
}

class inventory{
	public int health;

	public void statReset() {
		health = 100;
	}
}