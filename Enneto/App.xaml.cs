using Enneto.Views;
using Enneto.Views.Login;
using Enneto.Views.Slides;
using Enneto.Views.Toolbar;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Enneto
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new SliderView());
            //new FlyoutPageShop()
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
