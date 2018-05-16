using System;
using System.Collections.Generic;

public class TerminalBeosztasok
{
    List<TerminalBeosztas> terminalBeosztasok = new List<TerminalBeosztas>();


	public TerminalBeosztasok()
	{
	}


    public void terminalBeosztasLetrehozasa(TerminalBeosztas tb)
    {
        terminalBeosztasok.Add(tb);
        Console.WriteLine(tb.getTerminal().getAzonosito() + "terminalhoz terminalbeosztas jott letre");
    }

    public List<TerminalBeosztas> getTerminalBeosztasokDatumSzerint(DateTime idopont)
    {
        List<TerminalBeosztas> terminalBeosztasok_tmp = new List<TerminalBeosztas>();

        foreach (TerminalBeosztas tb in terminalBeosztasok)
        {
            DateTime tb_idopont = tb.getIdopont();
            if (tb_idopont.Year == idopont.Year && tb_idopont.Month == idopont.Month && tb_idopont.Day == idopont.Day)
            {
                terminalBeosztasok_tmp.Add(tb);
            }
        }
        
        return terminalBeosztasok_tmp;
    }

    public List<TerminalBeosztas> getTerminalBeosztasokDatumEsTipusSzerint(DateTime idopont, bool hutott)
    {
        List<TerminalBeosztas> terminalBeosztasok_tmp = new List<TerminalBeosztas>();

        foreach (TerminalBeosztas tb in terminalBeosztasok)
        {
            DateTime tb_idopont = tb.getIdopont();
            if (tb_idopont.Year == idopont.Year && tb_idopont.Month == idopont.Month && tb_idopont.Day == idopont.Day)
            {

                if (tb.getTerminal().getHutott() == hutott)
                {
                    terminalBeosztasok_tmp.Add(tb);
                }
            }
        }

        return terminalBeosztasok_tmp;
    }

    public List<TerminalBeosztas> getTerminalBeosztasokTerminalSzerint(string azonosito)
    {
        List<TerminalBeosztas> terminalBeosztasok_tmp = new List<TerminalBeosztas>();

        foreach (TerminalBeosztas tb in terminalBeosztasok)
        {
            if (tb.getTerminal().getAzonosito() == azonosito)
            {
                terminalBeosztasok_tmp.Add(tb);
            }
        }

        return terminalBeosztasok_tmp;
    }

    public TerminalBeosztas getTerminalBeosztas(string termekA, DateTime idopont, string terminalA)
    {
        foreach (TerminalBeosztas tb in terminalBeosztasok)
        {
            if (tb.getTermek().getKulsovonalkod() == termekA && tb.getIdopont() == idopont && tb.getTerminal().getAzonosito() == terminalA)
            {
                return tb;
            }
        }
        return null;
    }

    public void terminalBeosztasTorles(string termekAzon)
    {
        for (int i = terminalBeosztasok.Count - 1; i >= 0; --i)
        {
            if (terminalBeosztasok[i].getTermek().getKulsovonalkod() == termekAzon)
            {
                terminalBeosztasok.RemoveAt(i);
            }
        }
    }

}
