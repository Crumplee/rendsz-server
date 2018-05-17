using System;
using Communication;
using System.Collections.Generic;

public class Adminisztrator: Dolgozo
{
	public Adminisztrator(string _azonosito, string _vonalkod, string _nev, string _jogosultsag)
        :base(_azonosito, _vonalkod, _nev, _jogosultsag)
    {
      
    }
    

    public override void addFelhasznalo(CommObject.felhasznaloAdatokStruct ujFelhasznalo)
    {
        Dolgozo ujDolgozo = new Dolgozo(ujFelhasznalo.azonosito, ujFelhasznalo.vonalkod, ujFelhasznalo.nev, ujFelhasznalo.jogosultsag);
        SzerverKontroller.dolgozok.addFelhasznalo(ujDolgozo);

        string log = DateTime.Now.ToString() + " - " + getAzonosito() + " - " + "addFelhasznalo" + " - " + ujDolgozo.toLog();
        Logger.Instance().logs.Add(log);

    }

    public override CommObject getDolgozok()
    {
        CommObject toResponse = new CommObject();
        List<Dolgozo> dolgozok = SzerverKontroller.dolgozok.getDolgozok();

        foreach (Dolgozo d in dolgozok)
        {
            toResponse.felhasznalokLista.Add(new CommObject.felhasznaloAdatokStruct(d.getAzonosito(), d.getVonalkod(), d.getNev(), d.getJogosultsag()));
        }

        return toResponse;
    }

    public override void deleteFelhasznalo(string azonosito)
    {
        SzerverKontroller.dolgozok.deleteFelhasznalo(azonosito);

        string log = DateTime.Now.ToString() + " - " + getAzonosito() + " - " + "deleteFelhasznalo" + " - " + azonosito;
        Logger.Instance().logs.Add(log);
    }

    public override void modifyFelhasznalo(CommObject.felhasznaloAdatokStruct felhasznalo)
    {

        Dolgozo dolgozo = new Dolgozo(felhasznalo.azonosito, felhasznalo.vonalkod, felhasznalo.nev, felhasznalo.jogosultsag);
        SzerverKontroller.dolgozok.modifyFelhasznalo(dolgozo);

        string log = DateTime.Now.ToString() + " - " + getAzonosito() + " - " + "addFelhasznalo" + " - " + dolgozo.toLog();
        Logger.Instance().logs.Add(log);
    }

    public override List<string> logokListazasa()
    {
        List<string> logok = new List<string>();

        logok = Logger.Instance().logs;

        return logok;
    }

}
