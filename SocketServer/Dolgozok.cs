using System;
using System.Collections.Generic;

public class Dolgozok
{
    List<Dolgozo> dolgozok = new List<Dolgozo>();

    private static Dolgozok instance = new Dolgozok();

    public static Dolgozok Instance()
    {
        
        if (instance == null)
        {
            Console.WriteLine("létrehozzaa");
            instance = new Dolgozok();
        }
        return instance;        
    }


    private Dolgozok()
	{
       
    }

    public void init()
    {
        Dolgozo tmp = new Dolgozo("asd", "kek", "tyabiii", "adminisztrator");
        dolgozok.Add(tmp);
        tmp = new Dolgozo("lol", "lul", "tsabii", "raktaros");
        dolgozok.Add(tmp);
    }

    public List<Dolgozo> getDolgozok()
    {
        return dolgozok;
    }
}
