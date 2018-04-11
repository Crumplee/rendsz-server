using System;

public class Raklap
{
    string belsoVonalkod, raklaphelyAzonosito;
    bool epsegBe, epsegKi;
    int mozgatasSzama;

    public string getBelsoVonalkod()
    {
        return belsoVonalkod;
    }

	public Raklap(string _belsoVonalkod, string _raklaphelyAzonosito,
                    bool _epsegBe, bool _epsegKi, int _mozgatasSzama)
	{
        belsoVonalkod = _belsoVonalkod;
        raklaphelyAzonosito = _raklaphelyAzonosito;
        epsegBe = _epsegBe;
        epsegKi = _epsegKi;
        mozgatasSzama = _mozgatasSzama;

        Console.WriteLine(raklaphelyAzonosito);
	}
}
