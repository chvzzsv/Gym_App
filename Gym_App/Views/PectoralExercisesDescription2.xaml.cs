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
    public partial class PectoralExercisesDescription2 : ContentPage
    {
        public PectoralExercisesDescription2()
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
                ExerciseName = "PRESS DE BANCA INCLINADO CON MANCUERNAS",
                Description = "Este ejercicio se realiza en un banco inclinado y es ideal para trabajar la parte superior de los pectorales. Acuéstate en el banco inclinado con una mancuerna en cada mano. Baja las mancuernas lentamente hasta que estén a la altura de tus hombros y luego empújalas hacia arriba hasta que tus brazos estén completamente extendidos."
            };
            ExerciseNameLabel.Text = description.ExerciseName;
            ExerciseDescriptionLabel.Text = description.Description;
        }

        private async void ReturnButtonPectorial_Clicked(object sender, EventArgs e)
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