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
    /// Lógica de interacción para MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void BtnCliente_Click(object sender, RoutedEventArgs e)
        {
            new VistaBase(new CartaMenuView()).ShowDialog();
        }

        private void BtnCocina_Click(object sender, RoutedEventArgs e)
        {
            new VistaBase(new CocinaView()).ShowDialog();
        }

        private void BtnBarra_Click(object sender, RoutedEventArgs e)
        {
            new VistaBase(new BarraView()).ShowDialog(); // con showDialog, queda el main bloqueado detrás hasta cerrar la vista que levantemos
        }
    }
}
