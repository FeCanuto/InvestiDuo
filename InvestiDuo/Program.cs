using InvestiDuo._Repositories;
using InvestiDuo.Models;
using InvestiDuo.Presenters;
using InvestiDuo.Views;
using System.Configuration;

namespace InvestiDuo
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ApplicationConfiguration.Initialize();
            Start();

        }

        public static void Start()
        {
            string sqlConnectionString = ConfigurationManager.ConnectionStrings["InvestiDuo.Properties.Settings.SqlConnection"].ConnectionString;
            IMainView view = new MainView();
            new MainPresenter(view, sqlConnectionString);
            Application.Run((Form)view);

        }
    }
}
