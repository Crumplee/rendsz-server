﻿using System;
using Communication;
using System.Collections.Generic;
public class Dolgozo
{
    protected string azonosito, vonalkod, nev, jogosultsag;

	public Dolgozo(string _azonosito, string _vonalkod, string _nev, string _jogosultsag)
	{
        azonosito = _azonosito;
        vonalkod = _vonalkod;
        nev = _nev;
        jogosultsag = _jogosultsag;
	}

    public string getAzonosito()
    {
        return azonosito;
    }

    public string getVonalkod()
    {
        return vonalkod;
    }
    

    public string getJogosultsag()
    {
        return jogosultsag;
    }

    public string getNev()
    {
        return nev;
    }

    public virtual void pempo() {
        Console.WriteLine("alma");
    }

    public override string ToString()
    {
        return getNev();
    }

    public virtual CommObject termekekListazasa()
    {
        return new CommObject();
    }

    public virtual CommObject getSzabadRaklaphelyekTipusSzerint(bool hutott)
    {
        return new CommObject();
    }

    public virtual void behozandoTermekRegisztralasa(CommObject.termekAdatokStruct adatok)
    {

    }

    public virtual void munkarendHozzaadas(CommObject.beosztasAdatokStruct adatok)
    {
        
    }

    public CommObject munkarendLekerdezes()
    {
        CommObject toResponse = new CommObject();
        List<Munkarend> munkarendek = SzerverKontroller.munkarendek.getMunkarendek();

        foreach (Munkarend munkarend in munkarendek)
        {
            toResponse.beosztasokAdatokLista.Add(new CommObject.beosztasAdatokStruct(munkarend.getDolgozoAzonosito(), munkarend.getDatum(), munkarend.getMuszakSorszam()));
        }

        return toResponse;
    }

    public virtual void addFelhasznalo(CommObject.felhasznaloAdatokStruct ujFelhasznalo)
    {

    }

    public virtual void deleteFelhasznalo()
    {

    }
}
