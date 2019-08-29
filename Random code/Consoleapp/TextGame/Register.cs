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
			{"W1", "1, 2", "Sword"},
			{"W1", "4, 5", "Backpack"}
		};
		public string[,] doorMemory = new string[,]
		{
			{"W1", "3, 7", "0001D", "0002D", "3, 6"},
			{"W2", "3, 0", "0002D", "0001D", "3, 1"}
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
}
