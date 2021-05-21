using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototipoConvalidazioneBiglietto
{
    class CData
    {


        private int giorno;
        private int mese;
        private int anno;

        public CData()
        {
            giorno = 0;
            mese = 0;
            anno = 0;
        }

        public CData(int anno, int mese, int giorno)
        {
            this.anno = anno;
            this.mese = mese;
            this.giorno = giorno;
        }

        public int getGiorno()
        {
            return giorno;
        }

        public int getMese()
        {
            return mese;
        }
        public int getAnno()
        {
            return anno;
        }

        public override string ToString()
        {
            return  anno + " " + mese + " " +giorno ;
        }

        public string ToCsv()
        {
            string tmp;
            tmp = anno + ";" + mese + ";" + giorno;
            return tmp;
        }

    }
}
