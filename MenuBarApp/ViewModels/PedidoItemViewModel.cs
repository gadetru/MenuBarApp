using MenuBarApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MenuBarApp.ViewModels
{
    // esta clase va a ser auxiliar para hacer un checkeo de los productos completados en la cocina sin tener que persistir en la base de datos.
    public class PedidoItemViewModel : INotifyPropertyChanged
    {
        // El pedido real con todos sus datos
        public Pedido Pedido { get; set; }

        // Lista de productos del pedido, cada uno con su checkbox
        public ObservableCollection<DetallePedidoItemViewModel> Detalles { get; set; }

        // Esto calcula si todos los checkboxes están marcados
        // Lo usaremos para habilitar o deshabilitar el botón de completado

        //public bool TodosListos
        //{
        //    get
        //    {
        //        foreach (DetallePedidoItemViewModel detalle in Detalles)
        //        {
        //            if (detalle.EstaListo == false)
        //            {
        //                return false;
        //            }
        //        }
        //        return true;
        //    }
        //}

        // queda más siple así, solo hay que entenderlo bien
        public bool TodosListos => Detalles.All(d => d.EstaListo);

        public PedidoItemViewModel(Pedido pedido)
        {
            Pedido = pedido;

            // Convertimos cada DetallePedido en un DetallePedidoItemViewModel
            Detalles = new ObservableCollection<DetallePedidoItemViewModel>();

            foreach (DetallePedido detalle in pedido.Detalles)
            {
                DetallePedidoItemViewModel item = new DetallePedidoItemViewModel(detalle);

                // Cuando cambie un checkbox, recalculamos TodosListos
                item.PropertyChanged += (sender, e) =>
                {
                    if (e.PropertyName == nameof(DetallePedidoItemViewModel.EstaListo))
                    {
                        OnPropertyChanged(nameof(TodosListos));
                    }
                };

                Detalles.Add(item);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? nombre = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
    }

    // Clase que representa un producto dentro del pedido con su checkbox
    public class DetallePedidoItemViewModel : INotifyPropertyChanged
    {
        // El detalle real con el producto y la cantidad
        public DetallePedido Detalle { get; set; }

        // El checkbox — cuando cambia avisa a la UI
        private bool _estaListo = false;
        public bool EstaListo
        {
            get => _estaListo;
            set
            {
                _estaListo = value;
                OnPropertyChanged();
            }
        }

        public DetallePedidoItemViewModel(DetallePedido detalle)
        {
            Detalle = detalle;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? nombre = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
    }
}
