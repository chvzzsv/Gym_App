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
    public partial class ExerciseGuide : ContentPage
    {
        public ExerciseGuide()
        {
            NavigationPage.SetHasBackButton(this, false);
            InitializeComponent();
        }
        private async void ReturnButton_Clicked(object sender, EventArgs e)
        {
            // Lógica para el botón "Registrar"
            await Navigation.PushAsync(new Dashboard());
        }
        private void Ejercicio1Button_Clicked(object sender, EventArgs e)
        {
            // Replace "NewScreen" with the actual name of your new screen class
            Navigation.PushAsync(new PectoralExercises());
        }

        private void Ejercicio1ButtonEspalda_Clicked(object sender, EventArgs e)
        {
            // Replace "NewScreen" with the actual name of your new screen class
            Navigation.PushAsync(new BackExercises());
        }
        private void ButtonBiceps_Clicked(object sender, EventArgs e)
        {
            // Replace "NewScreen" with the actual name of your new screen class
            Navigation.PushAsync(new BicepExercises());
        }
        private void HomeButtonEspalda_Clicked(object sender, EventArgs e)
        {
            // Replace "NewScreen" with the actual name of your new screen class
            Navigation.PushAsync(new Dashboard());
        }
        private void Info2Button_Clicked(object sender, EventArgs e)
        {
            // Replace "NewScreen" with the actual name of your new screen class
            Navigation.PushAsync(new AppInfoPage());
        }
        private void CalendarioButton_Clicked(object sender, EventArgs e)
        {
            // Replace "NewScreen" with the actual name of your new screen class
            Navigation.PushAsync(new HorariosPage());
        }
    }
}