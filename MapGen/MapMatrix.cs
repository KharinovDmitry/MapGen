namespace MapGen
{
    internal class MapMatrix
    {
        private Perlin[] perlins { get; set; }
        public double[,] Matrix { get; set; }
        public int Size { get; private set; }
        public int Rang { get; set; }

        public MapMatrix(int rang, int k)
        {
            Rang = rang;
            Size = (int)Math.Pow(2, rang);
            perlins = GeneratePelins();
            Matrix = GenerateMatrix();
            Smooth(Matrix, k * 10);
        }

        private double[,] GenerateMatrix()
        {
            double[,] res = new double[Size, Size];
            Calculate(res);
            return res;
        }

        private void Smooth(double[,] res, int k)
        {
            for (int k0 = 0; k0 < k; k0++)
            {
                for (int i = 1; i < Size - 1; i++)
                {
                    for (int j = 1; j < Size - 1; j++)
                    {
                        res[i, j] = MiddleOf(Matrix[i, j], Matrix[i - 1, j], Matrix[i + 1, j], Matrix[i, j - 1], Matrix[i, j + 1]);
                    }
                }
            }
        }

        private void Calculate(double[,] res)
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    double sum = 0;
                    foreach (var el in perlins)
                    {
                        sum += el.Matrix[i, j];
                    }
                    res[i, j] = sum / Rang;
                }
            }
        }

        private static double MiddleOf(params double[] doubles)
        {
            return doubles.Sum() / doubles.Length;
        }

        private Perlin[] GeneratePelins()
        {
            Perlin[] res = new Perlin[Rang];
            for (int i = 0; i < Rang; i++)
            {
                res[i] = new Perlin((int)Math.Pow(2, i + 1));
                res[i].UpRang(Size);
            }
            return res;
        }
    }
}
