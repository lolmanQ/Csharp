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

		public bool MakeAction(int obj, int objRow, int objColumn, string World)
		{
			switch (obj)
			{
				case 0:
					return true;
				case 1:
					return false;
				case 3:
					OpenChest(World, objRow, objColumn);
					return true;
				case 4:
					return AttackEnemy();
				case 9:
					return false;
			}
			return false;
		}

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
}
