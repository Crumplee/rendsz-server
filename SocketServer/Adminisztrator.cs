using System;
using Communication;
using System.Collections.Generic;

public class Adminisztrator: Dolgozo
{
	public Adminisztrator(string _azonosito, string _vonalkod, string _nev, string _jogosultsag)
        :base(_azonosito, _vonalkod, _nev, _jogosultsag)
    {
      
    }

    public override void pempo()
    {
        Console.WriteLine("haggyukmá blizzárd");
    }

    public override void addFelhasznalo(CommObject.felhasznaloAdatokStruct ujFelhasznalo)
    {
        Dolgozo ujDolgozo = new Dolgozo(ujFelhasznalo.azonosito, ujFelhasznalo.vonalkod, ujFelhasznalo.nev, ujFelhasznalo.jogosultsag);
        SzerverKontroller.dolgozok.addFelhasznalo(ujDolgozo);        
    }

    public override CommObject getDolgozok()
    {
        CommObject toResponse = new CommObject();
        List<Dolgozo> dolgozok = SzerverKontroller.dolgozok.getDolgozok();

        foreach (Dolgozo d in dolgozok)
        {
            toResponse.felhasznalokLista.Add(new CommObject.felhasznaloAdatokStruct(d.getAzonosito(), "", d.getNev(), d.getJogosultsag()));
        }

        return toResponse;
    }

    public override void deleteFelhasznalo(string azonosito)
    {
        SzerverKontroller.dolgozok.deleteFelhasznalo(azonosito);
    }
}
