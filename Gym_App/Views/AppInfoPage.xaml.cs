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
    public partial class AppInfoPage : ContentPage
    {
        public AppInfoPage()
        {
            NavigationPage.SetHasBackButton(this, false);
            InitializeComponent();
        }
        private void HomeButtonInfo_Clicked(object sender, EventArgs e)
        {
            // Replace "NewScreen" with the actual name of your new screen class
            Navigation.PushAsync(new Dashboard());
        }
        private void CalenButton_Clicked(object sender, EventArgs e)
        {
            // Replace "NewScreen" with the actual name of your new screen class
            Navigation.PushAsync(new HorariosPage());
        }
        private void ReturnButtonInfo_Clicked(object sender, EventArgs e)
        {
            // Replace "NewScreen" with the actual name of your new screen class
            Navigation.PushAsync(new Dashboard());
        }
    }
}