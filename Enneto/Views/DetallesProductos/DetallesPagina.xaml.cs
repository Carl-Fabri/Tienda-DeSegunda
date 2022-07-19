using Enneto.Models;
using Enneto.Views;
using Enneto.Views.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Enneto
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]

    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class DetallesPagina : ContentPage
    {
        private Producto producto;
        public string ItemId
        {
            set
            {
                LoadProducto();
            }
        }
        public DetallesPagina(Producto producto)
        {
            this.producto = producto;
            LoadProducto();
            InitializeComponent();
            IconosToolbar();
            CalcularPrecio();
        }
        private async void Carrito_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ShoppingCart());
        }

        private async void IniciarSesion_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginUser());
        }


        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            AgregandoAlCarrito();
        }

        //Metodos
        void LoadProducto()
        {
            try
            {
                BindingContext = this.producto;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load note.");
            }
        }

        void CalcularPrecio()
        {
            if (producto.Oferta == 0.0)
            {
                Oferta.Text = Convert.ToString(producto.Precio);
                Precio.Text = null;
                TipoPrecio.Text = null;
            }
            else
            {
                Oferta.Text = Convert.ToString(producto.Oferta);
                Precio.Text = Convert.ToString(producto.Precio);
            }
        }

        public async void AgregandoAlCarrito()
        {
            if (baseDatos.EstaAutenticado)
            {
                AgregandoCarrito(producto);
                await DisplayAlert("Bien Hecho", "Acabas de Agregar un producto a tu compra", "OK");
            }
            else
            {
                await Navigation.PushAsync(new LoginUser());
            }
        }

        public void AgregandoCarrito(Producto AgregandoElemento)
        {
            if (baseDatos.Productos == null)
            {
                baseDatos.Productos = new List<Carrito>();
            }

            bool ExistenciaProducto = false;
            for (int contador = 0; contador < baseDatos.Productos.Count; contador++)
            {
                if (AgregandoElemento.id == baseDatos.Productos[contador].IdProducto)
                {
                    baseDatos.Productos[contador].CantidaProducto++;
                    ExistenciaProducto = true;
                    break;
                }
            }
            if (ExistenciaProducto != true)
            {
                baseDatos.Productos.Add(new Models.Carrito
                {
                    IdProducto = AgregandoElemento.id,
                    NombreProducto = AgregandoElemento.NombreProducto,
                    ImagenProducto = AgregandoElemento.Imagen,
                    CantidaProducto = 1,
                    Precio = Convert.ToDecimal(AgregandoElemento.Precio),
                    HayOferta = true,
                    PrecioOferta = Convert.ToDecimal(AgregandoElemento.Oferta),
                });
            }
        }
        public void IconosToolbar()
        {

            if (baseDatos.EstaAutenticado)
            {
                IniciarSesion.IsEnabled = false;
                IniciarSesion.IconImageSource = "";
                IniciarSesion.Priority = 0;
                Carrito.Priority = 1;
            }
            else
            {
                Carrito.IsEnabled = false;
                Carrito.IconImageSource = "";
                Carrito.Priority = 0;
                IniciarSesion.Priority = 0;
            }
        }


    }
}