using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maze_Game
{
    class DFS
    {
        public DFS(Node strt)
        {
            DFSU(strt);
        }

        private void DFSU(Node nd)
        {
            if (nd.x == 12 && nd.y == 28)
            {
                while (nd != null)
                {
                    Maze.stack.Push(nd);
                    nd = nd.parent;
                }
                Maze.goal = true;
               
                ////Console.ForegroundColor = ConsoleColor.Red;
                //int j = 0;
                //while (Maze.stack.Count > 0)
                //{
                //    nd = ((Node)Maze.stack.Pop());

                //    Console.WriteLine(nd.x.ToString() + " " + nd.y.ToString());
                //    Thread.Sleep(200);
                //}
            }
            else if (!Maze.goal)
            {
                nd.getChild(nd);
                Maze.visted[nd.x, nd.y] = 1;
            }
            for (int i = 0; nd != null && Maze.adjList[nd.x, nd.y] != null && i < Maze.adjList[nd.x, nd.y].Count && !Maze.goal; i++)
            {
                int x, y;
                x = ((Node)Maze.adjList[nd.x, nd.y][i]).x;
                y = ((Node)Maze.adjList[nd.x, nd.y][i]).y;
                if (Maze.visted[x, y] == 0)
                {
                    DFSU((Node)Maze.adjList[nd.x, nd.y][i]);
                }
            }
        }
    }
}
