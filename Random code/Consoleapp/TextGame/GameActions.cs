using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame
{
	class GameActions
	{
		Register register = new Register();
		Character character = new Character();

		public bool MakeAction(int obj, int objRow, int objColumn)
		{
			switch (obj)
			{
				case 0:
					return true;
				case 1:
					return false;
				case 3:
					OpenChest(objRow, objColumn);
					return true;
				case 4:
					return false;
				case 9:
					return false;
			}
			return false;
		}

		public void OpenChest(int Row, int Column)
		{
			string Itemid = register.GetId(FindChestItem(Row, Column));
			character.addToInv(Itemid);
			Console.WriteLine("You found: " + register.GetName(Itemid));
		}

		public string FindChestItem(int Row, int Column)
		{
			string ChestPos = Row + ", " + Column;
			for (int i = 0; i < register.chestMemory.GetLength(0); i++)
			{
				if (ChestPos == register.chestMemory[i, 0])
				{
					return register.chestMemory[i, 1];
				}
			}
			return "error";
		}
	}
}
