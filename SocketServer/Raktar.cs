using System;
using System.Collections.Generic;
using Communication;

public class Raktar
{
    int raklaphelySzam;
    string nev, cim, azonosito;
    List<Termek> termekek = new List<Termek>();
    List<Raklaphely> raklapHelyek = new List<Raklaphely>();
    List<Terminal> terminalok = new List<Terminal>();
    

	public Raktar(string _nev, string _cim, string _azonosito)
	{
        nev = _nev;
        cim = _cim;
        azonosito = _azonosito;
        for (int i = 0; i < 5; ++i)
        {
            string azon = "NH" + (i+1);
            raklapHelyek.Add(new Raklaphely(azon, false));
        }

        for (int i = 0; i < 5; ++i)
        {
            string azon = "H" + (i+1);
            raklapHelyek.Add(new Raklaphely(azon, true));
        }

        raklaphelySzam = raklapHelyek.Count;

        for (int i = 0; i < 3; ++i)
        {
            string azon = "HT" + (i + 1);
            terminalok.Add(new Terminal(azon, true));
        }

        for (int i = 0; i < 2; ++i)
        {
            string azon = "NHT" + (i + 1);
            terminalok.Add(new Terminal(azon, false));
        }

        List<string> raklapokk = new List<string>();
        raklapokk.Add("H1");
        termekek.Add(new Termek("asd", "lol", "kek", "H", DateTime.Parse("2000-01-01"), DateTime.Parse("2010-01-01"), 1, raklapokk));
    }

    public List<string> getSzabadRaklaphelyekTipusSzerint(bool hutott)
    {
        List<string> lista = new List<string>();
        if (hutott)
        {
            raklapHelyek.ForEach(rhely => {
                if (rhely.getHutott() && rhely.szabadE())
                    lista.Add(rhely.getAzonosito());
            });
        }
        else raklapHelyek.ForEach(rhely => {
            if (!rhely.getHutott() && rhely.szabadE())
                lista.Add(rhely.getAzonosito());
        });

        return lista;
    }

    public void behozandoTermekRogzitese(Termek ujTermek, List<string> raklaphelyek)
    {
        termekek.Add(ujTermek);
        raklaphelyLetrehozasa(raklaphelyek, ujTermek.getRaklapok());
    }

    public void raklaphelyLetrehozasa(List<string> _raklaphelyek, List<Raklap> raklapok)
    {
        for (int i = 0; i < _raklaphelyek.Count; ++i)
        {
            raklapHelyek.Find(hely => hely.getAzonosito() == _raklaphelyek[i]).setRaklapAzonosito(raklapok[i].getBelsoVonalkod());
        }
    }

    public List<Termek> getTermekLista()
    {
        return termekek;
    }

    public Terminal getTerminal(string azonosito)
    {
        foreach (Terminal t in terminalok)
        {
            if (t.getAzonosito() == azonosito)
            {
                return t;
            }
        }

        return null;
    }

    public Termek getTermek(string kulsoVonalkod)
    {
        foreach (Termek t in termekek)
        {
            if (t.getKulsovonalkod() == kulsoVonalkod)
            {
                return t;
            }
        }
        return null;
    }

    public void termekBehozatal(string azonosito, List<string> raklapok, List<bool> raktarban, List<string> epseg)
    {
        Termek t = getTermek(azonosito);

        for (int i = 0; i < raklapok.Count; ++i)
        {
            Raklap r = t.getRaklap(raklapok[i]);
            int idx = t.getRaklapok().IndexOf(r);
            t.getRaklapok()[idx].setRaktarban(raktarban[i]);
            t.getRaklapok()[idx].setEpsegBe(epseg[i]);
        }

        Console.WriteLine("termekbehozatal check -- " + t.getRaklapok()[0].getEpsegBe());
    }
}
