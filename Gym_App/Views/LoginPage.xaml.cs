using Gym_App.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gym_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private readonly DatabaseService _databaseService;
        public LoginPage()
        {
            NavigationPage.SetHasBackButton(this, false);
            InitializeComponent();
            _databaseService = new DatabaseService();
        }

        private async void IniciarSesion_Clicked(object sender, EventArgs e)
        {
            string usuario = usernameEntry.Text;
            string contraseña = passwordEntry.Text;

            bool credencialesValidas = _databaseService.ValidarCredenciales(usuario, contraseña);

            if (credencialesValidas)
            {
                // Navegar al Dashboard
                Application.Current.MainPage = new NavigationPage(new Dashboard());
            }
            else
            {
                await DisplayAlert("Error", "Usuario o contraseña incorrectos", "OK");
            }
        }
        private async void RecuperarContraseña_Clicked(object sender, EventArgs e)
        {
            // Navegar a la página de recuperación de contraseña
            await Navigation.PushAsync(new RecuperarContraseña());
        }
    }
}