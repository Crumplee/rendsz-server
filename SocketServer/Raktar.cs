using System;
using System.Collections.Generic;
using Communication;

public class Raktar
{
    int raklaphelySzam;
    string nev, cim, azonosito;
    List<Termek> termekek = new List<Termek>();
    List<Raklaphely> raklapHelyek = new List<Raklaphely>();
    

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
}
