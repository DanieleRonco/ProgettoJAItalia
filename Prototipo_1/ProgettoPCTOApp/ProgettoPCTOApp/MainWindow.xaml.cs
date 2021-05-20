using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProgettoPCTOApp
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        gestioneFile registrati;

        public MainWindow()
        {
            registrati = new gestioneFile();
            InitializeComponent();
            Biglietto temp = new Biglietto("m", 12);
            Utente utente1 = new Utente("Riccardo", "Camagni", " 18 / 29 / 0000", "miamael @gmail.com", "password", "123456", 10, temp);
            registrati.registra(utente1);

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                registrati.set_nome_file(openFileDialog.FileName);
                registrati.Salva();
                registrati.Carica();


            }

            
     
        }
        public MainWindow(gestioneFile gf)
        {
            registrati = gf;
            InitializeComponent();
        }

        private void BtnRegistrazione_Click(object sender, RoutedEventArgs e)
        {
            FinestraRegistrazione finestra = new FinestraRegistrazione(registrati);
            finestra.Show();
            this.Hide();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            FinestraLogin finestra = new FinestraLogin(registrati);
            finestra.Show();
            this.Hide();
        }
    }
}
