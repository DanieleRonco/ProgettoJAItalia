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

namespace ProgettoPCTOApp
{
    /// <summary>
    /// Logica di interazione per FinestraRegistrazione.xaml
    /// </summary>
    public partial class FinestraRegistrazione : Window
    {
        gestioneFile registrati1;
        Utente temp;

        public FinestraRegistrazione()
        {
            InitializeComponent();
            temp = new Utente();
        }

        public FinestraRegistrazione(gestioneFile pass)
        {
            InitializeComponent();
            registrati1 = pass;
            temp = new Utente();
        }

        private void BtnCreaAcc_Click(object sender, RoutedEventArgs e)
        {

            string nome = txtNome.Text;
            string cognome = txtCognome.Text;
            string nascita = txtNascita.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string check = txtConferma.Text;
            string codice = txtFiscale.Text;

            bool viaLibera=true;

            if (password != check)
            {
                viaLibera = false;
            }

            if (viaLibera==true)
            {
                temp = new Utente(nome, cognome, nascita, email, password, codice);
                registrati1.registra(temp);
            }

        }
    }
}
