using System;

public class Munkarend
{
    string dolgozoAzonosito;
    DateTime datum;
    int muszakSorszam;
	public Munkarend(string _dolgozoAzonosito, DateTime _datum, int _muszakSorszam)
	{
        dolgozoAzonosito = _dolgozoAzonosito;
        datum = _datum;
        muszakSorszam = _muszakSorszam;
	}

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
}
