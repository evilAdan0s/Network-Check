using System;
using System.Net;
using System.Net.Sockets;

namespace Network_Check
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            if (args.Length >= 2)
            {
                switch (args[0])
                {
                    case "-h":
                        if (program.getHTTPResponse(args[1]) == true)
                        {
                            Console.WriteLine("[*] HTTP can be used !");
                        }
                        else
                        {
                            Console.WriteLine("[!] HTTP has been disabled!");
                        }
                        break;
                    case "-t":
                        if (program.getTCPResponse(args[1], int.Parse(args[2])) == true)
                        {
                            Console.WriteLine("[*] TCP can be used !");
                        }
                        else
                        {
                            Console.WriteLine("[!] TCP has been disabled!");
                        }
                        break;
                    case "-d":
                        IPAddress[] ipAddresses = program.getDNSResponse(args[1]);
                        if (ipAddresses != null)
                        {
                            foreach (var ip in ipAddresses)
                            {
                                Console.WriteLine("[*] DNS: {0}  {1}",args[1], ip);
                            }
                        }
                        break;
                }
            }
            else
            {
                Console.WriteLine("[!] ERROR: Please check argument");
            }
        }

        private bool getHTTPResponse(string url)
        {
            string target = "http://" + url ;
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(target);
            request.Method = "HEAD";
            request.Timeout = 8000;
            try
            {
                HttpWebResponse response = (HttpWebResponse) request.GetResponse();
                
                return true;
            }
            catch (WebException e)
            {
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private bool getTCPResponse(string ip, int port)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork ,SocketType.Stream, ProtocolType.Tcp);
            try
            {
                socket.Connect(ip, port);
                socket.Close();
                return true;
            }
            catch (Exception e)
            {
                socket.Close();
                return false;
            }
        }

        private IPAddress[] getDNSResponse(string domainName)
        {

            try
            {
                IPAddress[] ip = Dns.GetHostAddresses(domainName);
                return ip;
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("[!] ERROR: Please check argument");
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
            
        }
    }
}