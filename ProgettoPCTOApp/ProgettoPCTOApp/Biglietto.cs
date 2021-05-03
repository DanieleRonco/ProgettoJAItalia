using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoPCTOApp
{
    class Biglietto
    {

        private int durata;
        private int settimana;
        private int mese;

        public Biglietto()
        {
            durata = 0;
            settimana = 0;
            mese = 0;

        }

        public void setDurata(int durata)
        {
            this.durata = durata;
        }

        public void setSettimana(int settimana)
        {
            this.settimana = settimana;
        }

        public void setMese(int mese)
        {
            this.mese = mese;
        }
        public int getDurata()
        {
            return durata;
        }

        public int getSettimana()
        {
            return settimana;
        }

        public int getMese()
        {
            return mese;
        }


    }
}
