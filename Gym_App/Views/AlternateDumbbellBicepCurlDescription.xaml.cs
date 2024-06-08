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
    public partial class AlternateDumbbellBicepCurlDescription : ContentPage
    {
        public AlternateDumbbellBicepCurlDescription()
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
                ExerciseName = "Curl de Bíceps con Mancuernas Alternas",
                Description = "El curl de bíceps con mancuernas alternas es un ejercicio efectivo para trabajar los bíceps. Toma una mancuerna en cada mano, con las palmas hacia el cuerpo. Alterna los brazos para levantar una mancuerna hacia tu hombro mientras giras la muñeca para que la palma quede hacia arriba. Baja la mancuerna de manera controlada y repite con el otro brazo."
            };
            ExerciseNameLabel.Text = description.ExerciseName;
            ExerciseDescriptionLabel.Text = description.Description;
          
        }

        private async void ReturnButtonAlternateDumbbellBicepCurl_Clicked(object sender, EventArgs e)
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