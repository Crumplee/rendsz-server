using System;
using System.Collections.Generic;

public class Termek
{
    string megrendeloAzonosito;
    string termekNev;
    string kulsoVonalkod;
    string tipus;
    DateTime beIdopont;
    DateTime kiIdopont;
    int mennyiseg;
    List<Raklap> raklapok = new List<Raklap>();

    public string getMegrendeloAzonosito()
    {
        return megrendeloAzonosito;
    }

    public string getTermekNev()
    {
        return termekNev;
    }

    public string getKulsovonalkod()
    {
        return kulsoVonalkod;
    }

    public string getTipus()
    {
        return tipus;
    }

    public DateTime getBeIdopont()
    {
        return beIdopont;
    }

    public DateTime getKiIdopont()
    {
        return kiIdopont;
    }

    public int getMennyiseg()
    {
        return mennyiseg;
    }

    public List<Raklap> getRaklapok()
    {
        return raklapok;
    }


    public Termek(  string _megrendeloAzonosito,
                    string _termekNev,
                    string _kulsoVonalkod,
                    string _tipus,
                    DateTime _beIdopont,
                    DateTime _kiIdopont,
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
        
        for (int i = 0; i < mennyiseg; ++i)
        {
            string kod = belsoKodGeneralas(termekNev, kulsoVonalkod, _raklaphelyek[i], beIdopont);
            Raklap raklap_tmp = new Raklap(kod, _raklaphelyek[i], true, true, 0);
            Console.WriteLine(raklap_tmp.getBelsoVonalkod());
            raklapok.Add(raklap_tmp);
            Console.WriteLine(raklapok.Count);
        }

    }

    string belsoKodGeneralas(string _termeknev, string _kulsoVonalkod, string _raklaphely, DateTime _beIdopont)
    {
        string kod = "";
        char[] charArray = _termeknev.ToCharArray();
        for (int i = 0; i < charArray.Length; i += 2)
            kod += charArray[i];
        kod += _kulsoVonalkod;
        kod += _beIdopont.Year + "" + _beIdopont.Month + "" + _beIdopont.Day;
        kod += _raklaphely;
        return kod;
    }
}
