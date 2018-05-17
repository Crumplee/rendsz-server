using System;
using System.Collections.Generic;
using Communication;

public class Munkarendek
{
    public List<Munkarend> munkarendek = new List<Munkarend>();
	public Munkarendek()
	{

	}

    public void addMunkarend(Munkarend munkarend)
    {
        munkarendek = Fajlkezelo.Instance().loadMunkarendek();
        munkarendek.Add(munkarend);
        Fajlkezelo.Instance().saveMunkarendek(munkarendek);
    }

    public List<Munkarend> getMunkarendek()
    {
        return Fajlkezelo.Instance().loadMunkarendek();
    }
}
