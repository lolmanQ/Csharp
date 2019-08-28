using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame
{
	class Register
	{
		public string[,] chestMemory = new string[,]
		{
			{"1, 2", "Sword"},
			{"4, 5", "Backpack"}
		};

		public string[,] IdList = new string[,]
		{
			{"0000", "error"},
			{"0001", "Sword" },
			{"0002", "Backpack" }
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
}
