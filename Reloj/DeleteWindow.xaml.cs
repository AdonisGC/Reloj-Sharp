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
    /// Lógica de interacción para DeleteWindow.xaml
    /// </summary>
    public partial class DeleteWindow : Window
    {
        public DeleteWindow()
        {
            InitializeComponent();
            setListCountry();

        }

        // Configurar lista de paises
        public void setListCountry()
        {
            comboBoxEliminate.Items.Clear();
            foreach (DiferenciaHoraria item in MainWindow.dh)
            {
                comboBoxEliminate.Items.Add(item.pais);
            }
            comboBoxEliminate.SelectedIndex = 0;
        }

        private void button_Click_Eliminate(object sender, RoutedEventArgs e)
        {
            foreach (DiferenciaHoraria dh in MainWindow.dh)
            {
                if (comboBoxEliminate.SelectedItem as String == dh.pais)
                {
                    MainWindow.dh.Remove(dh);
                    break;
                }
            }
            this.Close();
        }

        private void calEliminate_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
