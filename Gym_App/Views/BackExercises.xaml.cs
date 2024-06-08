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
    public partial class BackExercises : ContentPage
    {
        public BackExercises()
        {
            NavigationPage.SetHasBackButton(this, false);
            InitializeComponent();
        }
        private void ReturnButtonBackExercises_Clicked(object sender, EventArgs e)
        {
            // Replace "NewScreen" with the actual name of your new screen class
            Navigation.PushAsync(new ExerciseGuide());
        }
        private void Espalda1ButtonPectorial_Clicked(object sender, EventArgs e)
        {
            // Replace "NewScreen" with the actual name of your new screen class
            Navigation.PushAsync(new DumbbellRowDescription());
        }
        private void OnLatPulldownClicked(object sender, EventArgs e)
        {
            // Replace "NewScreen" with the actual name of your new screen class
            Navigation.PushAsync(new LatPulldownDescription());
        }
        private void BarbellClicked(object sender, EventArgs e)
        {
            // Replace "NewScreen" with the actual name of your new screen class
            Navigation.PushAsync(new BarbellRowDescription());
        }
        private void HomeButtonEspalda_Clicked(object sender, EventArgs e)
        {
            // Replace "NewScreen" with the actual name of your new screen class
            Navigation.PushAsync(new Dashboard());
        }
    }
}