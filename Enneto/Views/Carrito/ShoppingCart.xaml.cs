using Enneto.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Enneto.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PancakeView;
using System.Collections.Generic;

namespace Enneto.Views  
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShoppingCart : ContentPage
    {
        //Declarando Variables a Reutilizar
        Decimal PrecioTotal = 0.00m;


        public ShoppingCart()
        {
            InitializeComponent();
            CalculandoTotal();
            BindingContext = new ShoppingCartViewModels();
            ComprobandoArticulos(baseDatos.Productos.Count());
        }

        protected void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Aqui establecer eventos de seleccion de elemento
        }
        private void CantidadProductos_Completed(object sender, EventArgs e)
        {

            
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {

            if (baseDatos.Productos.Count == 0)
            {
                await DisplayAlert("Cuidado", "No tiene ningun producto en su Carrito", "Aceptar");
            }
            else {
                Navigation.InsertPageBefore(new Facturacion(PrecioTotal), this);
                await Navigation.PopAsync().ConfigureAwait(false);
            }
        }

        private async void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            //string oltext = e.OldTextValue;
            //var newtex = e.NewTextValue;
            var Entry = sender as Entry;

            //lets the Entry be empty
            if (string.IsNullOrEmpty(e.NewTextValue)) return;

            if (!double.TryParse(e.NewTextValue, out double value))
            {
                ((Entry)sender).Text = e.OldTextValue;
            }
            if (e.NewTextValue == "0" || e.NewTextValue == " ") {
                ((Entry)sender).Text = "1";
                await DisplayAlert("Porfavor", "Colocar un Numero Valido", "Aceptar");
            }

            CalculandoTotal();
            ComprobandoArticulos(baseDatos.Productos.Count());
            
        }

        //Agregar Producto
        async void Button_Clicked_1(object sender, EventArgs e)
        {
            var button = sender as Button;
            var productoId = Convert.ToInt32(button.CommandParameter);

            foreach (var item in baseDatos.Productos)
            {
                if(item.IdProducto == productoId)
                {
                    item.CantidaProducto += 1;
                }
            }

            BindingContext = new ShoppingCartViewModels();
            CalculandoTotal();
        }

        //Quitar Cantidad Producto
        async void Button_Clicked_2(object sender, EventArgs e)
        {
            var button = sender as Button;
            int productoId = Convert.ToInt32(button.CommandParameter);
            List<Carrito> temp = new List<Carrito>();
            bool EliminarElemento = false;

            foreach (var item in baseDatos.Productos)
            {
                if (item.IdProducto == productoId)
                {
                    if (item.CantidaProducto == 1)
                    {
                        var answer = await DisplayAlert("Cuidado", "Esta seguro de que quiere remover el producto?", "Si", "No");
                        if (answer)
                        {
                            EliminarElemento = true;
                            temp.Add(item);
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        item.CantidaProducto--;
                    }
                }
            }
            if (EliminarElemento) {
                baseDatos.Productos.RemoveAll(temp.Contains);
                foreach (var item in temp)
                {
                    baseDatos.Productos.Remove(item);
                }
            }

            BindingContext = new ShoppingCartViewModels();
            CalculandoTotal();
            ComprobandoArticulos(baseDatos.Productos.Count());
        }

        private async void RemoverProducto_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            int productoId = Convert.ToInt32(button.CommandParameter);
            List<Carrito> temp2 = new List<Carrito>();
            bool EliminarElemento = false;

            var answer = await DisplayAlert("Cuidado", "Esta seguro de que quiere remover el producto?", "Si", "No");
            if (answer)
            {
                foreach (var item in baseDatos.Productos) {
                    if (item.IdProducto == productoId)
                    {
                        EliminarElemento = true;
                        temp2.Add(item);
                    }
                }
            }else
            {
                return;
            }
            if (EliminarElemento) {
                baseDatos.Productos.RemoveAll(temp2.Contains);
                foreach (var item in temp2)
                {
                    baseDatos.Productos.Remove(item);
                }
            }

            BindingContext = new ShoppingCartViewModels();
            CalculandoTotal();
            ComprobandoArticulos(baseDatos.Productos.Count());
        }

        public void CalculandoTotal()
        {
            PrecioTotal = 0.00m;

            foreach (var item in baseDatos.Productos)
            {
                PrecioTotal += (Convert.ToDecimal(item.PrecioOferta) * Convert.ToDecimal(item.CantidaProducto));
            }

            PrecioFinal.Text = PrecioTotal.ToString();
        }
        public void ComprobandoArticulos(int CalculandoElemento) {
            if (CalculandoElemento == 0) {
                ProcesarCarro.IsEnabled = false;
            }
        }


    }
}
