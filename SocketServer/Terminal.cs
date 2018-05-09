using System;

public class Terminal
{
    string azonosito;
    bool hutott;

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
