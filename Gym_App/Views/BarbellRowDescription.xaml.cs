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
    public partial class BarbellRowDescription : ContentPage
    {
        public BarbellRowDescription()
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
                ExerciseName = "Remo con Barra Horizontal (Barbell Row)",
                Description = "El remo con barra horizontal es un ejercicio efectivo para fortalecer los músculos de la espalda. Coloca una barra en el suelo y agáchate para tomarla con un agarre de manos prono. Mantén la espalda recta y las rodillas ligeramente flexionadas. Levanta la barra hacia tu torso, manteniendo los codos cerca del cuerpo. Baja la barra de forma controlada para volver a la posición inicial."
            };
            ExerciseNameLabel.Text = description.ExerciseName;
            ExerciseDescriptionLabel.Text = description.Description;
           
        }

        private async void ReturnButtonBarbellRow_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }


        private async void OnLatPulldownClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LatPulldownDescription());
        }
        private void HomeButtonEspalda_Clicked(object sender, EventArgs e)
        {
            // Replace "NewScreen" with the actual name of your new screen class
            Navigation.PushAsync(new Dashboard());
        }
    }
}