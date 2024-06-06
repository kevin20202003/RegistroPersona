using Xamarin.Forms;
using System.IO;
using System;
using RegistroPersona.DataBase;

namespace RegistroPersona
{
    public partial class App : Application
    {
        static Data database;

        public static Data Database
        {
            get
            {
                if (database == null)
                {
                    database = new Data(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Personas.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
