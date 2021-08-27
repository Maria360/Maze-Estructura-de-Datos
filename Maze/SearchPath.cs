using System;
using System.Collections.Generic;
using System.Text;

namespace Maze
{
    class Node 
    {
        public bool isExplored = false;
        public Node isExploredFrom = null;

        public int X { get; set; }
        public int Y { get; set; }

        public Node(int x, int y)
        {
            X = x;
            Y = y;
        }
        public Array GetPos()
        {
            int[] pos = new int[2];
            pos[0] = X;
            pos[1] = Y;
            return pos;
        }

    }

    class SearchPath
    {
        private static Node startingPoint;
        private static Node endingPoint;
        private static Node searchingPoint;                           
        private static bool isExploring = true;                       // If we are end then it is set to false

        private static List<Node> path = new List<Node>();            // For storing the path traversed

        private static Dictionary<string, Node> block = new Dictionary<string, Node>();
        private static Queue<Node> queue = new Queue<Node>();

        static List<Node> nodes = new List<Node>();

        public static void CreateMaze()
        {
            nodes.Add(new Node(0, 0));
            nodes.Add(new Node(1, 0));
            nodes.Add(new Node(2, 0));
            nodes.Add(new Node(0, -1));
            nodes.Add(new Node(1,-1));//hueco???????????????
            nodes.Add(new Node(2,-1));
            nodes.Add(new Node(0,-2));
            nodes.Add(new Node(1,-2));
            nodes.Add(new Node(2,-2));
            
            foreach (Node node in nodes)
            {
                block.Add(node.GetPos().ToString(), node);//esto en serio funciona???? -NO ;;

            }
        }

        public static void BFS()
        {
            queue.Enqueue(startingPoint);
            while (queue.Count > 0 && isExploring)
            {
                searchingPoint = queue.Dequeue();
                OnReachingEnd();
                //ExploreNeighbourNodes();  Ayuda diosito xfa
                if (isExploring)
                {
                    foreach(Node node in nodes)
                    {
                        if (block.ContainsKey(node.GetPos().ToString()))
                        {
                            //node = block[node.GetPos().ToString()];
                        }
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

        public void CreatePath()
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
        private void SetPath(Node node)
        {
            path.Add(node);
        }

        /*public static List<string> GeneratePath(Dictionary<string, string> parentMap, string endState)
        {
            List<string> path = new List<string>();
            string parent = endState;
            while (parentMap.ContainsKey(parent))
            {
                path.Add(parent);
                parent = parentMap[parent];
            }
            return path;
        }*/

        public static void ShowPath()
        {
            //Console.WriteLine(path);
            Console.WriteLine(block);
        }
        

    }
}
