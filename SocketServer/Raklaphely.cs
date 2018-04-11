using System;

public class Raklaphely
{
    string azonosito;
    string raklapAzonosito = null;
    bool hutott;

    public string getAzonosito()
    {
        return azonosito;
    }

    public bool getHutott()
    {
        return hutott;
    }

    public bool szabadE()
    {
        return raklapAzonosito == null;
    }

    public void setRaklapAzonosito(string rAzon)
    {
        raklapAzonosito = rAzon;
    }

	public Raklaphely(string _azonosito, bool _hutott)
	{
        azonosito = _azonosito;
        hutott = _hutott;
	}
}
