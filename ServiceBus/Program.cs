using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus;

namespace ServiceBus
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof(ServicioSaludo));
            host.AddServiceEndpoint(typeof(IServicioSaludo), new NetTcpBinding(), "net.tcp://localhost:6985/saludo");

            host.AddServiceEndpoint(typeof(IServicioSaludo), new NetTcpRelayBinding(), ServiceBusEnvironment.CreateServiceUri("sb", "Demo444", "saludo")).Behaviors.Add((new TransportClientEndpointBehavior()
            {
                TokenProvider = TokenProvider.CreateSharedSecretTokenProvider("owner", "58A9PGyNb5Qayh8zkYxAj0cDtAKKjlRcyvoyqJSr8do=")
            }));
            host.Open();
            Console.ReadLine();
        }
    }
}
