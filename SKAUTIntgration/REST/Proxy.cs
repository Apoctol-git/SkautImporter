using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using xNet;

namespace SKAUTIntgration.REST
{
    public class Proxy: ProxyClient
    {
        public TcpClient Client { get; set; }
        public Proxy(ProxyType proxyType, string address, int port, string username, string password) : base(proxyType, address, port, username, password)
        {
            var a = CreateConnectionToProxy();
            Client = a;
        }

        public override TcpClient CreateConnection(string destinationHost, int destinationPort, TcpClient tcpClient = null)
        {
            return new TcpClient(_host, _port);
        }
    }
}
