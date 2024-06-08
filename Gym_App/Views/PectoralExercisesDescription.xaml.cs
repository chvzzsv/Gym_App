using Gym_App.Data;
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
    public partial class PectoralExercisesDescription : ContentPage
    {
        public PectoralExercisesDescription()
        {
            NavigationPage.SetHasBackButton(this, false);
            InitializeComponent();
            LoadExerciseDescription();
        }

        private void LoadExerciseDescription()
        {
            var dbService = new DatabaseService();
            ExerciseDescription description = dbService.ObtenerDescripcionesDeEjercicios().FirstOrDefault();
            if (description != null)
            {
                ExerciseNameLabel.Text = description.ExerciseName;
                ExerciseDescriptionLabel.Text = description.Description;
            }
        }

        private async void Pectoral1ButtonPectorialD_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PectoralExercises());
        }
        private void HomeButtonEspalda_Clicked(object sender, EventArgs e)
        {
            // Replace "NewScreen" with the actual name of your new screen class
            Navigation.PushAsync(new Dashboard());
        }
    }
}