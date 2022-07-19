using Enneto.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Enneto.ViewModels
{
    public class SliderViewModels : INotifyPropertyChanged
    {
        public IList<SliderViewItem> Data { get; set; } = new List<SliderViewItem>()
        {
            new SliderViewItem()
            {
                Title = "Bienvenido a De Segunda",
                Description = "Les desea un cordial todo el equipo que desarrollo este Sistema",
                Icon = "Bienvenidas.png",
                Step = 1,
                BackgroundColor = Xamarin.Forms.Color.FromHex("#FFFFFF")
                //BackgroundColor = Xamarin.Forms.Color.FromHex("#00BCD4")
            },
            new SliderViewItem()
            {
                Title = "Venta de Muebles",
                Description = "Aquí vendemos distintos tipos de muebles para tu hogar al igual que otros artículos interesantes. ",
                Icon = "furniture.png",
                Step = 2,
                BackgroundColor = Xamarin.Forms.Color.FromHex("#FFFFFF")
                //BackgroundColor = Xamarin.Forms.Color.FromHex("#E91E63")
            },
            new SliderViewItem()
            {
                Title = "Imágenes en cada producto",
                Description = "Cada producto cuenta con una imagen para que puedas ver como es el producto.",
                Icon = "imagen.png",
                Step = 3,
                BackgroundColor = Xamarin.Forms.Color.FromHex("#FFFFFF")
                //BackgroundColor = Xamarin.Forms.Color.FromHex("#00BCD4")
            },

            new SliderViewItem()
            {
                Title = "Productos Reparados",
                Description = "Algunos de los objetos de nuestra tienda son reparados para apoyar al medio ambiente y brindar más diversidad de artículos en nuestro catalogo.",
                Icon = "reparados.png",
                Step = 4,
                BackgroundColor = Xamarin.Forms.Color.FromHex("#FFFFFF")
                //BackgroundColor = Xamarin.Forms.Color.FromHex("#E91E63")
            },

            new SliderViewItem()
            {
                Title = "Variedad de categorías",
                Description = "Nuestro Catalogo dispone de Categorías para que puedas buscar lo que necesites.",
                Icon = "CategoriasImg.png",
                Step = 4,
                BackgroundColor = Xamarin.Forms.Color.FromHex("#FFFFFF")
                //BackgroundColor = Xamarin.Forms.Color.FromHex("#E91E63")
            },

            new SliderViewItem()
            {
                Title = "Busca tu producto",
                Description = "Implementamos un buscador para que puedas ubicar un determinado producto.",
                Icon = "BuscaArt.png",
                Step = 4,
                BackgroundColor = Xamarin.Forms.Color.FromHex("#FFFFFF")
                //BackgroundColor = Xamarin.Forms.Color.FromHex("#E91E63")
            },

            new SliderViewItem()
            {
                Title = "Paga como desees",
                Description = "Tenemos distintos métodos de pago con los que se te será más fácil poder pagarnos.",
                Icon = "pagadesees.png",
                Step = 5,
                BackgroundColor = Xamarin.Forms.Color.FromHex("#FFFFFF")
                //BackgroundColor = Xamarin.Forms.Color.FromHex("#00BCD4")
            },

            new SliderViewItem()
            {
                Title = "Historial de Compras",
                Description = "Registramos las compras que hacen dentro de nuestra tienda para que puedas tener un historial de las compras que haces.",
                Icon = "HistorialComp.png",
                Step = 5,
                BackgroundColor = Xamarin.Forms.Color.FromHex("#FFFFFF")
                //BackgroundColor = Xamarin.Forms.Color.FromHex("#00BCD4")
            },

            new SliderViewItem()
            {
                Title = "Cuenta de Usuario",
                Description = "Para que puedas comprar en nuestra tienda y también poder almacenar tus compras requieres de registrarte dentro de esta aplicación.",
                Icon = "BuscaUsu.png",
                Step = 5,
                BackgroundColor = Xamarin.Forms.Color.FromHex("#FFFFFF")
                //BackgroundColor = Xamarin.Forms.Color.FromHex("#00BCD4")
            }
        };

        public event PropertyChangedEventHandler PropertyChanged;

        public SliderViewModels()
        {
        }
    }

}
