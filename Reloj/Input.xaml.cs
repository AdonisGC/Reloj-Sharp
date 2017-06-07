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

namespace Reloj
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void closeInput(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void addHora(object sender, RoutedEventArgs e)
        {
            MainWindow.dh.Add(new DiferenciaHoraria(txt_pais.Text, Int32.Parse(txt_horas.Text)));
            this.Close();
        }
    }
}
