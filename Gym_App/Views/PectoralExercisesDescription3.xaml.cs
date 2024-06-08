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
    public partial class PectoralExercisesDescription3 : ContentPage
    {
        public PectoralExercisesDescription3()
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
                ExerciseName = "FONDOS EN PARALELAS", // Update this to the new exercise name
                Description = "Este ejercicio es excelente para trabajar los pectorales, tríceps y hombros. Sujeta las barras paralelas y elévate hasta que tus brazos estén completamente extendidos. Baja lentamente el cuerpo flexionando los codos hasta que los hombros estén al nivel de los codos. Luego, empuja hacia arriba hasta volver a la posición inicial."
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