using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using MenuBarApp.Models;
using MenuBarApp.Services;

namespace MenuBarApp.ViewModels
{
    internal class MenuClienteViewModel
    {
        public ObservableCollection<Producto> Productos { get; set; }

        private ProductoService misProductos;

        public MenuClienteViewModel()
        {
            misProductos = new ProductoService();

            misProductos.InsertarProducto(new Producto
            {
                Nombre = "Pizza",
                Precio = 7.50m,
                Categoria = Enums.CategoriaProducto.Comida
            });

            //Productos = new ObservableCollection<Producto>(lista);

            

            //var lista = misProductos.ObtenerProductos();

       
     
        }


  
        

    }
}
