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
    /*
    public override void deleteFelhasznalo()
    {
        CommObject toResponse = new CommObject();
        
        
        foreach (Dolgozo d in SzerverKontroller.dolgozok.getDolgozok())
        {
            users.Add(d.getNev());
        }
        toResponse.lista = users;


    }*/
}
