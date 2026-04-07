using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using MenuBarApp.Models;

namespace MenuBarApp.ViewModels
{
    internal class MenuClienteViewModel
    {
        public ObservableCollection<Producto> Productos { get; set; }

        public MenuClienteViewModel()
        {
            // prueba manual de correcto funcionamiento
            Productos = new ObservableCollection<Producto>();
            Productos.Add(new Producto { Nombre = "Hamburguesa", Precio = 5.50m });
            Productos.Add(new Producto { Nombre = "Cerveza", Precio = 2.00m });
        }

    }
}
