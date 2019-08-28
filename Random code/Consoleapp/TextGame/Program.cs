using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame
{

	class MainClass
	{
		public static void Main()
		{
			TextGameCode textGameCode = new TextGameCode();
			textGameCode.RenderWorld();
			textGameCode.SearchArray(2, textGameCode.gameArray2D, out textGameCode.playerRow, out textGameCode.playerColumn);
			Console.WriteLine("Row: " + textGameCode.playerRow + " Column:" + textGameCode.playerColumn);
			textGameCode.GameLoop();
		}
	}
}
