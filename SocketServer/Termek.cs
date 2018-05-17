using System;
using System.Collections.Generic;

public class Termek
{
    public string megrendeloAzonosito;
    public string termekNev;
    public string kulsoVonalkod;
    public string tipus;
    public DateTime beIdopont;
    public DateTime kiIdopont;
    public int mennyiseg;
    public List<Raklap> raklapok = new List<Raklap>();


    public void setMegrendeloAzonosito(string azon)
    {
        megrendeloAzonosito = azon;
    }

    public void setTermekNev(string nev)
    {
        termekNev = nev;
    }

    public void setKulsoVonalkod(string kod)
    {
        kulsoVonalkod = kod;
    }

    public void setBeIdopont(DateTime date)
    {
        beIdopont = date;
    }

    public void setKiIdopont(DateTime date)
    {
        kiIdopont = date;
    }


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

    public Termek() { }

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
            Raklap raklap_tmp = new Raklap(kod, _raklaphelyek[i], "", "", 0, false);
            raklapok.Add(raklap_tmp);
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

    public Raklap getRaklap(string azonosito)
    {
        foreach(Raklap r in raklapok)
        {
            if (r.getBelsoVonalkod() == azonosito)
            {
                return r;
            }
        }
        return null;
    }

    public string toLog()
    {
        string log = "";

        log += megrendeloAzonosito + "-" + termekNev + "-" + kulsoVonalkod + "-" + tipus + "-" + beIdopont.ToString() + "-"
            + kiIdopont.ToString() + "-" + mennyiseg.ToString();

        foreach (Raklap r in raklapok)
        {
            log += " | " + r.toLog();
        }


        return log;
    }
}
