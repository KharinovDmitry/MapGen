using System.Windows.Forms;

namespace MapGen
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize(); 
            Application.Run(new Form1());
        }
    }
}