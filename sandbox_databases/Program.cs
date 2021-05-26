using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sandbox_databases
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form_auth());
        }
    }

    static class login
    {
        public static string Value { get; set; }

    }

    static class intim
    {
        public static string Value { get; set; }

    }

    static class logos
    {
        public static string Value { get; set; }

    }

    static class pere
    {
        public static string Value { get; set; }

    }

    static class log
    {
        public static string Value { get; set; }

    }

    static class id_doc
    {
        public static int Value { get; set; }

    }
}
