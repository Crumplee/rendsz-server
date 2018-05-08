﻿using System;
using Communication;

public class SzerverKontroller
{
    private static SzerverKontroller instance = new SzerverKontroller();
    
    public static Raktar raktar = new Raktar("Raktar", "Raktar utca 420", "xxXRaktar69Xxx");
    public static Munkarendek munkarendek = new Munkarendek();

    private SzerverKontroller()
	{
	}
    
    public static SzerverKontroller Instance()
    {
        if (instance == null)
        {
            //Console.WriteLine("létrehozzaa");
            instance = new SzerverKontroller();
        }
        return instance;
    }

    

    public CommObject Valasz(CommObject request, ref Dolgozo user)
    {
        CommObject response = new CommObject();
        switch (request.Message)
        {
            case "bejelentkezes":
                Autentikator aut = new Autentikator();
                user = aut.autentikacio(request.bejelentkezesadatok.azonosito, request.bejelentkezesadatok.vonalkod);
                if (user != null)
                {
                    response.Message = user.getJogosultsag();
                    Console.WriteLine(user);
                }
                else
                {
                    response.Message = "hiba";
                }
                break;
            case "kijelentkezes":
                user = null;
                response.Message = "kijelentkezes_sikeres";
                break;
            case "szabadRaklaphelyekListazasa":
                response = user.getSzabadRaklaphelyekTipusSzerint(request.hutott);
                response.Message = "szabadRaklaphelyek";
                break;
            case "behozandoTermekRogzitese":
                user.behozandoTermekRegisztralasa(request.termekAdatok);
                response.Message = "Rogzitve";
                break;
            case "termekekListazasa":
                response = user.termekekListazasa();
                response.Message = "termekekLista";
                break;
            case "munkarendHozzaadas":
                user.munkarendHozzaadas(request.beosztasAdatok);
                response.Message = "munkarendHozzaadva";
                break;
            case "munkarendLekerdezes":
                response = user.munkarendLekerdezes(); ;
                break;
            default:
                break;
        }
        return response;
    }


}