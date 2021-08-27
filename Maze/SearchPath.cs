using System;
using System.Collections.Generic;
using System.Text;

namespace Maze
{
    class Node 
    {
        public bool isExplored = false;
        public Node isExploredFrom;//aca esta el error

        public int X { get; set; }
        public int Y { get; set; }

        public Node(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    class SearchPath
    {
        private static Node startingPoint= new Node(0,0);
        private static Node endingPoint= new Node(2,0);
        private static Node searchingPoint;                           
        private static bool isExploring = true;                       // If we are end then it is set to false

        private static List<Node> path = new List<Node>();            // For storing the path traversed

        private static Dictionary<int[,], Node> block = new Dictionary<int[,], Node>();
        private static Queue<Node> queue = new Queue<Node>();

        static List<Node> nodes = new List<Node>();

        static int[,] maze = { { 0, 0, 0 }, { 0, 1, 0 }, { 0, 0, 0 } };
        //static int[,] directions = { { 0,-1 }, { 0, 1 }, { -1, 0 },{ 1, 0 } };
        static int[][] directions = new int[4][];

    public static void CreateMaze()
        {
            block.Add(new int[0,0], new Node(0, 0));
            block.Add(new int[1,0], new Node(1, 0));
            block.Add(new int[2,0], new Node(2, 0));
            block.Add(new int[0,1], new Node(0, -1));
            //block.Add(new int[1,1], new Node(1, -1)); //El hueco no se pone o si?????
            block.Add(new int[2,1], new Node(2, -1));
            block.Add(new int[0,2], new Node(0, -2));
            block.Add(new int[1,2], new Node(1, -2));
            block.Add(new int[2,2], new Node(2, -2));
        }

        public static void BFS()
        {
            queue.Enqueue(startingPoint);
            while (queue.Count > 0 && isExploring)
            {
                searchingPoint = queue.Dequeue();
                OnReachingEnd();
                ExploreNeighbourNodes();  //Ayuda diosito xfa
                
            }
        }
        static void ExploreNeighbourNodes()
        {
            directions[0] = new int[] { 0, -1 };
            directions[1] = new int[] { 0, 1 };
            directions[2] = new int[] { 1, 0 };
            directions[3] = new int[] { -1, 0 };


            if (!isExploring) { return; }

            for (int i = 0; i < 4; i++)
            {
                int neighbourPosX = searchingPoint.X + directions[i][0];
                int neighbourPosY = searchingPoint.Y + directions[i][1];
                int[,] neighbourPos = new int[neighbourPosX, neighbourPosY];

                if (block.ContainsKey(neighbourPos))
                {
                    Node node = block[neighbourPos];
                    if (!node.isExplored)
                    {
                        queue.Enqueue(node);                       // Enqueueing the node at this position
                        node.isExplored = true;
                        node.isExploredFrom = searchingPoint;      // Set how we reached the neighbouring node i.e the previous node; for getting the path
                    }
                }

            }
        }
        private static void OnReachingEnd()
        {
            if (searchingPoint == endingPoint)
            {
                isExploring = false;
            }
            else
            {
                isExploring = true;
            }
        }

        public static void CreatePath()
        {
            SetPath(endingPoint);
            Node previousNode = endingPoint.isExploredFrom;

            while (previousNode != startingPoint)
            {
                SetPath(previousNode);
                previousNode = previousNode.isExploredFrom;
            }

            SetPath(startingPoint);
            path.Reverse();

        }
        private static void SetPath(Node node)
        {
            path.Add(node);
        }

        

        public static void Print()
        {
            Console.WriteLine("Starting Point-> "+startingPoint.X+","+startingPoint.Y);
            Console.WriteLine("Final Point-> " + endingPoint.X + "," + endingPoint.Y);

            for (int i =0; i<3; i++)
            {
                for(int j=0; j<3; j++)
                {
                    Console.Write("["+maze[i, j]+"]");
                }
                Console.WriteLine();
            }

            //Console.WriteLine("Path-> " + path);

        }


    }
}
