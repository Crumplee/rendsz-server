using System;
using System.Collections.Generic;

public class Dolgozok
{
    List<Dolgozo> dolgozok = new List<Dolgozo>();

    //private static Dolgozok instance = new Dolgozok();
    /*
    public static Dolgozok Instance()
    {        
        if (instance == null)
        {
            //Console.WriteLine("létrehozzaa");
            instance = new Dolgozok();
        }
        return instance;        
    }*/


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

    }

    public List<Dolgozo> getDolgozok()
    {
        return dolgozok;
    }

    public void addFelhasznalo(Dolgozo d)
    {
        dolgozok.Add(d);
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
        dolgozok.Remove(torlendo);
    }

    public void modifyFelhasznalo(Dolgozo dolgozo)
    {
        deleteFelhasznalo(dolgozo.getAzonosito());
        addFelhasznalo(dolgozo);
    }
}
