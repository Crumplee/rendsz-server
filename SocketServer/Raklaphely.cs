using System;

public class Raklaphely
{
    public string azonosito;
    public string raklapAzonosito = null;
    public bool hutott;

    public Raklaphely() { }

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
