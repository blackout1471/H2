using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring
{
    public class NetworkIdentifier
    {
        public NetworkIdentifier()
        {
            
        }

        /// <summary>
        /// Gets the ip adresses from a given hostname
        /// </summary>
        /// <param name="hostname"></param>
        /// <returns></returns>
        public IPAddress[] GetIpAdressesFromDomain(string hostname)
        {
            IPAddress[] adresses;
            try
            {
                adresses = Dns.GetHostAddresses(hostname);
            }
            catch (Exception e)
            {

                throw e;
            }

            return adresses;
        }

        /// <summary>
        /// Get host name from an ip
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public string GetHostNameFromIp(string ip)
        {
            string hostName = "";

            try
            {
                hostName = Dns.GetHostEntry(ip).HostName;
            }
            catch (Exception e)
            {
                throw e;
            }

            return hostName;
        }

        /// <summary>
        /// Pings the local machine
        /// </summary>
        /// <returns></returns>
        public PingReply Ping()
        {
            IPAddress local = IPAddress.Loopback;
            PingReply reply;

            try
            {
                reply = Ping(local.ToString());
            }
            catch (Exception e)
            {
                throw e;
            }

            return reply;
        }

        /// <summary>
        /// Ping an ip or hostname
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public PingReply Ping(string ip)
        {
            Ping ping = new Ping();
            PingReply reply;

            try
            {
                reply = ping.Send(ip);
            }
            catch (Exception e)
            {
                throw e;
            }
            

            return reply;
        }

        /// <summary>
        /// Traces a hostname and returns the time it takes between each hop and the ip
        /// </summary>
        /// <param name="hostname"></param>
        /// <param name="maxHops"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public TraceResult[] TraceRouteHostname(string hostname, int maxHops, int timeout)
        {
            List<TraceResult> results = new List<TraceResult>();

            try
            {
                IPAddress address = Dns.GetHostEntry(hostname).AddressList[0];

                using (Ping pingSender = new Ping())
                {

                    PingOptions pingOptions = new PingOptions();
                    Stopwatch stopWatch = new Stopwatch();
                    byte[] bytes = new byte[32];

                    pingOptions.DontFragment = true;
                    pingOptions.Ttl = 1;
                    int _maxHops = maxHops;


                    for (int i = 1; i < maxHops + 1; i++)
                    {
                        stopWatch.Reset();
                        stopWatch.Start();

                        PingReply pingReply = pingSender.Send(
                            address,
                            timeout,
                            new byte[32], pingOptions);

                        stopWatch.Stop();

                        string ip = (pingReply.Address != null) ? pingReply.Address.ToString() : "";

                        results.Add(new TraceResult((int)stopWatch.ElapsedMilliseconds, ip));

                        if (pingReply.Status == IPStatus.Success)
                            break;

                        pingOptions.Ttl++;

                    }
                }

            }
            catch (Exception e)
            {
                throw e;
            }

            return results.ToArray();
        }

        /// <summary>
        /// Get all the ip addresses for the different network interfaces
        /// </summary>
        /// <returns></returns>
        public IPAddress[] GetAllDhcpServers()
        {
            List<IPAddress> dhcpadresses = new List<IPAddress>();

            try
            {
                NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface adapter in adapters)
                {
                    IPInterfaceProperties adapteradapterProperties = adapter.GetIPProperties();
                    IPAddressCollection addresses = adapteradapterProperties.DhcpServerAddresses;

                    for (int i = 0; i < addresses.Count; i++)
                    {
                        dhcpadresses.Add(addresses[i]);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            
            return dhcpadresses.ToArray();
        }
    }
}
