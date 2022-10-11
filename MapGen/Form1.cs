using System;
using System.Drawing.Drawing2D;
using System.IO;

namespace MapGen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            int rang = 10; // 2 ^ rang = size of map
            int k = 30; // smooth koef
            MapMatrix map = new MapMatrix(rang, k);
            AddRiver(map);
            DrawBitmap(map);
        }

        private void AddRiver(MapMatrix map)
        {
            MapMatrix mapRiver = new MapMatrix(map.Rang, 20);
            for (int i = 0; i < mapRiver.Size; i++)
            {
                for (int j = 0; j < mapRiver.Size; j++)
                {
                    if (mapRiver.Matrix[i, j] > 0.38 && mapRiver.Matrix[i, j] < 0.4)
                        map.Matrix[i, j] = 0.4;
                }
            }
        }

        private void DrawBitmap(MapMatrix map)
        {
            Bitmap bmp = GetBitmap(map);
            string path = @".\test.png";
            bmp.Save(path);
            PictureBox pic = new PictureBox();
            pic.SizeMode = PictureBoxSizeMode.AutoSize;
            pic.Image = bmp;
            Controls.Add(pic);
        }
        private static Bitmap GetBitmap(MapMatrix map)
        {
            Bitmap bmp = new Bitmap(map.Size, map.Size);
            Graphics g = Graphics.FromImage(bmp);
            for (int x = 0; x < map.Size; x++)
            {
                for (int y = 0; y < map.Size; y++)
                {
                    Brush brush = GetBrush(map.Matrix[x, y]);
                    g.FillRectangle(brush, x, y, 1, 1);
                }
            }
            g.Dispose();
            return bmp;
        }

        private static Brush GetBrush(double v)
        {
            if (v < 0.2)
                return Brushes.DarkBlue;
            else if (v < 0.45)
                return Brushes.Blue;
            else if (v < 0.5)
                return Brushes.Yellow;
            else if (v < 0.6)
                return Brushes.Green;
            else if (v < 0.75)
                return Brushes.DarkGreen;
            else if (v <= 1)
                return Brushes.White;
            else
                throw new ArgumentException();
        }
    }
}