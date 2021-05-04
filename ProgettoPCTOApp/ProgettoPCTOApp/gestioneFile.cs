using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoPCTOApp
{
    class gestioneFile
    {

        private List<Utente> banca;
        private string nomeFile;

        public gestioneFile()
        {
            banca = new List<Utente>();
            nomeFile = "";
        }

        public string GetAllCsv()
        {
            string ritorno = "";
            for (int i = 0; i < banca.Count(); i++)
            {
                if (i != banca.Count() - 1) ritorno += banca.ElementAt(i).ToCsv() + "\n";
                else ritorno += banca.ElementAt(i).ToCsv();
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

    }
}
