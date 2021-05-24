using System;
using System.Collections.Generic;
using System.IO.Ports;
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
   
    public partial class MainWindow : Window
    {
        UtenteLetto utenteDaVerificare;
        SerialPort com;
        

        public MainWindow()
        {
            InitializeComponent();

            utenteDaVerificare = new UtenteLetto();
  

        }
        private void com_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string s = com.ReadExisting();
            string[] campi = s.Split(';');
            utenteDaVerificare = new UtenteLetto(campi[0], campi[1], campi[2], campi[3], int.Parse(campi[4]), float.Parse(campi[5]));

            if ((utenteDaVerificare.getTipoAbbonamento() == "g") && (utenteDaVerificare.getIndice() == DateTime.Now.Day))
            {
                MessageBox.Show("Biglietto valido");
                com.Write("OK");
            }

            else if ((utenteDaVerificare.getTipoAbbonamento() == "m") && (utenteDaVerificare.getIndice() == DateTime.Now.Month))
            {

                MessageBox.Show("Biglietto valido");
                com.Write("OK");

            }


            else if ((utenteDaVerificare.getTipoAbbonamento() == "s") && (utenteDaVerificare.getIndice() == GetWeekNumber(DateTime.Now.Date)))
            {

                MessageBox.Show("Biglietto valido");
                com.Write("OK");

            }

            else
            {
                MessageBox.Show("Biglietto non valido");
                com.Write("KO");
            }


        }

        private int GetWeekNumber(DateTime date)
        {
            System.Globalization.Calendar calendar = System.Threading.Thread.CurrentThread.CurrentCulture.Calendar;
            System.Globalization.DateTimeFormatInfo dateTimeFormat = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat;

            return calendar.GetWeekOfYear(date, dateTimeFormat.CalendarWeekRule, dateTimeFormat.FirstDayOfWeek);
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

            else if ((utenteDaVerificare.getTipoAbbonamento() == "s") && (utenteDaVerificare.getIndice() == GetWeekNumber(DateTime.Now.Date)))
            {

                MessageBox.Show("Biglietto valido");
                com.Write("OK");

            }

            else
            {
                MessageBox.Show("biglietto non valido");

            }
        }
    }
}
