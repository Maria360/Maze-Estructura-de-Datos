using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    class Program
    {
        static void Main(string[] args)
        {

            //Medir el tiempo que tarda en encontrar el path
            Stopwatch s = new Stopwatch();
            s.Start();
            SearchPath.CreateMaze();
            SearchPath.BFS();
            SearchPath.CreatePath(); //aca hay problemas

            SearchPath.Print();
            s.Stop();
            Console.WriteLine("Breadth-first search took " + s.ElapsedMilliseconds + " ms");
            Console.WriteLine();
            //Aca termina medicion tiempo

            Console.WriteLine();





        }
    }
}
