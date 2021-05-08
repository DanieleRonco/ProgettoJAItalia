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

                temp = new Biglietto(campi[6], int.Parse(campi[7]));
                pTemp = new Utente(campi[0], campi[1], campi[2], (campi[3]), campi[4], campi[5],temp);
                lista.Add(pTemp);
            }
        }

    }
}
