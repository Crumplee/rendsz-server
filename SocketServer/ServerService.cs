using Communication;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace SocketServer
{
    public class AsyncService
    {
        static Raktar raktar = new Raktar("Raktar", "Raktar utca 420", "xxXRaktar69Xxx");
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
                        CommObject request = serializer.Deserialize<CommObject>(requestStr);
                        Console.WriteLine("Received service request: " + request);                       

                        CommObject response = Response(request);
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
                Console.WriteLine("Connection closed, client: " + clientEndPoint);
            }
        }
        private static CommObject Response(CommObject request)
        {
            CommObject response = new CommObject();
            switch (request.Message)
            {
                case "szabadRaklaphelyekListazasa":
                    response.lista = raktar.getSzabadRaklaphelyekTipusSzerint(request.hutott);
                    break;
                case "behozandoTermekRogzitese":
                    raktar.behozandoTermekRogzitese(request.termekAdatok);
                    break;
                default:
                    break;
            }

            return response;
            /*
            string reqdata = request.Message;
            char cmd = reqdata[0];

            string data = reqdata.Substring(1, reqdata.Length - 1);
            string response_str = "";
            switch (cmd)
            {
                case '1':
                    response_str = DateTime.Now.ToString();
                    break;
                case '2':
                    response_str = Reverse(data);
                    break;
                case '3':
                    response_str = ToUpPeR(data);
                    break;
                default:
                    response_str = cmd + data;
                    break;
            }
            CommObject response = new CommObject(response_str + " --(Server)--");
            return response;          
           */
        }

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
        }

    }
}
