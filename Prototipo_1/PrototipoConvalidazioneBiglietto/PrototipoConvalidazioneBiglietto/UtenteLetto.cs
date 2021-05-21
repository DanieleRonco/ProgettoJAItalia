using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototipoConvalidazioneBiglietto
{
    class UtenteLetto
    {

        private string nome;
        private string cognome;
        private string ID;
        private string tipoAbbonamento;
        private int indice;
       // private CData data;
        private float credito;

        public UtenteLetto()
        {
            nome = "";
            cognome = "";
            ID = "";
            tipoAbbonamento = "";
            indice = 0;
            credito = 0.0f;
        }

        public UtenteLetto(string nome, string cognome, string iD, string tipoAbbonamento, int indice, float credito)
        {
            this.nome = nome;
            this.cognome = cognome;
            ID = iD ;
            this.tipoAbbonamento = tipoAbbonamento ;
            this.indice = indice;
            this.credito = credito;
        }

        public string getNome()
        {
            return nome;
        }

        public string getCognome()
        {
            return cognome;
        }

        public string getTipoAbbonamento()
        {
            return tipoAbbonamento;
        }

        public int getIndice()
        {
            return indice;
        }

      
        

    }
}
