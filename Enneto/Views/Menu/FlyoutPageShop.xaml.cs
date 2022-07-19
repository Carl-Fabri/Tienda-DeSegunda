using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Enneto.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlyoutPageShop : FlyoutPage
    {
        public FlyoutPageShop()
        {
            InitializeComponent();
            FlyoutPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as FlyoutPageShopFlyoutMenuItem;
            if (item == null)
                return;

            if (baseDatos.EstaAutenticado && item.Title == "Cerrar Sesion")
            {
                baseDatos.Perfil.Username = "Invitado@Correo.com";
                baseDatos.Perfil.Password = "";
                baseDatos.Perfil.FirstName = "Invitado";
                baseDatos.Perfil.LastName = "";
                baseDatos.Perfil.Avatar = "ImagenEjemplo.png";
                baseDatos.EstaAutenticado = false;

                Navigation.InsertPageBefore(new FlyoutPageShop(), this);
                FlyoutPage.ListView.SelectedItem = null;
                await Navigation.PopAsync().ConfigureAwait(false);

            }else {
                var page = (Page)Activator.CreateInstance(item.TargetType);
                //page.Title = item.Title;
                Detail = new NavigationPage(page);
                IsPresented = false;

                FlyoutPage.ListView.SelectedItem = null;
            }

        }
    }
}