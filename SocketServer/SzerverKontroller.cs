using System;
using Communication;

public class SzerverKontroller
{
    private static SzerverKontroller instance = new SzerverKontroller();
    
    public static Raktar raktar = new Raktar("Raktar", "Raktar utca 420", "xxXRaktar69Xxx");
    public static Munkarendek munkarendek = new Munkarendek();
    public static Dolgozok dolgozok = new Dolgozok();
    public static TerminalBeosztasok terminalBeosztasok = new TerminalBeosztasok();

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
                response = user.munkarendLekerdezes(user.getAzonosito());
                break;
            case "munkarendekLekerdezes":
                response = user.munkarendekLekerdezes();
                break;
            case "felhasznaloHozzaadasa":
                user.addFelhasznalo(request.felhasznaloAdatok);
                response.Message = "felhasznaloHozzaadva";
                break;
            case "felhasznalokListazasa":
                response = user.getDolgozok();
                break;
            case "felhasznaloTorlese":
                user.deleteFelhasznalo(request.felhasznaloAdatok.azonosito);
                response.Message = "felhasznaloTorolve";
                break;
            case "felhasznaloModositasa":
                user.modifyFelhasznalo(request.felhasznaloAdatok);
                response.Message = "felhasznaloModositva";
                break;
            case "terminalBeosztasTermekhez":
                user.terminalBeosztasLetrehozasa(request.terminalBeosztasAdatok);
                response.Message = "terminalBeosztasLetrehozva";
                break;
            case "terminalBeosztasokLekerdezes":
                response = user.getTerminalBeosztasok(request.terminalBeosztasLekerdezes);
                response.Message = "terminalBeosztas_" + request.terminalBeosztasLekerdezes.tipus;
                break;
            case "termekMozgatasLekerdezes":
                response = user.getTerminalBeosztasTermekDatumTerminalSzerint(request.termekMozgatasLekerdezes);
                break;
            case "termekBehozatal":
                user.termekBehozatal(request.termekAzonosito, request.mozgoRaklapAdatok);
                response.Message = "termekBehozatalRogzitve";
                break;
            case "termekKivitel":
                user.termekKivitel(request.termekAzonosito, request.mozgoRaklapAdatok);
                response.Message = "termekKivitelRogzitve";
                break;
            case "termekModositas":
                //Console.WriteLine("kapta halt");
                user.termekModositas(request.termekAzonosito, request.termekAdatok);
                response.Message = "termekModositva";
                break;
            case "termekTorlese":
                user.termekTorles(request.termekAzonosito);
                response.Message = "termekTorolve";
                break;
            case "termekSzurese":
                response = user.termekeSzurtListazasa(request.termekAdatok);
                break;
            case "logokListazasa":
                response.lista = user.logokListazasa();
                break;
            default:
                break;
        }
        return response;
    }




}
