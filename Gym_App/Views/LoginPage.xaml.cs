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
            InitializeComponent();
            _databaseService = new DatabaseService();
        }

        private void IniciarSesion_Clicked(object sender, EventArgs e)
        {
            string usuario = usernameEntry.Text;
            string contraseña = passwordEntry.Text;

            bool credencialesValidas = _databaseService.ValidarCredenciales(usuario, contraseña);

            if (credencialesValidas)
            {
                Navigation.PushAsync(new MainPage());
            }
            else
            {
                DisplayAlert("Error", "Usuario o contraseña incorrectos", "OK");
            }
        }
        private async void RecuperarContraseña_Clicked(object sender, EventArgs e)
        {
            // Navegar a la página de recuperación de contraseña
            await Navigation.PushAsync(new RecuperarContraseña());
        }
    }
}