using System;

public class Terminal
{
    public string azonosito;
    public bool hutott;

    public Terminal() { }

	public Terminal(string _azonosito, bool _hutott)
	{
        azonosito = _azonosito;
        hutott = _hutott;
	}

    public string getAzonosito()
    {
        return azonosito;
    }

    public bool getHutott()
    {
        return hutott;
    }
}
