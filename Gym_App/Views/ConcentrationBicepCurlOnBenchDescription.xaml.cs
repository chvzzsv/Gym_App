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
    public partial class ConcentrationBicepCurlOnBenchDescription : ContentPage
    {
        public ConcentrationBicepCurlOnBenchDescription()
        {
            InitializeComponent();
            LoadExerciseDescription();
        }

        private void LoadExerciseDescription()
        {
            var dbService = new DatabaseService();
            ExerciseDescription description = new ExerciseDescription
            {
                ExerciseName = "Curl Concentrado con Banca",
                Description = "El curl concentrado con banca es un ejercicio excelente para aislar los bíceps. Siéntate en una banca con una mancuerna en una mano, apoya el codo en el interior del muslo y curl la mancuerna hacia tu hombro. Baja de manera controlada y repite."
            };
            ExerciseNameLabel.Text = description.ExerciseName;
            ExerciseDescriptionLabel.Text = description.Description;
          
        }

        private async void ReturnButtonConcentrationBicepCurlOnBench_Clicked(object sender, EventArgs e)
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