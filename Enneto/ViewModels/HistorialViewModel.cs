using Enneto.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Enneto.ViewModels
{
    public class HistorialViewModel
    {
        public ObservableCollection<HistorialDeCompras> Historial { get; set; }

        public HistorialViewModel()
        {
            Historial = new ObservableCollection<HistorialDeCompras>(baseDatos.Carritos);
        }
    }
}
