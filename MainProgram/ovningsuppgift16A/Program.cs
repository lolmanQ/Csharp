using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ovningsuppgift16A
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("During how long did it take:");

			string userInputString = Console.ReadLine();
			double userInputDouble = double.Parse(userInputString);

			double distens = 9.81 * Math.Pow(userInputDouble, 2) / 2;
			Console.WriteLine(distens + " Meters");
        }
    }
}
