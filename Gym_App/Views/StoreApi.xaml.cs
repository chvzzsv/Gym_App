using Gym_App.Models;
using Gym_App.Services;
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
    public partial class StoreApi : ContentPage
    {
        private readonly Client _client;
        public StoreApi()
        {
            NavigationPage.SetHasBackButton(this, false);
            InitializeComponent();
            _client = new Client();
            LoadProducts();
        }
        private async void LoadProducts()
        {
            try
            {
                List<Product> products = await _client.GetProductsAsync();
                ProductsCollectionView.ItemsSource = products;
            }
            catch (Exception ex)
            {
               
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }
        private void HomeButtonEspalda_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Dashboard());
        }
        private void ReturnButtonDumbbellRow_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Dashboard());
        }
        private void HomeButtonHorario_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HorariosPage());
        }
        private void Info3Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AppInfoPage());
        }
    }
}