using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Livraison
{
    public partial class App : Application
    {
        public static string ServiceBaseAddress { get; internal set; }

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
