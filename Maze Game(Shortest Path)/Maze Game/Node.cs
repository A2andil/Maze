using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Game
{
    class Node
    {
        public int x, y;
        public Node parent;
        public Node(int x, int y, Node parent)
        {
            this.x = x;
            this.y = y;
            this.parent = parent;
        }
        public void getChild(Node nd)
        {
            //bottom
            if (nd.x < 12 && Maze.mzar[nd.x + 1, nd.y] == 0 && Maze.visted[nd.x + 1, nd.y] == 0)
            {
                Node Nd = new Node(nd.x + 1, nd.y, nd);
                Maze.que.Enqueue(Nd);
                Maze.visted[nd.x + 1, nd.y] = 1;
            }
            //left
            if (nd.y < 29 && Maze.mzar[nd.x, nd.y + 1] == 0 && Maze.visted[nd.x, nd.y + 1] == 0)
            {
                Node Nd = new Node(nd.x, nd.y + 1, nd);
                Maze.que.Enqueue(Nd);
                Maze.visted[nd.x, nd.y + 1] = 1;
            }
            //top
            if (nd.x > 0 && Maze.mzar[nd.x - 1, nd.y] == 0 && Maze.visted[nd.x - 1, nd.y] == 0)
            {
                Node Nd = new Node(nd.x - 1, nd.y, nd);
                Maze.que.Enqueue(Nd);
                Maze.visted[nd.x - 1, nd.y] = 1;
            }
            //right
            if (Maze.mzar[nd.x, nd.y - 1] == 0 && Maze.visted[nd.x, nd.y - 1] == 0)
            {
                Node Nd = new Node(nd.x, nd.y - 1, nd);
                Maze.que.Enqueue(Nd);
                Maze.visted[nd.x, nd.y - 1] = 1;
            }
        }
    }
}
