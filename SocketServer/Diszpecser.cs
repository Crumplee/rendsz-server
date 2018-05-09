using System;
using System.Collections.Generic;
using Communication;

public class Diszpecser: Dolgozo
{
	public Diszpecser(string _azonosito, string _vonalkod, string _nev, string _jogosultsag)
        :base(_azonosito, _vonalkod, _nev, _jogosultsag)
	{
	}
      

    public override CommObject termekekListazasa()
    {
        CommObject toResponse = new CommObject();
        List<Termek> termekek = SzerverKontroller.raktar.getTermekLista();
        
        foreach (Termek termek in termekek)
        {
            CommObject.termekAdatokStruct tmp = new CommObject.termekAdatokStruct(termek.getMegrendeloAzonosito(), termek.getTermekNev(),
                termek.getKulsovonalkod(), termek.getTipus(), termek.getBeIdopont().ToString(), termek.getKiIdopont().ToString(), termek.getMennyiseg(), new List<string>());
            foreach (Raklap raklap in termek.getRaklapok())
            {
                tmp.raklapAdatok.Add(raklap.toString());
            }
            toResponse.termekAdatokLista.Add(tmp);
        }
        return toResponse;
    }

    public override CommObject getSzabadRaklaphelyekTipusSzerint(bool hutott)
    {
        CommObject toResponse = new CommObject();
        toResponse.lista = SzerverKontroller.raktar.getSzabadRaklaphelyekTipusSzerint(hutott);
        return toResponse;
    }

    public override void behozandoTermekRegisztralasa(CommObject.termekAdatokStruct adatok)
    {
        Termek ujTermek = new Termek(adatok.megrendeloAzonosito,
                                        adatok.termekNev,
                                        adatok.kulsoVonalkod,
                                        adatok.tipus,
                                        DateTime.Parse(adatok.beIdopont),
                                        DateTime.Parse(adatok.kiIdopont),
                                        adatok.mennyiseg,
                                        adatok.raklaphelyek);

        SzerverKontroller.raktar.behozandoTermekRogzitese(ujTermek, adatok.raklaphelyek);
    }

    public override void terminalBeosztasLetrehozasa(CommObject.terminalBeosztasAdatokStruct terminalBeosztas)
    {
        Terminal terminal = SzerverKontroller.raktar.getTerminal(terminalBeosztas.terminalAzonosito);
        Termek termek = SzerverKontroller.raktar.getTermek(terminalBeosztas.termekAzonosito);

        TerminalBeosztas tb = new TerminalBeosztas(DateTime.Parse(terminalBeosztas.idopont),
                                                    terminalBeosztas.idotartamEgyseg,
                                                    termek,
                                                    terminalBeosztas.irany,
                                                    terminal
            );

        SzerverKontroller.terminalBeosztasok.terminalBeosztasLetrehozasa(tb);
    }

    public override CommObject getTerminalBeosztasok(CommObject.terminalBeosztasLekerdezesStruct terminalBeosztasLekerdezes)
    {
        CommObject toResponse = new CommObject();
        List<TerminalBeosztas> terminalbeosztasok = new List<TerminalBeosztas>();

        switch (terminalBeosztasLekerdezes.tipus)
        {
            case "datum":

                break;
            case "terminal":

                break;
            case "datumEsHutottseg":
                terminalbeosztasok = SzerverKontroller.terminalBeosztasok.getTerminalBeosztasokDatumEsTipusSzerint(DateTime.Parse(terminalBeosztasLekerdezes.idopont),
                                                                                                            terminalBeosztasLekerdezes.hutott);
                break;
            default:
                break;
        }


        foreach (TerminalBeosztas tb in terminalbeosztasok)
        {
            toResponse.terminalBeosztasAdatokLista.Add(new CommObject.terminalBeosztasAdatokStruct( tb.getIdopont().ToString(),
                                                                                                    tb.getIdotartamEgyseg(),
                                                                                                    tb.getTerminal().getHutott(),
                                                                                                    tb.getIrany(),
                                                                                                    tb.getTermek().getKulsovonalkod(),
                                                                                                    tb.getTerminal().getAzonosito()
            ));
        }

        return toResponse;
    }
}
