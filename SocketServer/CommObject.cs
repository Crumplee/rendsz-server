﻿using System;
using System.Collections.Generic;

namespace Communication
{
    [Serializable]
    public class CommObject
    {
        public string Message { get; set; }
        public bool hutott;
        public string termekAzonosito;
        public List<string> lista;
        public bejelentkezesAdatok bejelentkezesadatok;
        public List<termekAdatokStruct> termekAdatokLista = new List<termekAdatokStruct>();
        public List<beosztasAdatokStruct> beosztasokAdatokLista = new List<beosztasAdatokStruct>();
        public termekAdatokStruct termekAdatok;
        public beosztasAdatokStruct beosztasAdatok;
        public felhasznaloAdatokStruct felhasznaloAdatok;
        public List<felhasznaloAdatokStruct> felhasznalokLista = new List<felhasznaloAdatokStruct>();
        public terminalBeosztasAdatokStruct terminalBeosztasAdatok;
        public List<terminalBeosztasAdatokStruct> terminalBeosztasAdatokLista = new List<terminalBeosztasAdatokStruct>();
        public terminalBeosztasLekerdezesStruct terminalBeosztasLekerdezes;
        public termekMozgatasLekerdezesStruct termekMozgatasLekerdezes;
        public List<mozgoRaklapAdatokStruct> mozgoRaklapAdatok = new List<mozgoRaklapAdatokStruct>();


        public struct mozgoRaklapAdatokStruct
        {
            public string raklap;
            public bool bejott;
            public string epseg;

            public mozgoRaklapAdatokStruct(string _raklap, bool _bejott, string _epseg)
            {
                raklap = _raklap;
                bejott = _bejott;
                epseg = _epseg;
            }
        }


        public struct termekMozgatasLekerdezesStruct
        {
            public string termekAzonosito;
            public string idopont;
            public string terminalAzonosito;

            public termekMozgatasLekerdezesStruct(string _termekAzonosito, string _idopont, string _terminalAzonosito)
            {
                termekAzonosito = _termekAzonosito;
                idopont = _idopont;
                terminalAzonosito = _terminalAzonosito;
            }
        }


        public struct terminalBeosztasLekerdezesStruct
        {
            public string tipus;
            public string idopont;
            public string terminal;
            public bool hutott;

            public terminalBeosztasLekerdezesStruct(string _tipus, string _idopont, string _terminal, bool _hutott)
            {
                tipus = _tipus;
                idopont = _idopont;
                terminal = _terminal;
                hutott = _hutott;
            }
        }

            public struct terminalBeosztasAdatokStruct
        {
            public string idopont;
            public int idotartamEgyseg;
            public bool hutott;
            public string irany;
            public string termekAzonosito;
            public string terminalAzonosito;

            public terminalBeosztasAdatokStruct(string _idopont, int _idotartamEgyseg, bool _hutott, string _irany, string _termekAzonosito, string _terminalAzonosito)
            {
                idopont = _idopont;
                idotartamEgyseg = _idotartamEgyseg;
                hutott = _hutott;
                irany = _irany;
                termekAzonosito = _termekAzonosito;
                terminalAzonosito = _terminalAzonosito;
            }
        }


        public struct bejelentkezesAdatok
        {
            public string azonosito, vonalkod;

            public bejelentkezesAdatok(string _azonosito, string _vonalkod)
            {
                azonosito = _azonosito;
                vonalkod = _vonalkod;
            }
        }

        public struct felhasznaloAdatokStruct
        {
            public string azonosito, vonalkod, nev, jogosultsag;

            public felhasznaloAdatokStruct(string _azonosito, string _vonalkod, string _nev, string _jogosultsag)
            {
                azonosito = _azonosito;
                vonalkod = _vonalkod;
                nev = _nev;
                jogosultsag = _jogosultsag;
            }
        }


        public struct termekAdatokStruct
        {
            public string megrendeloAzonosito;
            public string termekNev;
            public string kulsoVonalkod;
            public string tipus;
            public string beIdopont;
            public string kiIdopont;
            public int mennyiseg;
            public List<string> raklaphelyek;
            public List<string> raklapAdatok;

            public termekAdatokStruct(string _megrendeloAzonosito,
                                string _termekNev,
                                string _kulsoVonalkod,
                                string _tipus,
                                string _beIdopont,
                                string _kiIdopont,
                                int _mennyiseg,
                                List<string> _raklaphelyek)
            {
                megrendeloAzonosito = _megrendeloAzonosito;
                termekNev = _termekNev;
                kulsoVonalkod = _kulsoVonalkod;
                tipus = _tipus;
                beIdopont = _beIdopont;
                kiIdopont = _kiIdopont;
                mennyiseg = _mennyiseg;
                raklaphelyek = _raklaphelyek;
                raklapAdatok = new List<string>();
            }
        }

        public struct beosztasAdatokStruct
        {
            public string dolgozoAzonosito;
            public DateTime datum;
            public int muszakSorszam;

            public beosztasAdatokStruct(string _dolgozoAzonosito, DateTime _datum, int _muszakSorszam)
            {
                dolgozoAzonosito = _dolgozoAzonosito;
                datum = _datum;
                muszakSorszam = _muszakSorszam;
            }
        }

        
        public CommObject() { }
        public CommObject(string msg)
        {
            this.Message = msg;
        }
        

        public override string ToString()
        {
            return Message;
        }
    }
}
