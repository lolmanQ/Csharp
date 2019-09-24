using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace circel
{
	class Program
	{
		static void Main(string[] args)
		{
			double radie = 5.2;
			double f1 = 8.2;
			double f2 = 7.9;
			double f3 = 2.3;
			Console.WriteLine("cirkel omkrets: " + CirkelOmkrets(radie));
			Console.WriteLine("cirkel area: " + CirkelArea(radie));
			Console.WriteLine("medel värde för float: " + FloatMedel(f1, f2, f3));
		}

		static double CirkelOmkrets(double radie)
		{
			double diameter = radie * 2;
			return diameter * Math.PI;
		}

		static double CirkelArea(double radie)
		{
			return Math.PI * Math.Pow(radie, 2);
		}

		static double FloatMedel(double float1, double float2, double float3)
		{
			return (float1 + float2 + float3) / 3;
		}
	}
}
