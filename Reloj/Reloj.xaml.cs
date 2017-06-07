using System;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Threading;
using System.Collections.Generic;

namespace Reloj
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Mi lista
        public static List<DiferenciaHoraria> dh = new List<DiferenciaHoraria>();
 
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();

            // init hora mundial 
            DiferenciaHoraria dh1 = new DiferenciaHoraria("Cuba", 4);
            DiferenciaHoraria dh2 = new DiferenciaHoraria("España", 1);
            DiferenciaHoraria dh3 = new DiferenciaHoraria("USA", 6);
            DiferenciaHoraria dh4 = new DiferenciaHoraria("Jamaica", 5);
            DiferenciaHoraria dh5 = new DiferenciaHoraria("Puerto Rico", 6);

            // dh.Add(dh1);
            // dh.Add(dh2);
            // dh.Add(dh3);
            // dh.Add(dh4);
            // dh.Add(dh5);

            setListCountry();
            setAlarm();

        }

        // Evento que se activa cada segundo
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Monstrando la hora en la ventana
            lbReloj.Content = DateTime.Now.ToLongTimeString();


            // Monstrando la hora en la ventana
            int n = 0;
            if (comboxDiferenciaHoraria.SelectedIndex >= 0 && comboxDiferenciaHoraria.SelectedIndex < dh.Count) {
                n = dh[comboxDiferenciaHoraria.SelectedIndex].diferenciaHoraria;
                horaMundial.Content = DateTime.Now.AddHours(n).ToLongTimeString();
            }

            // Obtener las horas, minutos y segundos de la alarma
            String alarmTime = Horas.Text + ":" + Minutos.Text + ":" + Segundos.Text;
             
            // Verificar si la alarma está activada y si coincide con la hora actual
            if (enableAlarm.IsChecked == true && DateTime.Now.ToLongTimeString().Equals(alarmTime))
            {
                MessageBox.Show("BOOM!!!!!!!!!!!");
            }
        }

        // Cerrar la aplicación
        private void MenuItem_Click_Sortir(object sender, RoutedEventArgs e)
        {
            if (File.Exists("persist.bin"))
            {
                File.Delete("persist.bin");
            }

            // Creando alarma
            Alarm alarm = new Alarm(Horas.Text, Minutos.Text, Segundos.Text, enableAlarm.IsChecked.Value);

            // Haciendo persistente la alarma
            Stream FileStream = File.Create("persist.bin");
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(FileStream, alarm);
            FileStream.Close();
           
            this.Close();
        }

        // Sobre la aplicación
        private void MenuItem_Click_Ajuda(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Applicació feta amb C#");
        }

        // Método helper para configurar elemento cargado a seleccionar por defecto 
        public static void setDefaultItem(ComboBox comboBox, string item)
        {
            foreach (ComboBoxItem comboBoxItem in comboBox.Items)
            {
                if (comboBoxItem.Content as String == item)
                {
                    comboBox.SelectedItem = comboBoxItem;
                    break;
                }
            }
        }

        // Abrir pop-up hora mundial
        private void MenuItem_Click_Afegir_Rellotge(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Hola mundo");
            Window1 win2 = new Window1();
            win2.ShowDialog();
            setListCountry();
        }

        // Configurar lista de paises
        public void setListCountry()
        {
            comboxDiferenciaHoraria.Items.Clear();
            foreach ( DiferenciaHoraria item in dh)
            {
                comboxDiferenciaHoraria.Items.Add(item.pais);
            }  
            comboxDiferenciaHoraria.SelectedIndex = 0;
        }

        // Configurar alarma
        private void setAlarm()
        {
            initAlarm();

            // Cargando datos persistentes
            if (File.Exists("persist.bin"))
            {
                Stream FileStream = File.OpenRead("persist.bin");
                BinaryFormatter deserializer = new BinaryFormatter();
                Alarm alarm = (Alarm)deserializer.Deserialize(FileStream);
                FileStream.Close();

                // Utilizando función de ayuda para configurar alarma con los datos cargados.
                setDefaultItem(Horas, alarm.horas);
                setDefaultItem(Minutos, alarm.minutos);
                setDefaultItem(Segundos, alarm.segundos);
                enableAlarm.IsChecked = alarm.enable;
            }
            else
            {
                Horas.SelectedIndex = 0;
                Minutos.SelectedIndex = 0;
                Segundos.SelectedIndex = 0;
            }
        }

        private void initAlarm()
        {
            // Iniciar comboBox de horas
            for (double i = 0; i <= 23; i++)
            {
                ComboBoxItem item = new ComboBoxItem();

                // Formato dos digitos
                item.Content = i.ToString("00");
                Horas.Items.Add(item);
            }

            // Iniciar comboBox de minutos y segundos
            for (int i = 0; i <= 59; i++)
            {
                ComboBoxItem _1item = new ComboBoxItem();
                ComboBoxItem _2item = new ComboBoxItem();

                // Formato dos digitos
                _1item.Content = i.ToString("00");
                _2item.Content = i.ToString("00");

                Minutos.Items.Add(_1item);
                Segundos.Items.Add(_2item);
            }
        }

        private void MenuItem_Click_Eliminar(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Hola mundo");
            DeleteWindow win3 = new DeleteWindow();
            win3.ShowDialog();
            horaMundial.Content = "";
            setListCountry();
        }
    }
}
