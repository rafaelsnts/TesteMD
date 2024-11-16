using System;
using System.Windows.Forms;
using TesteMD.Forms._1___Principal;

namespace TesteMD
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new form_MenuPrincipal());
        }
    }
}
