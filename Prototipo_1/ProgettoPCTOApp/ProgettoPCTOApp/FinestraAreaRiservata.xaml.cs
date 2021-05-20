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
        string tariffa;
        int indice;
        float costo;
        float saldo;
        Biglietto b;
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
            if (saveFileDialog.ShowDialog() == true)
            { g.set_nome_file(saveFileDialog.FileName);
                g.Salva(); }
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
