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
    }
}
