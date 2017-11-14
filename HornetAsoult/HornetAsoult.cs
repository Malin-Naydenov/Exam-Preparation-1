using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HornetAsoult
{
    class HornetAsoult
    {
        static void Main(string[] args)
        {
            var beans = Console.ReadLine().Split(' ').Select(long.Parse).ToList();
            var hornbeams = Console.ReadLine().Split(' ').Select(long.Parse).ToList();

            List<long> house = new List<long>();
            long restBean = 0;
            long allHornbeam = hornbeams.Sum();

            for (int i = 0; i < beans.Count; i++)
            {
                if (hornbeams.Count == 0)
                {
                    break;
                }
                else if (allHornbeam <= beans[i])
                {
                    restBean = beans[i] - allHornbeam;
                    if(restBean > 0)
                    {
                    house.Add(restBean);

                    }
                    hornbeams.RemoveAt(0);
                    allHornbeam = hornbeams.Sum();
                }
                
            }

            if (house.Count != 0)
            {
                Console.WriteLine(String.Join(" ", house));
            }
            else
            {
                Console.WriteLine(String.Join(" ",hornbeams));
            }
            
        }
    }
}
