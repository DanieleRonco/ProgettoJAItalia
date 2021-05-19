using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoPCTOApp
{
    public class gestioneFile
    {

        private List<Utente> lista;
        private string nomeFile;

        public gestioneFile()
        {
            lista = new List<Utente>();
            nomeFile = "";          
        }

        public void registra(Utente utente)
        {
            lista.Add(utente);
        }


        public string GetAllCsv()
        {
            string ritorno = "";
            for (int i = 0; i < lista.Count(); i++)
            {
                if (i != lista.Count() - 1) ritorno += lista.ElementAt(i).ToCsv() + "\n";
                else ritorno += lista.ElementAt(i).ToCsv();
            }
            return ritorno;
        }
        public void Salva()
        {
            File.WriteAllText(nomeFile, this.GetAllCsv());
        }

        public void set_nome_file(string nomeFile)
        {
            this.nomeFile = nomeFile;
        }

        public void Carica()
        {
            lista.Clear();
            Utente pTemp;
            Biglietto temp;

            string linea = "";
            string tutto = File.ReadAllText(nomeFile);
            string[] Linee = tutto.Split('\n');

            for (int i = 0; i < Linee.Length; i++)
            {
                linea = Linee[i];
                string[] campi = linea.Split(';');

                temp = new Biglietto(campi[7], int.Parse(campi[8]));
                pTemp = new Utente(campi[0], campi[1], campi[2], campi[3], campi[4], campi[5],float.Parse(campi[6]),temp);
                lista.Add(pTemp);
            }
        }



        public bool isResistrato(Utente utente)
        {
            for (int i = 0;  i< lista.Count; i++)
            {
                if ((utente.getCognome() == lista.ElementAt(i).getCognome())&& (utente.getCodFiscale()==lista.ElementAt(i).getCodFiscale())&&(utente.getPassword()==lista.ElementAt(i).getPassword()))
                {
                    return true;
                }
            }


            return false;
        }

        public Utente getUtente(Utente u)
        {
            Utente temp=new Utente();
            for (int i = 0; i < lista.Count; i++)
            {
                if ((u.getCognome() == lista.ElementAt(i).getCognome()) && (u.getCodFiscale() == lista.ElementAt(i).getCodFiscale()) && (u.getPassword() == lista.ElementAt(i).getPassword()))
                {
                    temp = lista.ElementAt(i);
                    return temp;
                }
            }

            return null;

        }
      
    }
}
