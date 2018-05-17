using System;

public class Raklap
{
    public string belsoVonalkod, raklaphelyAzonosito;
    public string epsegBe, epsegKi;
    public int mozgatasSzama;
    public bool raktarban;

    public string getBelsoVonalkod()
    {
        return belsoVonalkod;
    }

    public string toString()
    {
        return belsoVonalkod + " | " + raklaphelyAzonosito;
    }

    public Raklap() { }

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

    public void setEpsegBe(string e)
    {
        epsegBe = e;
    }

    public void setRaktarban(bool r)
    {
        raktarban = r;
    }

    public string getEpsegBe()
    {
        return epsegBe;
    }

    public void setEpsegKi(string e)
    {
        epsegKi = e;
    }

    public string toLog()
    {
        string log = "";

        log += belsoVonalkod + " - " + raklaphelyAzonosito + " - " + epsegBe + " - " + epsegKi + " - " + mozgatasSzama.ToString() + " - "
            + raktarban.ToString();

        return log;
    }
}
