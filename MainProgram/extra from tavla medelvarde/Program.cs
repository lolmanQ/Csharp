using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace extra_from_tavla_medelvarde
{
    class Program
    {
        public static void Main()
        {
            int antalTal;
            double summa = 0, input, large = 0, small = 0;
            Console.Write("Antal tal som ska matas in? ");
            antalTal = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= antalTal; i++)
            {
                Console.Write("Skriv värde " + i + ": ");
                input = Convert.ToDouble(Console.ReadLine());
                summa = summa + input;

                if(large == 0)
                {
                    large = input;
                }
                else if(input > large)
                {
                    large = input;
                }

                if (small == 0)
                {
                    small = input;
                }
                else if (input < small)
                {
                    small = input;
                }
            }
            Console.WriteLine("Medelvärdet är: " + (summa / antalTal));
            Console.WriteLine("Högsta talet är: " + large);
            Console.WriteLine("Lägsta talet är: " + small);
        }

    }
}
