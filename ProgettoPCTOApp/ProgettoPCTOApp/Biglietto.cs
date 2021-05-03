using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoPCTOApp
{
    class Biglietto
    {

        private bool singolo;
        private int settimana;
        private int mese;

        public Biglietto()
        {
            singolo = false;
            settimana = 0;
            mese = 0;

        }

        public Biglietto(bool singolo)
        {
            this.singolo = singolo;
        }

        public Biglietto(int settimana)
        {
            this.settimana = settimana;
        }

        public bool getSingolo()
        {
            return singolo;
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
