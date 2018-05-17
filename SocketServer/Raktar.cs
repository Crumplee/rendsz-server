using System;
using System.Collections.Generic;
using Communication;

public class Raktar
{
    int raklaphelySzam;
    string nev, cim, azonosito;
    public List<Termek> termekek = new List<Termek>();
    public List<Raklaphely> raklapHelyek = new List<Raklaphely>();
    public List<Terminal> terminalok = new List<Terminal>();
    

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
        raklapokk.Clear();

        raklapokk.Add("H2");
        raklapokk.Add("H3");
        termekek.Add(new Termek("pisi", "kaka", "kek", "H", DateTime.Parse("2005-01-01"), DateTime.Parse("2018-01-01"), 2, raklapokk));
        raklapokk.Clear();

        raklapokk.Add("HT1");
        termekek.Add(new Termek("asd2", "lol2", "kek2", "NH", DateTime.Parse("2004-01-01"), DateTime.Parse("2000-01-01"), 1, raklapokk));
        raklapokk.Clear();
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
        termekek = Fajlkezelo.Instance().loadTermekek();

        termekek.Add(ujTermek);
        raklaphelyLetrehozasa(raklaphelyek, ujTermek.getRaklapok());

        Fajlkezelo.Instance().saveTermekek(termekek);
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
        return Fajlkezelo.Instance().loadTermekek();
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
        foreach (Termek t in Fajlkezelo.Instance().loadTermekek())
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

        //Console.WriteLine("termekbehozatal check -- " + t.getRaklapok()[0].getEpsegBe());
    }

    public void termekKivitel(string azonosito, List<string> raklapok, List<string> epseg)
    {
        Termek t = getTermek(azonosito);

        for (int i = 0; i < raklapok.Count; ++i)
        {
            Raklap r = t.getRaklap(raklapok[i]);
            int idx = t.getRaklapok().IndexOf(r);
            t.getRaklapok()[idx].setEpsegKi(epseg[i]);
        }
        termekTorles(t);

    }

    public void termekTorles(Termek t)
    {
        termekek.Remove(t);
    }

    public void termekModositas(string termekAzonosito, Termek termek)
    {
        for (int i = 0; i < termekek.Count; ++i)
        {
            if (termekek[i].getKulsovonalkod() == termekAzonosito)
            {
                termekek[i].setTermekNev(termek.getTermekNev());
                termekek[i].setKulsoVonalkod(termek.getKulsovonalkod());
                termekek[i].setBeIdopont(termek.getBeIdopont());
                termekek[i].setKiIdopont(termek.getKiIdopont());
                termekek[i].setMegrendeloAzonosito(termek.getMegrendeloAzonosito());
                break;
            }
        }
        
    }

    public List<Termek> getTermekLista(Termek szurok)
    {
        List<Termek> termekekLista = termekek;
        List<Termek> termekekLista_tmp = new List<Termek>();

        //kulsovonkod
        if (szurok.getKulsovonalkod() != null)
        {
            foreach (Termek t in termekekLista)
            {
                if (szurok.getKulsovonalkod() == t.getKulsovonalkod())
                {
                    termekekLista_tmp.Add(t);
                }
            }
            termekekLista = termekekLista_tmp;
            termekekLista_tmp = new List<Termek>();
        }
        
        //termeknev
        if (szurok.getTermekNev() != null)
        {
            foreach (Termek t in termekekLista)
            {
                if (szurok.getTermekNev() == t.getTermekNev())
                {
                    termekekLista_tmp.Add(t);
                }
            }
            termekekLista = termekekLista_tmp;
            termekekLista_tmp = new List<Termek>();
        }

        //bedatum
        if (szurok.getBeIdopont().ToString() != new DateTime().ToString())
        {
            foreach (Termek t in termekekLista)
            {
                if (szurok.getBeIdopont().ToString() == t.getBeIdopont().ToString())
                {
                    termekekLista_tmp.Add(t);
                }
            }
            termekekLista = termekekLista_tmp;
            termekekLista_tmp = new List<Termek>();
        }

        //kidatum
        if (szurok.getKiIdopont().ToString() != new DateTime().ToString())
        {
            foreach (Termek t in termekekLista)
            {
                if (szurok.getKiIdopont().ToString() == t.getKiIdopont().ToString())
                {
                    termekekLista_tmp.Add(t);
                }
            }
            termekekLista = termekekLista_tmp;
            termekekLista_tmp = new List<Termek>();
        }

        //tipus
        if (szurok.getTipus() != null)
        {
            foreach (Termek t in termekekLista)
            {
                if (szurok.getTipus() == t.getTipus())
                {
                    termekekLista_tmp.Add(t);
                }
            }
            termekekLista = termekekLista_tmp;
            termekekLista_tmp = new List<Termek>();
        }

        //megrendelo
        if (szurok.getMegrendeloAzonosito() != null)
        {
            foreach (Termek t in termekekLista)
            {
                if (szurok.getMegrendeloAzonosito() == t.getMegrendeloAzonosito())
                {
                    termekekLista_tmp.Add(t);
                }
            }
            termekekLista = termekekLista_tmp;
            termekekLista_tmp = new List<Termek>();
        }
        
        //raklap
        if (szurok.getRaklapok().Count > 0)
        {
            foreach (Termek t in termekekLista)
            {
                for (int i = 0; i < t.getRaklapok().Count; ++i)
                {
                    if (szurok.getRaklapok()[0] == t.getRaklapok()[i])
                    {
                        termekekLista_tmp.Add(t);
                    }
                }
            }
            termekekLista = termekekLista_tmp;
            termekekLista_tmp = new List<Termek>();
        }


        return termekekLista;
    }
}
