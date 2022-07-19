using Enneto.Views.HistorialCompras;
using Enneto.Views.Login;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Enneto.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlyoutPageShopFlyout : ContentPage
    {
        public ListView ListView;

        public FlyoutPageShopFlyout()
        {
            InitializeComponent();
            BindingContext = new FlyoutPageShopFlyoutViewModel();
            InstanciandoUsuario();
            ListView = MenuItemsListView;
            NavigationPage.SetHasNavigationBar(this, false);     
        }

        class FlyoutPageShopFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<FlyoutPageShopFlyoutMenuItem> MenuItems { get; set; }

            //Menus Mostrables
            public FlyoutPageShopFlyoutViewModel()
            {

                if (baseDatos.EstaAutenticado)
                {
                    MenuItems = new ObservableCollection<FlyoutPageShopFlyoutMenuItem>(new[]
                {
                    new FlyoutPageShopFlyoutMenuItem { Id = 0, Title = "Inicio", TargetType = typeof(MainPage),Icon="hogar.png"},
                    new FlyoutPageShopFlyoutMenuItem { Id = 1, Title = "Carrito", TargetType = typeof(ShoppingCart),Icon="carritoblack.png" },
                    new FlyoutPageShopFlyoutMenuItem { Id = 2, Title = "Historial de Compras",TargetType= typeof(Historial), Icon="bolsablack.png" },
                    new FlyoutPageShopFlyoutMenuItem { Id = 3, Title = "Cerrar Sesion",TargetType= typeof(FlyoutPage),Icon="flechablack.png" },
                });
                }
                else {
                    MenuItems = new ObservableCollection<FlyoutPageShopFlyoutMenuItem>(new[]
                {
                    new FlyoutPageShopFlyoutMenuItem { Id = 0, Title = "Inicio", TargetType = typeof(MainPage), Icon = "hogar.png" },
                    new FlyoutPageShopFlyoutMenuItem { Id = 1, Title = "Iniciar Sesion", TargetType = typeof(LoginUser), Icon = "Iniciar.png" },
                    new FlyoutPageShopFlyoutMenuItem { Id = 2, Title = "Registrarse", TargetType = typeof(Register), Icon = "Registrar.png" },
                });
                }
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }

        public void InstanciandoUsuario()
        {
            NombrePerfiltxt.Text = baseDatos.Perfil.FirstName;
            Correotxt.Text = baseDatos.Perfil.Username;
            FotoPerfil.Source = baseDatos.Perfil.Avatar;
        }

    }
}