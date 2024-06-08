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
    public partial class HorariosPage : ContentPage
    {
        public HorariosPage()
        {
            NavigationPage.SetHasBackButton(this, false);
            InitializeComponent();
        }
        private async void ReturnButtonHorario_Clicked(object sender, EventArgs e)
        {
            // Lógica para el botón "Consejos"
            await Navigation.PushAsync(new Dashboard());
        }

        private async void OnBackButtonClicked(object sender, EventArgs e)
        {
            // Lógica para el botón "Consejos"
            await Navigation.PushAsync(new Dashboard());
        }
        private async void HomeButtonHorario_Clicked(object sender, EventArgs e)
        {
            // Lógica para el botón "Consejos"
            await Navigation.PushAsync(new Dashboard());
        }
        private async void HomeButtonReturn_Clicked(object sender, EventArgs e)
        {
            // Lógica para el botón "Consejos"
            await Navigation.PushAsync(new Dashboard());
        }
        private async void InfoButton_Clicked(object sender, EventArgs e)
        {
            // Lógica para el botón "Consejos"
            await Navigation.PushAsync(new AppInfoPage());
        }

    }
}