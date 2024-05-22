using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gym_App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Database.Initialize();

            var databaseService = new DatabaseService();
            databaseService.AgregarUsuarioDePrueba();

            MainPage = new NavigationPage(new LoginPage());
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
