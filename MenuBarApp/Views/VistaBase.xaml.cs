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
using System.Windows.Shapes;

namespace MenuBarApp.Views
{
    /// <summary>
    /// Lógica de interacción para VistaBase.xaml
    /// </summary>
    public partial class VistaBase : Window
    {
        public VistaBase( UserControl vista) // le vamos a pasar por parámetros, la vista que queremos que se vea al clicar el boton
         {
            InitializeComponent();
            Contenido.Content = vista;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape) { this.Close(); } // pa cerrar la ventana con la tecla Esc y que no estén trasteando.

        }
    }
}
