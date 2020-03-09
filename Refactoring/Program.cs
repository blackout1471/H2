using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring
{
    class Program
    {
        private static NetworkIdentifier networkIdentifier;

        static void Main()
        {
            networkIdentifier = new NetworkIdentifier();

            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("Menu");
                Console.WriteLine("1. Get ips from hostname\n" +
                    "2. Ping ip/hostname\n" +
                    "3. Get Hostname from ip\n" +
                    "4. Traceroute an ip\n" +
                    "5. Display all dhcp servers\n" +
                    "6. Display local machines information\n");

                Console.WriteLine("Type q to quit");
                string ans = Console.ReadLine();
                Console.Clear();

                switch(ans)
                {
                    case "1":
                        GetIpsFromHostMenu();
                        break;
                    case "2":
                        PingMenu();
                        break;
                    case "3":
                        GetHostFromIpMenu();
                        break;
                    case "4":
                        TraceRouteHostMenu();
                        break;
                    case "5":
                        DisplayDHCPServersMenu();
                        break;
                    case "6":
                        DisplayLocalMachineInformationMenu();
                        break;
                    case "q":
                        running = false;
                        break;
                }
            }
        }

        /// <summary>
        /// Menu for when wanting to get ip from host name
        /// </summary>
        private static void GetIpsFromHostMenu()
        {
            Console.WriteLine("Get ip from hostname");
            Console.Write("Write hostname adress: ");
            string ans = Console.ReadLine();

            try
            {
                IPAddress[] addresses = networkIdentifier.GetIpAdressesFromDomain(ans);
                Console.WriteLine($"hostname: {ans}");

                for (int i = 0; i < addresses.Length; i++)
                {
                    Console.WriteLine($"{i}. {addresses[i].ToString()}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Menu for when wanting to get ip from host name
        /// </summary>
        private static void GetHostFromIpMenu()
        {
            Console.WriteLine("Get Hostname from ip");
            Console.Write("Write ip: ");
            string ans = Console.ReadLine();

            try
            {
                string host = networkIdentifier.GetHostNameFromIp(ans);
                Console.WriteLine($"hostname: {host}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Ping menu
        /// </summary>
        private static void PingMenu()
        {
            Console.WriteLine("Ping a ip/host");
            Console.Write("Write ip adress: ");
            string ans = Console.ReadLine();

            try
            {
                PingReply reply = networkIdentifier.Ping(ans);
                if (reply.Status == IPStatus.Success)
                    Console.WriteLine($"{reply.Address} took {reply.RoundtripTime} ms");
                else
                    Console.WriteLine($"Could not complete ping for unknown reason");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Trace route menu
        /// </summary>
        private static void TraceRouteHostMenu()
        {
            Console.WriteLine("TraceRoute a ip adress");
            Console.Write("Write ip adress / hostname: ");
            string host = Console.ReadLine();

            Console.Write("\nWrite max hops: ");
            string hops = Console.ReadLine();

            Console.Write("\nWrite timeout: ");
            string timeout = Console.ReadLine();

            try
            {
                int maxHops = int.Parse(hops);
                int maxTimeout = int.Parse(timeout);
                TraceResult[] results = networkIdentifier.TraceRouteHostname(host, maxHops, maxTimeout);

                for (int i = 0; i < results.Length; i++)
                {
                    Console.WriteLine($"{i}. {results[i].IpAddress} took {results[i].Ms} ms");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Displays all dhcp servers
        /// </summary>
        private static void DisplayDHCPServersMenu()
        {
            Console.WriteLine("Displaying Dhcp servers");

            try
            {
                IPAddress[] adresses = networkIdentifier.GetAllDhcpServers();

                for (int i = 0; i < adresses.Length; i++)
                {
                    Console.WriteLine($"{i}. {adresses[i].ToString()}");
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }

            Console.ReadKey();
           
        }

        /// <summary>
        /// Displays the local machines ip adresses and aliases
        /// </summary>
        private static void DisplayLocalMachineInformationMenu()
        {
            Console.WriteLine("Fetching data for local machine...");

            try
            {
                string hostName = Dns.GetHostName();
                IPHostEntry hostInfo = Dns.GetHostEntry(hostName);

                IPAddress[] address = hostInfo.AddressList;

                string[] aliases = hostInfo.Aliases;

                Console.WriteLine("Host name : " + hostInfo.HostName);
                Console.WriteLine("\nAliases : ");
                for (int index = 0; index < aliases.Length; index++)
                {
                    Console.WriteLine(aliases[index]);
                }
                Console.WriteLine("\nIP address list : ");
                for (int index = 0; index < address.Length; index++)
                {
                    Console.WriteLine(address[index]);
                }

            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }

            Console.ReadKey();
        }
    }
}
