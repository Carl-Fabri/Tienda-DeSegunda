using Enneto.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enneto.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Enneto.Views.Slides
{
    public partial class SliderView : ContentPage
    {
        SliderViewModels Context;
        public SliderView()
        {
            InitializeComponent();
            this.BindingContext = new SliderViewModels();

        }
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            Context = this.BindingContext as SliderViewModels;

        }

        private void MainCarousel_PositionChanged(object sender, PositionChangedEventArgs e)
        {
            var image = sender as Image;

        }

        private async void RedireccionTienda_Clicked(object sender, EventArgs e)
        {
            RedireccionTienda.IsEnabled = false;
            Navigation.InsertPageBefore(new FlyoutPageShop(),this);
            await Navigation.PopAsync(true);
        }
    }
}