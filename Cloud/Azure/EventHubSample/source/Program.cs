using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.ServiceBus.Samples
{
    using System.Configuration;
    using Microsoft.ServiceBus.Messaging;
    using Microsoft.ServiceBus.Samples.SessionMessages;

    class Program
    {
        #region Fields

        static string eventHubName;
        static int numberOfMessages;
        static int numberOfPartitions;
        #endregion

        static void Main(string[] args)
        {
            //Initialize
            ParseArgs(args);
            string connectionString = GetServiceBusConnectionString();
            NamespaceManager namespaceManager = NamespaceManager.CreateFromConnectionString(connectionString);
            
            Manage.CreateEventHub(eventHubName, numberOfPartitions, namespaceManager);

            Receiver r = new Receiver(eventHubName, connectionString);
            r.MessageProcessingWithPartitionDistribution();

            Sender s = new Sender(eventHubName, numberOfMessages);
            s.SendEvents();

            Console.WriteLine("Press enter key to stop worker.");
            Console.ReadLine();
        }

        static void ParseArgs(string[] args)
        {
          
                eventHubName = "hwblreventhub";
                Console.WriteLine("ehnanme: " + eventHubName);

                numberOfMessages = 100;
                Console.WriteLine("NumberOfmessage: " + numberOfMessages);

                numberOfPartitions = 4;
                Console.WriteLine("numberOfPartitions: " + numberOfPartitions);
           
        }

        private static string GetServiceBusConnectionString()
        {
            string connectionString = ConfigurationManager.AppSettings["Microsoft.ServiceBus.ConnectionString"];
            if (string.IsNullOrEmpty(connectionString))
            {
                Console.WriteLine("Did not find Service Bus connections string in appsettings (app.config)");
                return string.Empty;
            }
            ServiceBusConnectionStringBuilder builder = new ServiceBusConnectionStringBuilder(connectionString);
            builder.TransportType = TransportType.Amqp;
            return builder.ToString();
        }
    }
}
