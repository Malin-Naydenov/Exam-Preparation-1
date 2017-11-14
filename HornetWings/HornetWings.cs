using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HornetWings
{
    class HornetWings
    {
        static void Main(string[] args)
        {
            int wingFlaps = int.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            int rest = int.Parse(Console.ReadLine());

            double travel = (wingFlaps / 1000) * distance;
            double travelSeconds = wingFlaps / 100;
            double travelRest = (wingFlaps / rest) * 5;

            double totalSeconds = travelSeconds + travelRest;
            Console.WriteLine($"{travel:f2} m.");
            Console.WriteLine($"{totalSeconds} s.");
        }
    }
}
