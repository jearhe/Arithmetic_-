using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 控制台Test
{
    class Program
    {
        static void Main(string[] args)
        {
            test aa = new test();
            int[,] map = new int[100, 100];
            aa.ClearMap(map,12);
            aa.move(0, 0, 12, map);
            int k = aa.count;
            Console.WriteLine("{0}", k);

        }
    }
}
