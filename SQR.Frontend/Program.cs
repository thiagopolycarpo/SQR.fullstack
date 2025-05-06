using System;
using System.Windows.Forms;

namespace SQR.Frontend
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ProductionForm());
        }
    }
}