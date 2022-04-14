using AndroidX.Loader.Content;
using LivraisonService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Livraison
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
           
            try
            {
                ProductService service = new ProductService(App.ServiceBaseAddress);
                var products = await service.GetAsync();
              
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                await DisplayAlert("Bad", "An error occured !", "Ok");
            }
           
            base.OnAppearing();
        }


        private async void ClickGestureRecognizer_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ProductEdit(OnAppearing), true);
        }

        private void RefreshView_Refreshing(object sender, EventArgs e)
        {
           
            OnAppearing();
        }

        private class ProductEdit : Page
        {
            private Action onAppearing;

            public ProductEdit(Action onAppearing)
            {
                this.onAppearing = onAppearing;
            }
        }
    }
}
