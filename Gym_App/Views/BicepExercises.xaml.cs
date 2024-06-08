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
    public partial class BicepExercises : ContentPage
    {
        public BicepExercises()
        {
            NavigationPage.SetHasBackButton(this, false);
            InitializeComponent();
        }
        private async void OnBicepCurlClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BicepCurlDescription());
        }
        private async void ReturnButtonBicepExercises_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ExerciseGuide());
        }
        private async void OnAlternateDumbbellBicepCurlClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AlternateDumbbellBicepCurlDescription());
        }
        private async void OnConcentrationBicepCurlOnBenchClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ConcentrationBicepCurlOnBenchDescription());
        }
        private void HomeButtonEspalda_Clicked(object sender, EventArgs e)
        {
            // Replace "NewScreen" with the actual name of your new screen class
            Navigation.PushAsync(new Dashboard());
        }
    }
}