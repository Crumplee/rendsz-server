using Communication;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Collections.Generic;

namespace SocketServer
{
    public class AsyncService
    {
        private IPAddress ipAddress;
        private int port;

        public AsyncService(int port)
        {
            this.port = port;
            
            this.ipAddress = IPAddress.Loopback;
            if (this.ipAddress == null)
                throw new Exception("No IPv4 address for server");
        }
        public async void Run()
        {
            /*
            //init, töröld majd
            SzerverKontroller.dolgozok.init();
            
            List<string> raklapokk = new List<string>();
            raklapokk.Add("H1");
            Terminal tm = new Terminal("HT1", true);
            Termek tk = new Termek("asd", "lol", "kek", "H", DateTime.Parse("2000-01-01"), DateTime.Parse("2010-01-01"), 1, raklapokk);
            SzerverKontroller.terminalBeosztasok.terminalBeosztasLetrehozasa(new TerminalBeosztas(DateTime.Parse("2000-01-01"), 1, tk, "be", tm));
            */

            TcpListener listener = new TcpListener(this.ipAddress, this.port);
            listener.Start();
            Console.Write("Test socket service is now running");
            Console.WriteLine(" " + this.ipAddress + " on port " + this.port);
            Console.WriteLine("Hit <enter> to stop service\n");
            while (true)
            {
                try
                {
                    TcpClient tcpClient = await listener.AcceptTcpClientAsync();
                    Task t = Process(tcpClient);
                }
                catch (Exception ex)
                { 
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private async Task Process(TcpClient tcpClient)
        {
            Dolgozo user = null;
            string clientEndPoint = tcpClient.Client.RemoteEndPoint.ToString();
            Console.WriteLine("Received connection request from " + clientEndPoint);
            try
            {
                NetworkStream networkStream = tcpClient.GetStream();
                StreamReader reader = new StreamReader(networkStream);
                StreamWriter writer = new StreamWriter(networkStream);
                writer.AutoFlush = true;
                
                JavaScriptSerializer serializer = new JavaScriptSerializer();

                

                while (true)
                {
                    string requestStr = await reader.ReadLineAsync();
                    if (requestStr != null)
                    {
                        //Console.WriteLine(i);
                        CommObject request = serializer.Deserialize<CommObject>(requestStr);
                        Console.WriteLine("Received service request: " + request);

                        SzerverKontroller szerverKontroller = SzerverKontroller.Instance();
                        CommObject response = szerverKontroller.Valasz(request, ref user);

                        //Console.WriteLine("Computed response is: " + response + "\n");
                        await writer.WriteLineAsync(serializer.Serialize(response));
                    }
                    else
                    {
                        Console.WriteLine("Connection closed, client: " + clientEndPoint);
                        break; // Client closed connection
                    }
                }
                tcpClient.Close();
            }
            catch (Exception ex)
            {                
                if (tcpClient.Connected)
                {                    
                    tcpClient.Close();
                }
                Console.WriteLine("Error connection closed, client: " + clientEndPoint);
                Console.WriteLine(ex.Message);
            }
        }
        /*
        private static CommObject Response(CommObject request, ref Dolgozo user)
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

                    response.lista = raktar.getSzabadRaklaphelyekTipusSzerint(request.hutott);
                    break;
                case "behozandoTermekRogzitese":
                    raktar.behozandoTermekRogzitese(request.termekAdatok);
                    response.Message = "Rogzitve";
                    break;
                case "termekekListazasa":

                    response = raktar.getTermekLista();
                    break;
                case "munkarendHozzaadas":
                    Console.WriteLine(request.beosztasAdatok.datum);
                    munkarendek.addMunkarend(request.beosztasAdatok);
                    response.Message = "Hozzaadva";
                    break;
                case "munkarendLekerdezes":
                    response = munkarendek.getMunkarendek();
                    break;
                default:
                    break;
            }

            return response;
        }*/

        /*
        private static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        private static string ToUpPeR(string s)
        {
            string res = "";
            for(int i = 0; i < s.Length; ++i)
            {
                if (i % 2 == 0)
                    res += char.ToUpper(s[i]);
                else
                    res += s[i];
            }
          
            res += "\n" + Mocking();
            return res;
        }

        private static string Mocking()
        {
            string[] lines = File.ReadAllLines("mocking.txt");
            string m = "";
            foreach (string line in lines)
            {
                m += line + "\n";
            }
            return m;
        }*/
        
    }
}
