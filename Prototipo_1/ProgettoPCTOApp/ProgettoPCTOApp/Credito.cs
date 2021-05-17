using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoPCTOApp
{
    public class Credito
    {
        float saldo;
        string pin;

        public Credito()
        {
            saldo = 0.0f;
            pin = "";
        }

        public Credito(float saldo, string pin)
        {
            this.saldo = saldo;
            this.pin = pin ;
        }

        public float getSaldo()
        {
            return saldo;
        }

        public string getPin()
        {
            return pin;
        }


        public string ToCsv()
        {
            string tmp;
            tmp = saldo + ";" + pin;
            return tmp;
        }

    }
}
