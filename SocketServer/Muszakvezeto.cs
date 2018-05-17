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

       

        string log = DateTime.Now.ToString() + " - " + getAzonosito() + " - " + "addMunkarend" + " - " + ujmunkarend.toLog();
        Logger.Instance().logs.Add(log);

        SzerverKontroller.munkarendek.munkarendek.Clear();
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

        Termek t = SzerverKontroller.raktar.getTermek(azonosito);
        //string log = DateTime.Now.ToString() + " - " + getAzonosito() + " - " + "termekBehozatal" + " - " + t.toLog();
       // Logger.Instance().logs.Add(log);
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

        Termek t = SzerverKontroller.raktar.getTermek(azonosito);
        //string log = DateTime.Now.ToString() + " - " + getAzonosito() + " - " + "termekKivitel" + " - " + t.toLog();
        //Logger.Instance().logs.Add(log);
    }

    public override CommObject munkarendekLekerdezes()
    {
        CommObject toResponse = new CommObject();
        List<Munkarend> munkarendek = SzerverKontroller.munkarendek.getMunkarendek();

        foreach (Munkarend munkarend in munkarendek)
        {
            toResponse.beosztasokAdatokLista.Add(new CommObject.beosztasAdatokStruct(munkarend.getDolgozoAzonosito(), munkarend.getDatum(), munkarend.getMuszakSorszam()));
        }

        return toResponse;
    }

    public override CommObject termekeSzurtListazasa(CommObject.termekAdatokStruct adatok)
    {
        CommObject toResponse = new CommObject();

        Termek termekSzurok = new Termek(adatok.megrendeloAzonosito, adatok.termekNev, adatok.kulsoVonalkod, adatok.tipus,
                                         DateTime.Parse(adatok.beIdopont), DateTime.Parse(adatok.kiIdopont), 0, adatok.raklapAdatok);



        List<Termek> termekek = SzerverKontroller.raktar.getTermekLista(termekSzurok);

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

    public override CommObject getTerminalBeosztasok(CommObject.terminalBeosztasLekerdezesStruct terminalBeosztasLekerdezes)
    {
        CommObject toResponse = new CommObject();
        List<TerminalBeosztas> terminalbeosztasok = new List<TerminalBeosztas>();

        //Console.WriteLine(terminalBeosztasLekerdezes.tipus + " " + terminalBeosztasLekerdezes.idopont + " " + terminalBeosztasLekerdezes.hutott);

        switch (terminalBeosztasLekerdezes.tipus)
        {
            case "datum":
                terminalbeosztasok = SzerverKontroller.terminalBeosztasok.getTerminalBeosztasokDatumSzerint(DateTime.Parse(terminalBeosztasLekerdezes.idopont));
                break;
            case "terminal":
                terminalbeosztasok = SzerverKontroller.terminalBeosztasok.getTerminalBeosztasokTerminalSzerint(terminalBeosztasLekerdezes.terminal);
                break;
            case "datumEsHutottseg":
                terminalbeosztasok = SzerverKontroller.terminalBeosztasok.getTerminalBeosztasokDatumEsTipusSzerint(DateTime.Parse(terminalBeosztasLekerdezes.idopont),
                                                                                                                    terminalBeosztasLekerdezes.hutott);
                //Console.WriteLine("terminalbeosztasok szama: " + terminalbeosztasok.Count);
                break;
            default:
                break;
        }


        foreach (TerminalBeosztas tb in terminalbeosztasok)
        {
            toResponse.terminalBeosztasAdatokLista.Add(new CommObject.terminalBeosztasAdatokStruct(tb.getIdopont().ToString(),
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
