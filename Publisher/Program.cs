using Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publisher
{
     internal class Program
     {
          static void Main(string[] args)
          {
               Console.WriteLine("Publisher");

               var publisherSocket = new PublisherSocket();

               publisherSocket.Connect(Settings.BROKER_IP, Settings.BROKER_PORT);

               if (publisherSocket.IsConnected)
               {
                    while (true)
                    {
                         var payload = new Payload();

                         Console.WriteLine("Enter the topic: ");
                         payload.Topic = Console.ReadLine().ToLower();

                         Console.WriteLine("Enter the message: ");
                         payload.Message = Console.ReadLine();

                         var payloadString = JsonConvert.SerializeObject(payload); // serializare transformare in json
                         byte[] data = Encoding.UTF8.GetBytes(payloadString);

                         publisherSocket.Send(data);
                    }
               }

               Console.ReadLine();
          }
     }
}
