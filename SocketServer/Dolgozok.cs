using System;
using System.Collections.Generic;

public class Dolgozok
{
    public List<Dolgozo> dolgozok = new List<Dolgozo>();
    

    public Dolgozok()
	{
       
    }

    public void init()
    {
        Dolgozo tmp = new Dolgozo("admin", "123", "tyabiii", "adminisztrator");
        dolgozok.Add(tmp);
        tmp = new Dolgozo("diszpecser", "123", "tsabii", "diszpecser");
        dolgozok.Add(tmp);
        tmp = new Dolgozo("muszakv", "123", "foni", "muszakvezeto");
        dolgozok.Add(tmp);
        tmp = new Dolgozo("raktaros", "123", "belezogep", "raktaros");
        dolgozok.Add(tmp);

        Fajlkezelo.Instance().saveDolgozok(dolgozok);
    }

    public List<Dolgozo> getDolgozok()
    {
        return Fajlkezelo.Instance().loadDolgozok();
    }

    public void addFelhasznalo(Dolgozo d)
    {
        dolgozok = Fajlkezelo.Instance().loadDolgozok();
        dolgozok.Add(d);
        Fajlkezelo.Instance().saveDolgozok(dolgozok);
    }

    public void deleteFelhasznalo(string azonosito)
    {
        Dolgozo torlendo = null;
        foreach (Dolgozo d in dolgozok)
        {
            if (d.getAzonosito() == azonosito)
            {
                torlendo = d;
                break;
            }
        }
        dolgozok = Fajlkezelo.Instance().loadDolgozok();

        int idx = dolgozok.FindIndex(dolgozo => dolgozo.azonosito == azonosito);
        dolgozok.RemoveAt(idx);
        Fajlkezelo.Instance().saveDolgozok(dolgozok);
        dolgozok.Clear();
    }

    public void modifyFelhasznalo(Dolgozo dolgozo)
    {
        dolgozok = Fajlkezelo.Instance().loadDolgozok();
        for (int i = 0; i < dolgozok.Count; ++i)
        {
            if (dolgozok[i].getAzonosito() == dolgozo.getAzonosito())
            {
                dolgozok[i].setNev(dolgozo.getNev());
                dolgozok[i].setJogosultsag(dolgozo.getJogosultsag());
                break;
            }
        }
        Fajlkezelo.Instance().saveDolgozok(dolgozok);
    }
}
