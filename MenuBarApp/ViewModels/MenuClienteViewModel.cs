using MenuBarApp.Models;
using MenuBarApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MenuBarApp.ViewModels
{
    internal class MenuClienteViewModel : INotifyPropertyChanged // heredamos esta interfaz para que la UI note los cambios
    {
        private ObservableCollection<Producto> productos;

        
        public ObservableCollection<Producto> Productos
        {
            get => productos;
            set
            {
                productos = value;
                OnPropertyChanged(); // aquí notificamos de cambios a la UI cuando se setee el campo productos.
            }
        }

        public ObservableCollection<LineaPedido> Carrito { get; set; } = new();  // aquí la lista de lo que voy a pedir pa come.

        public decimal Total => Carrito.Sum(x => x.Producto.Precio * x.Cantidad);  // propiedad para calcular el total de la cuenta.

        private ProductoService misProductos;

        public MenuClienteViewModel()
        {
            misProductos = new ProductoService();
            
        }

        private void CargarProductos()
        {
            var lista = misProductos.ObtenerProductos();
            Productos = new ObservableCollection<Producto>(lista);
        }

        public void CargarPorCategoria(Enums.CategoriaProducto categoria)
        {
            var lista = misProductos.ObtenerPorCategoria(categoria);
            Productos = new ObservableCollection<Producto>(lista);
        }


        //************* un cambio, una funcioncita para que sean los productos del carro los que tengan la opcion pa quitar y agregar más productos de un tipo.************

        public void AgregarLineaPedido(LineaPedido linea)
        {
            AgregarProducto(linea.Producto);
            OnPropertyChanged(nameof(Total)); // pa que actualice el precio.
        }

        //************** logica para el carrito de productos para pedidos ******************
        public void AgregarProducto(Producto Producto)
        {
            var linea = Carrito.FirstOrDefault(x => x.Producto.IdProducto == Producto.IdProducto);
            
            if(linea == null)
            {
                Carrito.Add(new LineaPedido { Producto = Producto, Cantidad = 1 });
            }
            else
            {
                linea.Cantidad++;
            }
            OnPropertyChanged(nameof(Total));

        }
        public void QuitarProducto(LineaPedido linea)
        {
            
            if(linea != null)
            {
                linea.Cantidad--;
                if(linea.Cantidad <= 0)
                {
                    Carrito.Remove(linea);
                }
            }
            OnPropertyChanged(nameof(Total));
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string nombre = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }

        
    }
}
