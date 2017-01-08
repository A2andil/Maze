using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maze_Game
{

    public partial class Form1 : Form
    {
        public static Bitmap bmp = new Bitmap(600, 260);
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int rw = PBOX.Height / 20, cl = PBOX.Width / 20;
            for (int i = 0; i < rw; i++)
            {
                for (int j = 0; j < cl; j++)
                {
                    int strw = i * 20, stcl = j * 20;
                    for (int n = strw; n < strw + 20; n++)
                        for (int m = stcl; m < stcl + 20; m++)
                            if (Maze.mzar[i, j] == 1)
                                bmp.SetPixel(m, n, Color.DarkGray);
                            else
                                bmp.SetPixel(m, n, Color.White);

                }
            }
            PBOX.Image = bmp;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Maze.start();
            Node nd = new Node(5, 11, null);
            BFS bfs = new BFS(nd);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Maze.stack.Count > 0)
            {
                Node tnd = (Node)Maze.stack.Pop();
                for (int i = tnd.x * 20; i < tnd.x * 20 + 20; i++)
                {
                    for (int j = tnd.y * 20; j < tnd.y * 20 + 20; j++)
                    {
                        Form1.bmp.SetPixel(j, i, Color.DeepPink);
                    }
                }
            }
            PBOX.Image = bmp;
        }
    }
}
