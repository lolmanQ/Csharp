using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace random
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Är det fint väder?");
            string inputString = Console.ReadLine();
            inputString = inputString.ToLower();
            if(inputString == "j")
            {
                Console.WriteLine("Vi går på picknick!");
            }
            else if(inputString == "n")
            {
                Console.WriteLine("Vi stannar inne och läser en bok");
            }
            else
            {
                Console.WriteLine("Jag förstår inte");
            }
        }
    }
}
