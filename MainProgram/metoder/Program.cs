using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metoder
{
	class Program
	{
		static void Main(string[] args)
		{
			if(ReturnInputToInt(out int number))
			{
				Console.WriteLine(number);
			}
			else
			{
				Console.WriteLine("not a int");
			}

		}

		static bool ReturnInputToInt(out int outInt)
		{
			string stringInput = Console.ReadLine();
			if (int.TryParse(stringInput, out outInt))
			{
				return true;
			}
			else
			{
				outInt = 0;
				return false;
			}
		}
	}
}
