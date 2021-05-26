using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Globalization;
using System.Linq;
using System.IO.Ports;
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
using System.Runtime;

namespace ProgettoPCTOApp
{
    public partial class FinestraAreaRiservata : Window
    {
        DispatcherTimer timer;
        gestioneFile g;
        Utente u;
        string tariffa;

        SerialPort com;

        int indice;
        float costo;
        float saldo;
        Biglietto b;
        public FinestraAreaRiservata(Utente temp, gestioneFile listaRegistrati)
        {
            com = new SerialPort("COM3", 9600);
            try { com.Open(); } catch { };

            u = temp;
            g = listaRegistrati;
            InitializeComponent();
            lblUtente.Content = u.getCognome() + " " + u.getNome();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
            b= u.getBiglietto();
            tariffa= b.getTariffa();
            indice = b.getIndice();
            if (b.getTariffa() == "s")
            {
                lblTariffa.Content = "Settimanale";
                lblIndice.Content = indice.ToString();
            }
            else if (b.getTariffa() == "g")
            {
                lblTariffa.Content = "Giornaliero";
                lblIndice.Content = indice.ToString();
            }
            else if (b.getTariffa() == "m")
            {
                lblTariffa.Content = "Mensile";
                lblIndice.Content = indice.ToString();
            }
            else {

                lblTariffa.Content = "NESSUNO";
                lblIndice.Content = "NESSUNO";
            }
            lblIndice.Content = indice.ToString();
            lblSaldo.Content = u.getSaldo().ToString() + " €";
            saldo = u.getSaldo();
            cmbTariffa.Items.Add("Giornaliero");
            cmbTariffa.Items.Add("Settimanale");
            cmbTariffa.Items.Add("Mensile");
        }

        private int GetWeekNumber(DateTime date)
        {
            System.Globalization.Calendar calendar = System.Threading.Thread.CurrentThread.CurrentCulture.Calendar;
            System.Globalization.DateTimeFormatInfo dateTimeFormat = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat;

            return calendar.GetWeekOfYear(date, dateTimeFormat.CalendarWeekRule, dateTimeFormat.FirstDayOfWeek);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            lblTime.Content = DateTime.Now.ToLongTimeString();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow(g);
            main.Show();
            this.Hide();
        }

        private void btnCompra_Click(object sender, RoutedEventArgs e)
        {
            if (costo > saldo) {
                MessageBox.Show("Non hai abbastanza credito!");
                return;
            }

            saldo = saldo - costo;
            b.setBiglietto(tariffa,indice);
            u.aggiornaUtente(saldo, b);
            SaveFileDialog saveFileDialog = new SaveFileDialog();
           
            g.Salva();
            b = u.getBiglietto();
            tariffa = b.getTariffa();
            indice = b.getIndice();
            if (b.getTariffa() == "s")
            {
                lblTariffa.Content = "Settimanale";
                lblIndice.Content = indice.ToString();
              
            }
            else if (b.getTariffa() == "g")
            {
                lblTariffa.Content = "Giornaliero";
                lblIndice.Content = indice.ToString();
            }
            else if (b.getTariffa() == "m")
            {
                lblTariffa.Content = "Mensile";
                lblIndice.Content = indice.ToString();
            }
            else
            {
                lblTariffa.Content = "NESSUNO";
                lblIndice.Content = "NESSUNO";
            }
            lblIndice.Content = indice.ToString();
            lblSaldo.Content = u.getSaldo().ToString() + " €";
            saldo = u.getSaldo();
            com.Write(u.ToCsvBiglietto());
        }

        private void CmbTariffa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbTariffa.SelectedIndex == 0) {
                indice = DateTime.Now.Day;
              
                lblCosto.Content = "2 €";
                costo = 2;
                tariffa = "g";
            }
            if (cmbTariffa.SelectedIndex == 1)
            {
                indice = GetWeekNumber(DateTime.Now.Date);
                lblCosto.Content = "15 €";
                costo = 15;
                tariffa = "s";
            }
            if (cmbTariffa.SelectedIndex == 2)
            {
                indice = DateTime.Now.Month;
                lblCosto.Content = "40 €";
                costo = 40;
                tariffa = "m";
            }
          
            btnCompra.IsEnabled = true;
        }   
    }
}