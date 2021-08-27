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
            //SearchPath.CreatePath(); //aca hay problemas
            SearchPath.BFS();

            SearchPath.Print();
            s.Stop();
            Console.WriteLine("Breadth-first search took " + s.ElapsedMilliseconds + " ms");
            //Aca termina medicion tiempo
            SearchPath.CreateMaze();

            Console.WriteLine();





        }
    }
}
