using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
using System.Windows.Threading;

namespace ProgettoPCTOApp
{
   

    public partial class FinestraAreaRiservata : Window
    {
        DispatcherTimer timer;
        gestioneFile g;
        Utente u;

        public FinestraAreaRiservata(Utente temp, gestioneFile listaRegistrati)
        {
            u = temp;
            g = listaRegistrati;
            InitializeComponent();
            lblUtente.Content = u.getCognome() + " " + u.getNome();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();

        }


        void timer_Tick(object sender, EventArgs e)
        {
            lblTime.Content = DateTime.Now.ToLongTimeString();
   
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Hide();
        }
    }
}
