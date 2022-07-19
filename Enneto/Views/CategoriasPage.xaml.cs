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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoriasPage : ContentPage
    {
        public Producto ProductoSeleccionado { get; set; }
        public List<Producto> ProductosFiltrados = new List<Producto>();
        public CategoriasPage(string NombreCategoria, int IdCategoriaSeleccionada)
        {
            InitializeComponent();
            IconosToolbar();
            LoadProducto(IdCategoriaSeleccionada);
            Titulo.Text = NombreCategoria;
            BindingContext = new MainViewModel();
        }

        //Toolbar

        private async void Carrito_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ShoppingCart());
        }

        //Elementos Content

        private async void IniciarSesion_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginUser());
        }

        async void ListaColeccion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var Elemento = e.CurrentSelection.FirstOrDefault() as Producto;
            if (Elemento == null)
                return;
            ProductoSeleccionado = Elemento;
            await Navigation.PushAsync(new DetallesPagina(ProductoSeleccionado));
            ListaColeccion.SelectedItem = null;
        }

        //Buscador
        private void BotonCarrito_Clicked(object sender, EventArgs e)
        {

            var button = sender as ImageButton;
            var model = this.BindingContext as MainViewModel;
            var producto = model.producto.FirstOrDefault(p => p.id == Convert.ToInt32(button.CommandParameter));
            AgregandoAlCarrito(producto);
        }

        //Metodos

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
                IniciarSesion.Priority = 1;
            }
        }
        void LoadProducto(int IdCategoriaSeleccionada)
        {
            var model = BindingContext as MainViewModel;
            var Categoria = model.producto.Where(e => e.idCategoria == IdCategoriaSeleccionada);

            foreach (var items in Categoria) {
                ProductosFiltrados.Add(items);
            }
            ListaColeccion.ItemsSource = ProductosFiltrados;
        }

        void BuscandoElementos(string NombreElemento)
        {
            if (string.IsNullOrWhiteSpace(NombreElemento))
            {
                ListaColeccion.ItemsSource = ProductosFiltrados;
            }
            //EasteEgg
            else if (NombreElemento == "trikitrakatelas") {
                
                var model = this.BindingContext as MainViewModel;
                var ElemetoBuscados = model.producto.Where(e => e.id == 65);
                ListaColeccion.ItemsSource = ElemetoBuscados;
            }

            else
            {
                var ElemetoBuscados = ProductosFiltrados.Where(e => e.NombreProducto.Contains(NombreElemento));
                ListaColeccion.ItemsSource = ElemetoBuscados;
            }

        }

        private void Buscador_TextChanged(object sender, TextChangedEventArgs e)
        {
            BuscandoElementos(e.NewTextValue);
        }

        //Carrito
        public async void AgregandoAlCarrito(Producto productoSeleccionado)
        {
            if (baseDatos.EstaAutenticado)
            {
                ProcesandoCarrito(productoSeleccionado);
                await DisplayAlert("Bien Hecho", "Acabas de Agregar un producto a tu compra", "OK");
            }
            else
            {
                await Navigation.PushAsync(new LoginUser());
            }
        }

        public void ProcesandoCarrito(Producto AgregandoElemento)
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


    }
}