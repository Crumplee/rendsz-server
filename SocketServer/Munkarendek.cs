using System;
using System.Collections.Generic;
using Communication;

public class Munkarendek
{
    List<Munkarend> munkarendek = new List<Munkarend>();
	public Munkarendek()
	{

	}

    public void addMunkarend(Munkarend munkarend)
    {
        munkarendek.Add(munkarend);
    }

    public List<Munkarend> getMunkarendek()
    {
        return munkarendek;
    }
}
