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
        private void InitializeMyControl()
        {
            
            txtPassword.MaxLength = 14;
        }

        public FinestraRegistrazione()
        {
            InitializeComponent();
            InitializeMyControl();
            temp = new Utente();
        }

        public FinestraRegistrazione(gestioneFile pass)
        {
            InitializeComponent();
            InitializeMyControl();
            registrati1 = pass;
            temp = new Utente();
        }

        private void BtnCreaAcc_Click(object sender, RoutedEventArgs e)
        {

            string nome = txtNome.Text;

            string cognome = txtCognome.Text;
            string nascita = txtNascita.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Password.ToString();
            string check = txtConferma.Password.ToString();
            string codice = txtFiscale.Text;

            bool viaLibera=true;

            if (password != check)
            {
                viaLibera = false;
            }

            if (viaLibera==true)
            {
                temp = new Utente(nome, cognome, nascita, email, password, codice,null);
                registrati1.registra(temp);
                MessageBox.Show("Registrato correttamente!");
                txtCognome.Text = "";
                txtConferma.Clear();
                txtEmail.Text = "";
                txtFiscale.Text = "";
                txtNascita.Text = "";
                txtNome.Text = "";
                txtPassword.Clear();

                registrati1.Salva();

            }else
            {
                MessageBox.Show("Le password non coincidono!");
            }

        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main= new MainWindow(registrati1);
            main.Show();
            this.Hide();
        }
    }
}
