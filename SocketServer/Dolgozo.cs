using System;
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

    public CommObject munkarendLekerdezes(string azonosito)
    {
        CommObject toResponse = new CommObject();
        List<Munkarend> munkarendek = SzerverKontroller.munkarendek.getMunkarendek();

        foreach (Munkarend munkarend in munkarendek)
        {
            if (munkarend.getDolgozoAzonosito() == azonosito)
            {
                toResponse.beosztasokAdatokLista.Add(new CommObject.beosztasAdatokStruct(munkarend.getDolgozoAzonosito(), munkarend.getDatum(), munkarend.getMuszakSorszam()));

            }
        }

        return toResponse;
    }

    public virtual CommObject munkarendekLekerdezes()
    {
        return new CommObject();
    }

    public virtual void addFelhasznalo(CommObject.felhasznaloAdatokStruct ujFelhasznalo)
    {

    }

    public virtual CommObject getDolgozok()
    {
        return new CommObject();
    }

    public virtual void deleteFelhasznalo(string azonosito)
    {

    }

    public virtual void modifyFelhasznalo(CommObject.felhasznaloAdatokStruct felhasznalo)
    {

    }

    public virtual void terminalBeosztasLetrehozasa(CommObject.terminalBeosztasAdatokStruct terminalBeosztas)
    {

    }

    public virtual CommObject getTerminalBeosztasok(CommObject.terminalBeosztasLekerdezesStruct terminalBeosztasLekerdezes)
    {
        return new CommObject();
    }

    public virtual CommObject getTerminalBeosztasTermekDatumTerminalSzerint(CommObject.termekMozgatasLekerdezesStruct termekMozgatasAdatok)
    {
        return new CommObject();
    }

    public virtual void termekBehozatal(string termek, List<CommObject.mozgoRaklapAdatokStruct> mozgoRaklapAdatok)
    {

    }

    public virtual void termekKivitel(string termek, List<CommObject.mozgoRaklapAdatokStruct> mozgoRaklapAdatok)
    {

    }
}
