using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace power_and_switch
{
	class Program
	{
		static void Main(string[] args)
		{
			int a = 5, b = 10;
			SwitchVar(ref a, ref b);
			Console.WriteLine(a + " " + b);
			Console.WriteLine(Power(2, 3));
		}

		static void SwitchVar(ref int var1,ref int var2)
		{
			int to2 = var1;
			int to1 = var2;
			var1 = to1;
			var2 = to2;
		}

		static int Power(int baseNumb, int exponentNumb)
		{
			int baseKeep = baseNumb;
			for(int i = 1; i < exponentNumb; i++)
			{
				baseKeep *= baseNumb;
			}
			return baseKeep;
		}
	}
}
