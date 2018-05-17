using System;

public class Munkarend
{
    public string dolgozoAzonosito;
    public DateTime datum;
    public int muszakSorszam;
	public Munkarend(string _dolgozoAzonosito, DateTime _datum, int _muszakSorszam)
	{
        dolgozoAzonosito = _dolgozoAzonosito;
        datum = _datum;
        muszakSorszam = _muszakSorszam;
	}

    public Munkarend() { }

    public string getDolgozoAzonosito()
    {
        return dolgozoAzonosito;
    }

    public DateTime getDatum()
    {
        return datum;
    }

    public int getMuszakSorszam()
    {
        return muszakSorszam;
    }

    public string toLog()
    {
        string log = "";
        log += dolgozoAzonosito + " - " + datum.ToString() + " - " + muszakSorszam.ToString();
        return log;
    }
}
