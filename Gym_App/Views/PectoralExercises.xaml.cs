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
    public partial class PectoralExercises : ContentPage
    {
        public PectoralExercises()
        {
            NavigationPage.SetHasBackButton(this, false);
            InitializeComponent();

        }
        private async void Pectoral1ButtonPectorial_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PectoralExercisesDescription());
        }
        private async void Pectoral2ButtonPectorialD_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PectoralExercisesDescription2());
        }
        private async void Pectoral3ButtonPectorialD_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PectoralExercisesDescription3());
        }

        private async void ReturnButtonPectorial_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ExerciseGuide());
        }

        private void HomeButtonEspalda_Clicked(object sender, EventArgs e)
        {
            // Replace "NewScreen" with the actual name of your new screen class
            Navigation.PushAsync(new Dashboard());
        }
        private void Info3Button_Clicked(object sender, EventArgs e)
        {
            // Replace "NewScreen" with the actual name of your new screen class
            Navigation.PushAsync(new AppInfoPage());
        }
       
            private void calen1Button_Clicked(object sender, EventArgs e)
        {
            // Replace "NewScreen" with the actual name of your new screen class
            Navigation.PushAsync(new HorariosPage());
        }
    }
}