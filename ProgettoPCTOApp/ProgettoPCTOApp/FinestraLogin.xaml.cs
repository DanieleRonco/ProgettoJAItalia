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
    /// Logica di interazione per FinestraLogin.xaml
    /// </summary>
    public partial class FinestraLogin : Window
    {
        private void InitializeMyControl()
        {
            txtPassword.MaxLength = 14;
        }
        public FinestraLogin()
        {

            InitializeComponent();
            InitializeMyControl();


        }
    }
}
