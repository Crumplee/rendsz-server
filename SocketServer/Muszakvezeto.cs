using System;
using Communication;
using System.Collections.Generic;

public class Muszakvezeto: Dolgozo
{
	public Muszakvezeto(string _azonosito, string _vonalkod, string _nev, string _jogosultsag)
        : base(_azonosito, _vonalkod, _nev, _jogosultsag)
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

    public override void munkarendHozzaadas(CommObject.beosztasAdatokStruct adatok)
    {
        Munkarend ujmunkarend = new Munkarend(adatok.dolgozoAzonosito, adatok.datum, adatok.muszakSorszam);
        SzerverKontroller.munkarendek.addMunkarend(ujmunkarend);
    }

    public override CommObject getTerminalBeosztasTermekDatumTerminalSzerint(CommObject.termekMozgatasLekerdezesStruct termekMozgatasAdatok)
    {
        CommObject toResponse = new CommObject();
        TerminalBeosztas tb = SzerverKontroller.terminalBeosztasok.getTerminalBeosztas(termekMozgatasAdatok.termekAzonosito, 
                                                                                        DateTime.Parse(termekMozgatasAdatok.idopont),
                                                                                        termekMozgatasAdatok.terminalAzonosito);
        toResponse.termekAzonosito = termekMozgatasAdatok.termekAzonosito;
        Termek termek = tb.getTermek();
        foreach (Raklap r in termek.getRaklapok())
        {
            toResponse.mozgoRaklapAdatok.Add(new CommObject.mozgoRaklapAdatokStruct(r.getBelsoVonalkod(), false, ""));
        }

        return toResponse;
    }

    public override void termekBehozatal(string termek, List<CommObject.mozgoRaklapAdatokStruct> mozgoRaklapAdatok)
    {

        List<string> raklapok = new List<string>();
        List<bool> raktarban = new List<bool>();
        List<string> epseg = new List<string>();
        
        foreach (CommObject.mozgoRaklapAdatokStruct mra in mozgoRaklapAdatok)
        {
            raklapok.Add(mra.raklap);
            raktarban.Add(mra.bejott);
            epseg.Add(mra.epseg);
        }

        SzerverKontroller.raktar.termekBehozatal(termek, raklapok, raktarban, epseg);
    }

    public override void termekKivitel(string termek, List<CommObject.mozgoRaklapAdatokStruct> mozgoRaklapAdatok)
    {
        List<string> raklapok = new List<string>();
        List<string> epseg = new List<string>();

        foreach (CommObject.mozgoRaklapAdatokStruct mra in mozgoRaklapAdatok)
        {
            raklapok.Add(mra.raklap);
            epseg.Add(mra.epseg);
        }

        SzerverKontroller.raktar.termekKivitel(termek, raklapok, epseg);
    }
}
