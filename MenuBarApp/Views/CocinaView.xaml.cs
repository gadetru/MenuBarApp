using MenuBarApp.ViewModels;
using System.Windows.Controls;

namespace MenuBarApp.Views
{
    public partial class CocinaView : UserControl
    {
        public CocinaView()
        {
            InitializeComponent();
            DataContext = new CocinaViewModel();
        }
    }
}