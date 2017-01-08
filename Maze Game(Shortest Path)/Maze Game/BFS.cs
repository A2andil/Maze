using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maze_Game
{
    class BFS
    {
        public BFS(Node nd)
        {
            Maze.que.Enqueue(nd);
            search();
        }

        private void search()
        {
            while (Maze.que.Count > 0)
            {
                Node cur = (Node)Maze.que.Dequeue();
                if (cur.x == 12 && cur.y == 28)
                {
                    Node tmp = cur;
                    while (tmp != null)
                    {
                        Maze.stack.Push(tmp);
                        tmp = tmp.parent;
                    }
                    break;
                }
                cur.getChild(cur);
            }
        }
    }
}
