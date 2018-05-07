using System;

public class Adminisztrator: Dolgozo
{
	public Adminisztrator(string _azonosito, string _vonalkod, string _nev, string _jogosultsag)
        :base(_azonosito, _vonalkod, _nev, _jogosultsag)
    {
      
    }

    public override void pempo()
    {
        Console.WriteLine("haggyukmá blizzárd");
    }
    
}
