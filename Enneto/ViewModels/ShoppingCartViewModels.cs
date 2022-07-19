using Enneto.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Enneto.ViewModel
{
    public class ShoppingCartViewModels
    {
        public ObservableCollection <Carrito> Carritos { get; set; }

        public ShoppingCartViewModels()
        {
            Carritos = new ObservableCollection<Carrito>(baseDatos.Productos);
        }

    }
}

