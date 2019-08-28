using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame
{
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
}
