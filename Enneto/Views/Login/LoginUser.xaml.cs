using Enneto.ViewModels.Loguin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Enneto.Views.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginUser : ContentPage
    {
        public LoginUser()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel(Navigation, this);
        }

        private async void SignUp_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Register());
        }

        private async void LoguinButton_Clicked(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new FlyoutPageShop(), this);
            await Navigation.PopAsync().ConfigureAwait(false);
        }
    }
}