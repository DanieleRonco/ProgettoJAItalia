﻿using Microsoft.Win32;
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
            lblTariffa.Content = tariffa;
            lblIndice.Content = indice.ToString();
            lblSaldo.Content = u.getSaldo().ToString() + " €";
            saldo = u.getSaldo();
            cmbTariffa.Items.Add("Giornaliero");
            cmbTariffa.Items.Add("Settimanale");
            cmbTariffa.Items.Add("Mensile");


            if (cmbTariffa.Text == "Giornaliero")
            {
                tariffa = "g";
            }
            if (cmbTariffa.Text == "Settimanale")
            {
                tariffa = "s";
            }
            if (cmbTariffa.Text == "Mensile")
            {
                tariffa = "m";

            }


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

        }

        private void CmbTariffa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbTariffa.Text == "Giornaliero") {

                lblCosto.Content = "2 €";
                costo = 2;
            }
            if (cmbTariffa.Text == "Settimanale")
            {

                lblCosto.Content = "15 €";
                costo = 15;
            }
            if (cmbTariffa.Text == "Mensile")
            {

                lblCosto.Content = "40 €";
                costo = 40;
            }

        }
    }
}
