using System;

public class TerminalBeosztas
{
    public DateTime idopont;
    public int idotartamEgyseg; //30 perc
    public Termek termek;
    public string irany;
    public Terminal terminal;

    public TerminalBeosztas() { }

	public TerminalBeosztas(DateTime _idopont, int _idotartamEgyseg, Termek _termek, string _irany, Terminal _terminal)
	{
        idopont = _idopont;
        idotartamEgyseg = _idotartamEgyseg;
        termek = _termek;
        irany = _irany;
        terminal = _terminal;
	}

    public Termek getTermek()
    {
        return termek;
    }

    public DateTime getIdopont()
    {
        return idopont;
    }

    public Terminal getTerminal()
    {
        return terminal;
    }

    public int getIdotartamEgyseg()
    {
        return idotartamEgyseg;
    }

    public string getIrany()
    {
        return irany;
    }

    public string toLog()
    {
        string log = "";

        log += terminal.getAzonosito() + " - " + idopont.ToString() + " - " + idotartamEgyseg.ToString() + " - " + termek.getKulsovonalkod()
            + " - " + irany;
        return log;
    }
}
