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
                termek.getKulsovonalkod(), termek.getTipus(), termek.getBeIdopont(), termek.getKiIdopont(), termek.getMennyiseg(), new List<string>());
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
}
