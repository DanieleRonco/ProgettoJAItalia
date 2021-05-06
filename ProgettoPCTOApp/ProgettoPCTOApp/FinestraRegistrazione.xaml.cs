﻿using System;
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

            string nometxt = txtNome.Text;

            string cognometxt = txtCognome.Text;
            string nome = "";
            string cognome = "";
            string nascita = txtNascita.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Password.ToString();
            string check = txtConferma.Password.ToString();
            string codice = txtFiscale.Text;
            
            for (int i = 0; i < nometxt.Length; i++)
            {
                if (i == 0)
                {
                    nome = nome + nometxt.Substring(0, 1).ToUpper();

                }
                else
                {
                    nome = nome + nometxt.Substring(i, 1).ToLower();

                }
            }
            for (int i = 0; i < cognometxt.Length; i++)
            {
                if (i == 0)
                {
                    cognome = cognome + cognometxt.Substring(0, 1).ToUpper();

                }
                else
                {
                    cognome = cognome + cognometxt.Substring(i, 1).ToLower();

                }
            }

            
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
