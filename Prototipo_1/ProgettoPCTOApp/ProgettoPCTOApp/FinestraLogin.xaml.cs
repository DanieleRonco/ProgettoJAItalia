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
    /// Logica di interazione per FinestraLogin.xaml
    /// </summary>
    public partial class FinestraLogin : Window
    {
        gestioneFile listaRegistrati;
        Utente temp;


        private void InitializeMyControl()
        {
            txtPassword.MaxLength = 14;
        }
        public FinestraLogin()
        {

            InitializeComponent();
            InitializeMyControl();


        }
        public FinestraLogin(gestioneFile pass)
        {

            InitializeComponent();

            listaRegistrati = pass;


        }

        private void BtnAccedi_Click(object sender, RoutedEventArgs e)
        {
            string id = txtNome.Text;

            string cognometxt = txtCognome.Text;
            string cognome = "";
   


            for (int i = 0; i <= cognometxt.Length; i++)
            {
                if (i == 0)
                {
                    cognome = cognome + cognome.Substring(0, 1).ToUpper();

                }
                else
                {
                    cognome = cognome + cognome.Substring(i, 1).ToLower();

                }
            }

            string password = txtPassword.Password.ToString();

            Utente u = new Utente("", cognome, "", "", password, id, 0.0f, null);

            if (listaRegistrati.isResistrato(u) == true)
            {
                temp = listaRegistrati.getUtente(u);

                FinestraAreaRiservata finestra = new FinestraAreaRiservata(temp, listaRegistrati);
                finestra.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("non sei registrato, torna alla schermata principale e registrati");
            }








        }
    }
}
