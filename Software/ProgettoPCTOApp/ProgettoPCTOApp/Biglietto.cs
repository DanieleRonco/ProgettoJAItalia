using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace ProgettoPCTOApp
{
    public class Biglietto
    {
        private string tariffa;  // se g = giornaliero se s= settimanale se m= mensile
        private int indice;    // in base alla tariffa

        public Biglietto()
        {
            tariffa = "";
            indice = 0;

        }

        public Biglietto(string tariffa, int indice)
        {
            this.tariffa = tariffa;
            this.indice = indice;
        }

        public string getTariffa()
        {
            return tariffa;
        }

        public int getIndice()
        {
            return indice;
        }
        public void setBiglietto(string tariffa, int indice)
        {
            this.tariffa = tariffa;
            this.indice = indice;

        }
        public override string ToString()
        {
            string tmp;
            tmp =  tariffa + " " + indice;
            return base.ToString();
        }

        public string ToCsv()
        {
            string tmp;
            tmp = tariffa + ";" + indice ;
            return tmp;
        }

        public string getFineBiglietto()
        {
            string ritorno;
            if (this.tariffa == "g")
            {
                ritorno = System.DateTime.Now.ToString("yyyy/MM/dd");
                Console.WriteLine(ritorno);
            }
            else if (this.tariffa == "s")
            {
                ritorno = System.DateTime.Now.AddDays(7).ToString("yyyy/MM/dd");
                Console.WriteLine(ritorno);
            }
            else
            {
                ritorno = System.DateTime.Now.AddMonths(1).ToString("yyyy/MM/dd");
                Console.WriteLine(ritorno);
            }
            return ritorno;
        }
    }
}