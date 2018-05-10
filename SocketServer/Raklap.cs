using System;

public class Raklap
{
    string belsoVonalkod, raklaphelyAzonosito;
    string epsegBe, epsegKi;
    int mozgatasSzama;
    bool raktarban;

    public string getBelsoVonalkod()
    {
        return belsoVonalkod;
    }

    public string toString()
    {
        return belsoVonalkod + " | " + raklaphelyAzonosito;
    }

	public Raklap(string _belsoVonalkod, string _raklaphelyAzonosito,
                    string _epsegBe, string _epsegKi, int _mozgatasSzama, bool _raktarban)
	{
        belsoVonalkod = _belsoVonalkod;
        raklaphelyAzonosito = _raklaphelyAzonosito;
        epsegBe = _epsegBe;
        epsegKi = _epsegKi;
        mozgatasSzama = _mozgatasSzama;
        raktarban = _raktarban;

        //Console.WriteLine(raklaphelyAzonosito);
	}
}
