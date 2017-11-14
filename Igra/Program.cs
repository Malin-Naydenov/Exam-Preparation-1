using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igra
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> gru = new List<int> { 10, 20, 30, 40 };
            gru.RemoveAt(0);
            Console.WriteLine(String.Join(" ", gru));
        }
    }
}
