using MenuBarApp.Models;
using MenuBarApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MenuBarApp.Views
{
    /// <summary>
    /// Lógica de interacción para CartaMenu.xaml
    /// </summary>
    public partial class CartaMenuView : UserControl
    {
        public CartaMenuView()
        {
            InitializeComponent();

            DataContext = new MenuClienteViewModel();
        }
        private void Comida_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as MenuClienteViewModel).CargarPorCategoria(Enums.CategoriaProducto.Comida);
        }

        private void Bebida_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as MenuClienteViewModel).CargarPorCategoria(Enums.CategoriaProducto.Bebida);
        }

        private void Postre_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as MenuClienteViewModel).CargarPorCategoria(Enums.CategoriaProducto.Postre);
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var producto = (sender as Button).Tag as Producto;

            (DataContext as MenuClienteViewModel).AgregarProducto(producto);
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            var linea = (sender as Button).Tag as LineaPedido;

            (DataContext as MenuClienteViewModel).QuitarProducto(linea);
        }

        private void Add_Click_Carrito(object sender, RoutedEventArgs e)
        {
            var linea = (sender as Button).Tag as LineaPedido;
            (DataContext as MenuClienteViewModel).AgregarLineaPedido(linea);
        }

    }
    
}
