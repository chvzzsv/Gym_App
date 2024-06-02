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
			InitializeComponent ();
            AgendarButton.Clicked += AgendarButton_Clicked;
            RegistrarButton.Clicked += RegistrarButton_Clicked;
            ConsejosButton.Clicked += ConsejosButton_Clicked;
        }
        private async void AgendarButton_Clicked(object sender, EventArgs e) =>
            await Navigation.PushAsync(new AgendarPage());

        private async void RegistrarButton_Clicked(object sender, EventArgs e)
        {
            // Lógica para el botón "Registrar"
            await Navigation.PushAsync(new RegistrarPage());
        }

        private async void ConsejosButton_Clicked(object sender, EventArgs e)
        {
            // Lógica para el botón "Consejos"
            await Navigation.PushAsync(new ConsejosPage());
        }

        private class RegistrarPage : Page
        {
        }

        private class ConsejosPage : Page
        {
        }
    }
}