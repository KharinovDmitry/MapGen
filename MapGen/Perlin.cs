namespace MapGen
{
    internal class Perlin
    {
        public int Rang { get; set; }
        public int[,] Matrix { get; set; }

        public Perlin(int rang)
        {
            Rang = rang;
            Matrix = GenerateMatrix(rang);
        }
        private int[,] GenerateMatrix(int rang)
        {
            int[,] res = new int[rang, rang];
            Random r = new Random();
            for (int i = 0; i < rang; i++)
            {
                for (int j = 0; j < rang; j++)
                {
                    res[i, j] = r.Next(0, 2);
                }
            }
            return res;
        }

        public void UpRang(int newRang)
        {
            if (newRang < Rang || newRang % Rang != 0)
                throw new ArgumentException();
            int[,] newMatrix = new int[newRang, newRang];
            int k = newRang / Rang;
            for (int i = 0; i < newRang; i++)
            {
                for (int j = 0; j < newRang; j++)
                {
                    newMatrix[i, j] = Matrix[i / k, j / k];
                }
            }
            Rang = newRang;
            Matrix = newMatrix;
        }
    }
}
