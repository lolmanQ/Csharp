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
		public int health = 100;
		public int attack = 10;
		public static List<string> inventory = new List<string>();



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
			foreach (string a in inventory)
			{
				Console.WriteLine(a);
			}
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

		public void addToInv(string item)
		{
			inventory.Add(item);
			foreach (string a in inventory)
			{
				Console.WriteLine(a);
			}
		}
	}
}
