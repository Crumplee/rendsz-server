using System;
using System.Collections.Generic;

public class TerminalBeosztasok
{
    List<TerminalBeosztas> terminalBeosztasok = new List<TerminalBeosztas>();


	public TerminalBeosztasok()
	{
	}

    /*
    public List<TerminalBeosztas> getTerminalBeosztasokDatumSzerint(DateTime nap)
    {
        List<TerminalBeosztas> 
    }*/

    public void terminalBeosztasLetrehozasa(TerminalBeosztas tb)
    {
        terminalBeosztasok.Add(tb);
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

}
