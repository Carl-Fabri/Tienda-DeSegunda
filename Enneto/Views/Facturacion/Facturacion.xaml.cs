using Enneto.Views.Pagos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Enneto.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Facturacion : ContentPage
    {
        public Facturacion(decimal CantidadAPagar)
        {
            InitializeComponent();
            PagoFinal.Text = Convert.ToString(CantidadAPagar);
        }

        //Redirecciones
        private async void Carrito_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ShoppingCart(),true);

        }

        //Eventos
        private async void YapePago_Clicked(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(PrimeraDireccion.Text) && !string.IsNullOrEmpty(SegundaDireccion.Text))
            {
                ProcesandoCarrito();
                await Navigation.PushModalAsync(new PagoConYape());
            }
            else {
                await DisplayAlert("Aviso", "Rellena los campos de Direccion Porfavor", "OK");
                return;
            }
        }

        private async void AgoraPago_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(PrimeraDireccion.Text) && !string.IsNullOrEmpty(SegundaDireccion.Text))
            {
                ProcesandoCarrito();
                await Navigation.PushModalAsync(new PagoConAgora());
            }
            else
            {
                await DisplayAlert("Aviso", "Rellena los campos de Direccion Porfavor", "OK");
                return;
            }
        }

        private async void PlinPago_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(PrimeraDireccion.Text) && !string.IsNullOrEmpty(SegundaDireccion.Text))
            {
                ProcesandoCarrito();
                await Navigation.PushModalAsync(new PagoConPlin());
            }
            else
            {
                await DisplayAlert("Aviso", "Rellena los campos de Direccion Porfavor", "OK");
                return;
            }
        }

        //METODOS

        //Metodo que devolvera el Total a Pagar
        public decimal PrecioAPagar(decimal PrecioOferta, decimal PrecioNormal, int Cantidad)
        {
            if (PrecioOferta == 0)
            {
                decimal PrecioPago = PrecioNormal * Cantidad;
                return PrecioPago;
            }
            else
            {
                decimal PrecioPago = PrecioOferta * Cantidad;
                return PrecioPago;
            }
        }

        //Metodos
        public void ProcesandoCarrito()
        {
            int idActualCarrito = baseDatos.Carritos.Count();
            for (int contador = 0; contador < baseDatos.Productos.Count(); contador++)
            {
                baseDatos.Carritos.Add(new Models.HistorialDeCompras
                {
                    IdCarrito = idActualCarrito,
                    NombreProducto = baseDatos.Productos[contador].NombreProducto,
                    Direccion1 = PrimeraDireccion.Text,
                    Direccion2 = SegundaDireccion.Text,
                    Direccion3 = TerceraDireccion.Text,
                    Cantidad = baseDatos.Productos[contador].CantidaProducto,
                    PrecioFinal = PrecioAPagar(baseDatos.Productos[contador].PrecioOferta, baseDatos.Productos[contador].PrecioOferta, baseDatos.Productos[contador].CantidaProducto),
                    Fecha = DateTime.Today
                });
            }
            baseDatos.Productos.Clear();
        }

    }
}