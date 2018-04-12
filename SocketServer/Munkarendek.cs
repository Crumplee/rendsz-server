using System;
using System.Collections.Generic;
using Communication;

public class Munkarendek
{
    List<Munkarend> munkarendek = new List<Munkarend>();
	public Munkarendek()
	{

	}

    public void addMunkarend(CommObject.beosztasAdatokStruct adatok)
    {
        munkarendek.Add(new Munkarend(adatok.dolgozoAzonosito, adatok.datum, adatok.muszakSorszam));
    }

    public CommObject getMunkarendek()
    {
        CommObject toResponse = new CommObject();
        foreach(Munkarend munkarend in munkarendek)
        {
            toResponse.beosztasokAdatokLista.Add(new CommObject.beosztasAdatokStruct(munkarend.getDolgozoAzonosito(),munkarend.getDatum(),munkarend.getMuszakSorszam()));
        }

        return toResponse;
    }
}
