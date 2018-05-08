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
                termek.getKulsovonalkod(), termek.getTipus(), termek.getBeIdopont(), termek.getKiIdopont(), termek.getMennyiseg(), new List<string>());
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
                                        adatok.beIdopont,
                                        adatok.kiIdopont,
                                        adatok.mennyiseg,
                                        adatok.raklaphelyek);

        SzerverKontroller.raktar.behozandoTermekRogzitese(ujTermek, adatok.raklaphelyek);
    }
}
