using System.Drawing.Drawing2D;

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
            GenerateMap();
        }

        private void GenerateMap()
        {
            int rang = 10; // 2 ^ rang = размер карты
            int k = 30; // Коэффицент сглаживания
            MapMatrix map = new MapMatrix(rang, k);
            string path = @"C:\\Users\terro\OneDrive\Рабочий стол\VS\test.png";
            Bitmap bmp = GetBitmap(map);
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