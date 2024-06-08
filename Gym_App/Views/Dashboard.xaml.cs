using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gym_App.Views
{

	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Dashboard : ContentPage
	{
		public Dashboard ()
		{

            NavigationPage.SetHasBackButton(this, false);
            InitializeComponent();
            AgendarButton.Clicked += AgendarButton_Clicked;
            RegistrarButton.Clicked += RegistrarButton_Clicked;
            ConsejosButton.Clicked += ConsejosButton_Clicked;
            CerrarSesionButton.Clicked += CerrarSesionButton_Clicked;

            // Mostrar el nombre del usuario en el Dashboard
            if (DatabaseService.UsuarioActual != null)
            {
                UsuarioLabel.Text = $"Bienvenido, {DatabaseService.UsuarioActual.Nombre}";
            }
        }
        private async void AgendarButton_Clicked(object sender, EventArgs e) =>
            await Navigation.PushAsync(new AgendarPage());

        private async void RegistrarButton_Clicked(object sender, EventArgs e)
        {
            // Lógica para el botón "Registrar"
            await Navigation.PushAsync(new ExerciseGuide());
        }

        private async void ConsejosButton_Clicked(object sender, EventArgs e)
        {
            // Lógica para el botón "Consejos"
            await Navigation.PushAsync(new StoreApi());
        }

        private class RegistrarPage : Page
        {
        }

        private class ConsejosPage : Page
        {
        }
        private async void CerrarSesionButton_Clicked(object sender, EventArgs e)
        {
            // Lógica de cierre de sesión
            var databaseService = new DatabaseService();
            databaseService.CerrarSesion();

            // Navegar a la página de inicio de sesión
            await Navigation.PushAsync(new  LoginPage());
        }
        private async void HorarioButton_Clicked(object sender, EventArgs e)
        {
            // Lógica para el botón "Consejos"
            await Navigation.PushAsync(new HorariosPage());
        }
        private async void InfoButton_Clicked(object sender, EventArgs e)
        {
            // Lógica para el botón "Consejos"
            await Navigation.PushAsync(new AppInfoPage());
        }
    }
}