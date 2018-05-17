using System;
using System.Collections.Generic;
using Communication;
using System.Linq;
using System.IO;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

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
        /*
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
        
        */
        /*
        for (int i = 0; i < 5; ++i)
        {
            string azon = "HT" + (i + 1);
            terminalok.Add(new Terminal(azon, true));
        }

        for (int i = 0; i < 5; ++i)
        {
            string azon = "NHT" + (i + 1);
            terminalok.Add(new Terminal(azon, false));
        }

        XmlSerializer xmlSer = new XmlSerializer(typeof(List<Terminal>));
        Stream stream = File.Open("terminaloklista.xml", FileMode.Create);

        xmlSer.Serialize(stream, terminalok);
        stream.Close();
        */
        //Fajlkezelo.Instance().saveasd(terminalok);

        /*
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
        raklapokk.Clear();*/
    }

    public List<string> getSzabadRaklaphelyekTipusSzerint(bool hutott)
    {
        raklapHelyek = Fajlkezelo.Instance().loadRaklaphelyek();
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
        raklapHelyek.Clear();
        return lista;
    }

    public void behozandoTermekRogzitese(Termek ujTermek, List<string> raklaphelyek)
    {

        //itt ez
        termekek = Fajlkezelo.Instance().loadTermekek();       

        termekek.Add(ujTermek);
        raklaphelyLetrehozasa(raklaphelyek, ujTermek.getRaklapok());

        Fajlkezelo.Instance().saveTermekek(termekek);
    }

    public void raklaphelyLetrehozasa(List<string> _raklaphelyek, List<Raklap> raklapok)
    {
        raklapHelyek = Fajlkezelo.Instance().loadRaklaphelyek();
        for (int i = 0; i < _raklaphelyek.Count; ++i)
        {
            raklapHelyek.Find(hely => hely.getAzonosito() == _raklaphelyek[i]).setRaklapAzonosito(raklapok[i].getBelsoVonalkod());
        }
        Fajlkezelo.Instance().saveRaklaphelyek(raklapHelyek);
        raklapHelyek.Clear();
    }

    public List<Termek> getTermekLista()
    {
        return Fajlkezelo.Instance().loadTermekek();
    }

    public Terminal getTerminal(string azonosito)
    {
        foreach (Terminal t in Fajlkezelo.Instance().loadTerminalok())
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
        termekek = Fajlkezelo.Instance().loadTermekek();

        int idx = termekek.FindIndex(termek => termek.kulsoVonalkod == azonosito);

        for (int i = 0; i < raklapok.Count; ++i)
        {
            Raklap r = termekek[idx].getRaklap(raklapok[i]);
            int idx2 = termekek[idx].getRaklapok().IndexOf(r);

            termekek[idx].getRaklapok()[idx2].setRaktarban(raktarban[i]);
            termekek[idx].getRaklapok()[idx2].setEpsegBe(epseg[i]);
        }

        Fajlkezelo.Instance().saveTermekek(termekek);
    }

    public void termekKivitel(string azonosito, List<string> raklapok, List<string> epseg)
    {
        termekek = Fajlkezelo.Instance().loadTermekek();

        int idx = termekek.FindIndex(termek => termek.kulsoVonalkod == azonosito);


        for (int i = 0; i < raklapok.Count; ++i)
        {
            Raklap r = termekek[idx].getRaklap(raklapok[i]);
            int idx2 = termekek[idx].getRaklapok().IndexOf(r);
            termekek[idx].getRaklapok()[idx2].setEpsegKi(epseg[i]);
        }
        termekTorles(termekek[idx]);

    }

    public void termekTorles(Termek t)
    {
        int idx;
        
        termekek = Fajlkezelo.Instance().loadTermekek();
        raklapHelyek = Fajlkezelo.Instance().loadRaklaphelyek();

        idx = termekek.FindIndex(termek => termek.getKulsovonalkod() == t.getKulsovonalkod());

        foreach(Raklaphely rh in raklapHelyek)
        {
            if (termekek[idx].raklapok.Exists(tr => tr.belsoVonalkod == rh.raklapAzonosito))
            {
                rh.raklapAzonosito = null;
            }
        }
        Fajlkezelo.Instance().saveRaklaphelyek(raklapHelyek);
        raklapHelyek.Clear();

        termekek.RemoveAt(idx);
        
        Fajlkezelo.Instance().saveTermekek(termekek);

        termekek.Clear();
    }

    public void termekModositas(string termekAzonosito, Termek termek)
    {
        termekek = Fajlkezelo.Instance().loadTermekek();
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
        Fajlkezelo.Instance().saveTermekek(termekek);
    }

    public List<Termek> getTermekLista(Termek szurok)
    {
        List<Termek> termekekLista = Fajlkezelo.Instance().loadTermekek();
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
