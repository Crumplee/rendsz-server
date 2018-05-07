using System;

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

    public void munkarendLekerdezes()
    {
        //hujuj

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
}
