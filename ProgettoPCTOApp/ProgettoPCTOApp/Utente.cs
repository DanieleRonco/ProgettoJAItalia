﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoPCTOApp
{
    class Utente
    {
        private string nome;
        private string cognome;
        private string nascita;
        private string email;
        private string password;
        private string codFiscale;
        private Biglietto biglietto;

        public Utente()
        {
            nome = "";
            cognome = "";
            nascita = "";
            email = "";
            password = "";
            codFiscale = "";
        }

        public Utente(string nome, string cognome, string nascita, string email, string password,string codFiscale)
        {
            this.nome = nome ;
            this.cognome = cognome ;
            this.nascita = nascita ;
            this.email = email ;
            this.password = password ;
            this.codFiscale = codFiscale;
        }

        public Utente(string nome, string cognome, string nascita, string email, string password,string codFiscale,Biglietto biglietto)
        {
            this.nome = nome;
            this.cognome = cognome;
            this.nascita = nascita;
            this.email = email;
            this.password = password;
            this.codFiscale = codFiscale;
            this.biglietto = biglietto;
        }

        public string getNome()
        {
            return nome;
        }

        public string getCognome()
        {
            return cognome;
        }
        public string getNascita()
        {
            return nascita;
        }
        public string getEmail()
        {
            return email;
        }

        public string getPassword()
        {
            return password;
        }

        public string getCodFiscale()
        {
            return codFiscale;
        }

        public override string ToString()
        {
            string tmp;
            tmp = nome + " " + cognome + " " + nascita + " " + email+" "+password+" "+ codFiscale;
            return base.ToString();
        }

        public string ToCsv()
        {
            string tmp;
            tmp = nome + ";" + cognome + ";" + nascita + ";" + email + ";" + password + ";" + codFiscale+";"+biglietto.ToString();
            return tmp;
        }
    }
}