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

namespace PrototipoConvalidazioneBiglietto
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UtenteLetto utenteDaVerificare;
   
        

        public MainWindow()
        {
            InitializeComponent();

            utenteDaVerificare = new UtenteLetto();
  

        }

        private void BtnSimula_Click(object sender, RoutedEventArgs e)
        {

            string[] campi = txtStringa.Text.Split(';');

            utenteDaVerificare = new UtenteLetto(campi[0], campi[1], campi[2], campi[3], int.Parse(campi[4]), float.Parse(campi[5]));
       




            if ((utenteDaVerificare.getTipoAbbonamento() == "g") && (utenteDaVerificare.getIndice() == DateTime.Now.Day))
            {

                MessageBox.Show("biglietto valido");

            }

            else if ((utenteDaVerificare.getTipoAbbonamento() == "m") && (utenteDaVerificare.getIndice() == DateTime.Now.Month))
            {

                MessageBox.Show("biglietto valido");

            }

            //qui andrebbe il controllo del settimanale
      
            else
            {
                MessageBox.Show("biglietto non valido");

            }
        }
    }
}
