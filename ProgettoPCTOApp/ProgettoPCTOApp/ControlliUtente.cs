
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoPCTOApp
{
    public class ControlliUtente
    {
        private Utente utente;

        /*
        public ControlliUtente()
        {

            utente = new Utente();
        }

        public bool controlloPassword(Utente u) {

            string password = u.getPassword();
            if (password != u.getConfPassword())
            {

                return false;

            }
            else if (password.Length < 8)
            {
                return false;
            }

            return true;
        }

        public string correggiNome(Utente u)
        {
            string nome = u.getNome();
            string nomecorretto = "";
            for (int i = 0; i <= nome.Length; i++)
            {
                if (i == 0)
                {
                    nomecorretto = nomecorretto + nome.Substring(0, 1).ToUpper();

                }
                else
                {
                    nomecorretto = nomecorretto + nome.Substring(i-1, i).ToLower();

                }
            }
            return nomecorretto;
        }
            public string correggiCognome(Utente u)
            {
                string cognome = u.getCognome();
                string cognomecorretto = "";

                for (int i = 0; i <= cognome.Length; i++)
                {
                if (i == 0)
                    {
                    cognomecorretto = cognomecorretto + cognome.Substring(0, 1).ToUpper();

                    }
                    else
                    {
                        cognomecorretto = cognomecorretto + cognome.Substring(i-1, i).ToLower();

                    }
                }
                return cognomecorretto;
            }


        public bool Controllo()
        {
            if (controlloPassword(utente) == false) {



                return false;
            }
            else{

                correggiCognome(utente);
                correggiNome(utente);


                return true;
            }



        }
       }
     */
    }
}






