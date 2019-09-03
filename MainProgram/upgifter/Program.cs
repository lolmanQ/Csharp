using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace upgifter
{
    class Program
    {
        static void Main(string[] args)
        {
            string userinput = Console.ReadLine();
            int userinputint = int.Parse(userinput);
            userinputint++;
            for(int i = userinputint; i<= 100;i++)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
        }
    }
}
