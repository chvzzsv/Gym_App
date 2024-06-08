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
    public partial class LatPulldownDescription : ContentPage
    {
        public LatPulldownDescription()
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
                ExerciseName = "Jalón al Pecho (Lat Pulldown)",
                Description = "El jalón al pecho es un ejercicio fundamental para trabajar los músculos de la espalda, específicamente el dorsal ancho. Siéntate en la máquina de jalón y ajusta el apoyo para los muslos. Agarra la barra con las manos más separadas que el ancho de los hombros y tira de ella hacia abajo hasta la parte superior del pecho, luego regresa lentamente a la posición inicial."
            };
            ExerciseNameLabel.Text = description.ExerciseName;
            ExerciseDescriptionLabel.Text = description.Description;
        }

        private async void ReturnButtonLatPulldown_Clicked(object sender, EventArgs e)
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