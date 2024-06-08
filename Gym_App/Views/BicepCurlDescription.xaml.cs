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
    public partial class BicepCurlDescription : ContentPage
    {
        public BicepCurlDescription()
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
                ExerciseName = "Curl de Bíceps con Barra",
                Description = "El curl de bíceps con barra es un ejercicio clásico para desarrollar los músculos de los bíceps. Toma una barra con ambas manos, con las palmas hacia arriba y los pies al ancho de los hombros. Flexiona los codos y lleva la barra hacia tus hombros, manteniendo los codos cerca del cuerpo. Baja la barra de manera controlada para regresar a la posición inicial."
            };
            ExerciseNameLabel.Text = description.ExerciseName;
            ExerciseDescriptionLabel.Text = description.Description;
            
        }

        private async void ReturnButtonBarbellBicepCurl_Clicked(object sender, EventArgs e)
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