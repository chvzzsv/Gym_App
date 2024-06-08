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
    public partial class DumbbellRowDescription : ContentPage
    {
        public DumbbellRowDescription()
        {
            NavigationPage.SetHasBackButton(this, false);
            InitializeComponent();
            LoadExerciseDescription();
        }

        private void LoadExerciseDescription()
        {
            var dbService = new DatabaseService();
            ExerciseDescription description = new ExerciseDescription
            {
                ExerciseName = "Remo con Mancuernas (Dumbbell Row)",
                Description = "El remo con mancuernas es un ejercicio eficaz para fortalecer los músculos de la espalda. Coloca una rodilla y una mano sobre un banco para estabilizarte. Con la otra mano, toma una mancuerna y déjala colgar hacia abajo. Levanta la mancuerna hacia tu torso, manteniendo el codo cerca del cuerpo. Baja la mancuerna de forma controlada para volver a la posición inicial."
            };
            ExerciseNameLabel.Text = description.ExerciseName;
            ExerciseDescriptionLabel.Text = description.Description;
        }

        private async void ReturnButtonDumbbellRow_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
        private void HomeButtonEspalda_Clicked(object sender, EventArgs e)
        {
            // Replace "NewScreen" with the actual name of your new screen class
            Navigation.PushAsync(new Dashboard());
        }
    }
}