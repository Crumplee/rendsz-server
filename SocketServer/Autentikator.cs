using System;

public class Autentikator
{
	public Autentikator()
	{

	}

    public Dolgozo autentikacio(string azonosito, string vonalkod)
    {
        Dolgozo user = null;
        //Dolgozok dolgozok = Dolgozok.Instance();       

        SzerverKontroller.dolgozok.init();

        foreach (Dolgozo d in SzerverKontroller.dolgozok.getDolgozok())
        {
            
            if (d.getAzonosito() == azonosito && d.getVonalkod() == vonalkod)
            {
                switch (d.getJogosultsag())
                {
                    case "adminisztrator":
                        user = new Adminisztrator(d.getAzonosito(), d.getVonalkod(), d.getNev(), d.getJogosultsag());
                        break;
                    case "diszpecser":
                        user = new Diszpecser(d.getAzonosito(), d.getVonalkod(), d.getNev(), d.getJogosultsag());
                        break;
                    case "muszakvezeto":
                        user = new Muszakvezeto(d.getAzonosito(), d.getVonalkod(), d.getNev(), d.getJogosultsag());
                        break;
                    case "raktaros":
                        user = new Raktaros(d.getAzonosito(), d.getVonalkod(), d.getNev(), d.getJogosultsag());
                        break;
                    default:
                        break;
                }
                return user;
            }
        }
        return user;
    }
}
