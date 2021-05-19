using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoPCTOApp
{
    public class Biglietto
    {

        private string tariffa;  // se G = giornaliero se S= settimanale M= mensile
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
    }
}
