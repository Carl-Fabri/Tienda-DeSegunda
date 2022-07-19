using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Enneto.Views.Toolbar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToolbarView1 : ContentView
    {
        public ToolbarView1()
        {
            InitializeComponent();
        }

        private void MenuClick(object sender, EventArgs e) 
        {
            App.Current.MainPage.DisplayAlert("Mensaje","Menu cliqueado","Ok");
        }
        private async void NavigateToBack(object sender, EventArgs e)
        {
           await Navigation.PopAsync();
        }

        public string ToolbarTitle
        {
            get => (string)GetValue(ToolbarTitleProperty);
            set => SetValue(ToolbarTitleProperty, value);
        }

        public static readonly BindableProperty ToolbarTitleProperty = BindableProperty.Create(
            nameof(BackButtonIsVisible),
            typeof(string),
            typeof(ToolbarView1), default(string),
            defaultBindingMode: BindingMode.OneWay);



        public bool BackButtonIsVisible
        {
            get => (bool)GetValue(BackButtonTitleProperty);
            set => SetValue(BackButtonTitleProperty, value);
        }

        public static readonly BindableProperty BackButtonTitleProperty = BindableProperty.Create(
            nameof(BackButtonIsVisible),
            typeof(bool),
            typeof(ToolbarView1), default(bool),
            defaultBindingMode: BindingMode.OneWay);

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }


}