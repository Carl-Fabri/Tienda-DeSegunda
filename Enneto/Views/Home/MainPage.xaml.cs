using Enneto.Models;
using Enneto.Views;
using Enneto.Views.Login;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Enneto.ViewModel;

namespace Enneto
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        //public List<Producto> PrimeraLista = new List<Producto>();
        public Producto ProductoSeleccionado { get; set; }
        public List<Producto> TerceraSeccion = new List<Producto>();
        public List<Producto> SeccionPresentacion = new List<Producto>();
        public MainPage()
        {
            InitializeComponent();
            IconosToolbar();
            BindingContext = new MainViewModel();
            InstanciandoPresentacion();
            InstanciandoPrimeraCategoria();
            InstanciandoSegundaSección();
        }

        //Toolbar

        //Evento de Carrito
        private async void Carrito_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ShoppingCart());
        }
        //Evento de Iniciar Sesión
        private async void IniciarSesion_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginUser());
        }

        //Elementos Content
        //Carrousel 1

        //Redirecciona a Detalles 
        public async void ImageButton_Clicked(object sender, EventArgs e)
        {
            var button = sender as ImageButton;
            var model = this.BindingContext as MainViewModel;
            var producto = model.producto.FirstOrDefault(p => p.id == Convert.ToInt32(button.CommandParameter));
            await Navigation.PushAsync(new DetallesPagina(producto));
        }

        //Boton de Carrito
        private void ImageButton_Clicked_2(object sender, EventArgs e)
        {
            var button = sender as ImageButton;
            var model = this.BindingContext as MainViewModel;
            var producto = model.producto.FirstOrDefault(p => p.id == Convert.ToInt32(button.CommandParameter));
            AgregandoAlCarrito(producto);
        }

        //Evento que se ejecuta cuando se cambia de carrousel
        public void Complemento_CurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
        {
        }

        ///////Categorias
        
        //Redierecciona a Categorias
        private async void ImageButton_Clicked_1(object sender, EventArgs e)
        {
            var button = sender as ImageButton;
            int IdCategoriaSeleccionada = Convert.ToInt32(button.CommandParameter);
            var model = this.BindingContext as MainViewModel;
            var categoriaseleccionada = model.categoria.FirstOrDefault(c => c.idCategoria == Convert.ToInt32(button.CommandParameter));
            string NombreCategoria = categoriaseleccionada.NombreCategoria;
            //string ImagenCategoria = categoriaseleccionada.ImagenCategoria;

            await Navigation.PushAsync(new CategoriasPage(NombreCategoria,IdCategoriaSeleccionada));
        }

        /////Carrousel 2
        //Instanciando Contenido 2 seccion
        private async void Producto2_Clicked(object sender, EventArgs e)
        {
            var button = sender as ImageButton;
            var model = this.BindingContext as MainViewModel;
            var producto = model.producto.FirstOrDefault(p => p.id == Convert.ToInt32(button.CommandParameter));
            await Navigation.PushAsync(new DetallesPagina(producto));
        }

        private void Carrito2_Clicked(object sender, EventArgs e)
        {
            var button = sender as ImageButton;
            var model = this.BindingContext as MainViewModel;
            var producto = model.producto.FirstOrDefault(p => p.id == Convert.ToInt32(button.CommandParameter));
            AgregandoAlCarrito(producto);
            //await Navigation.PushAsync(new ShoppingCart());
        }

        //Evento que se ejecuta cuando se cambia de carrousel
        private void Complemento2_CurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
        {
        }

        private async void ImageButton_Clicked_3(object sender, EventArgs e)
        {
            var button = sender as ImageButton;
            int IdCategoriaSeleccionada = Convert.ToInt32(button.CommandParameter);
            var model = BindingContext as MainViewModel;
            var categoriaseleccionada = model.categoria.FirstOrDefault(c => c.idCategoria == Convert.ToInt32(button.CommandParameter));
            string NombreCategoria = categoriaseleccionada.NombreCategoria;
            //string ImagenCategoria = categoriaseleccionada.ImagenCategoria;

            await Navigation.PushAsync(new CategoriasPage(NombreCategoria, IdCategoriaSeleccionada));
        }

        //Elementos
        private void BotonCarrito_Clicked(object sender, EventArgs e)
        {
            var button = sender as ImageButton;
            var model = this.BindingContext as MainViewModel;
            var producto = model.producto.FirstOrDefault(p => p.id == Convert.ToInt32(button.CommandParameter));
            AgregandoAlCarrito(producto);
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

        //Metodos

        //Metodo para comprobar la existencia del producto en el carrito
        public void ProcesandoCarrito(Producto AgregandoElemento)
        {
            if (baseDatos.Productos == null)
            {
                baseDatos.Productos = new List<Carrito>();
            }

            bool ExistenciaProducto = false;
            for (int contador = 0; contador < baseDatos.Productos.Count; contador++ )
            {
                if (AgregandoElemento.id == baseDatos.Productos[contador].IdProducto)
                {
                    baseDatos.Productos[contador].CantidaProducto++;
                    ExistenciaProducto = true;
                    break;
                }   
            }
            if (ExistenciaProducto != true) {
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

        public async void AgregandoAlCarrito(Producto productoSeleccionado) {
            if (baseDatos.EstaAutenticado) 
            {
                ProcesandoCarrito(productoSeleccionado);
                await DisplayAlert("Bien Hecho", "Acabas de Agregar un producto a tu compra", "OK");
            }
            else {
                await Navigation.PushAsync(new LoginUser());
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
                IniciarSesion.Priority = 1;
            }
        }

        public void InstanciandoPresentacion()
        {
            var model = BindingContext as MainViewModel;
            var Seccion = model.producto;
            List<int> listaenteros = new List<int>();
            Random random = new Random();
            int PosiciomSeleccionada = 0;

            //for (int i = 0; i < 5;)
            //{
            //    PosiciomCategoria = random.Next(1, 5);
            //    if (!listacategorias.Any(num => num == PosiciomCategoria))
            //    {
            //        i++;
            //        var CategoriaProductos = Seccion.Where(e => e.idCategoria == PosiciomCategoria);
            //        var ProductoProducto = CategoriaProductos.FirstOrDefault(e => e.idCategoria == PosiciomCategoria);
            //        SeccionPresentacion.Add(ProductoProducto);
            //        listacategorias.Add(PosiciomCategoria);
            //    }
            //    else
            //    {
            //    }
            //}
            for (int i = 0; i < 5;)
            {
                PosiciomSeleccionada = random.Next(0, Seccion.Count());
                if (!listaenteros.Any(num => num == PosiciomSeleccionada) && (PosiciomSeleccionada != 65))
                {
                    listaenteros.Add(PosiciomSeleccionada);
                    SeccionPresentacion.Add(Seccion[PosiciomSeleccionada]);
                    i++;
                }
                else
                {
                }
            }
            Complemento.ItemsSource = SeccionPresentacion;
        }

        public void InstanciandoPrimeraCategoria()
        {
            var model = BindingContext as MainViewModel;
            var valor = new Random();
            int IdCategoriaRandom = valor.Next(1, 5);

            var NombreCategoria= model.categoria.FirstOrDefault(c => c.idCategoria == IdCategoriaRandom);
            var CategoriaProductos = model.producto.Where(e => e.idCategoria == IdCategoriaRandom);

            TituloPrimeraSeccion.Text = NombreCategoria.NombreCategoria;
            Complemento2.ItemsSource = CategoriaProductos;
        }

        public void InstanciandoSegundaSección()
        {
            //TerceraSeccion
            var model = BindingContext as MainViewModel;
            var Seccion = model.producto;
            Random random = new Random();
            List<int> listaenteros = new List<int>();
            int numero = 0;
            for (int i = 0; i < 10;)
            {
                numero = random.Next(0, Seccion.Count());
                if (!listaenteros.Any(num => num == numero) && (numero != 65))
                {
                    listaenteros.Add(numero);
                    TerceraSeccion.Add(Seccion[numero]);
                    i++;
                }
                else {
                    //if (Seccion.Any(num => num.id.numero))
                    //{
                    //    TerceraSeccion.Add(Seccion[numero]);
                    //}
                    //else { 
                    //}
                }
            }
            ListaColeccion.ItemsSource = TerceraSeccion;
        }
    }
}
