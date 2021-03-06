﻿using RestBus.RabbitMQ;
using RestBus.RabbitMQ.Client;
using System;
using System.Net.Http;
using System.Text;

namespace Examples
{
    static class Basic
    {
        public async static void Run()
        {
            /*
             * An example that composes a HttpRequest Message and sends it via the RestBus RabbitMQ client.
             * 
             * For more examples, see the https://github.com/tenor/RestBus.Examples repo
             * 
             */

            //Start Web API 2 host to receive message.
            WebAPISelfHost host = new WebAPISelfHost();
            var servers = host.Start();

            //Create client
            BasicMessageMapper msgMapper = new BasicMessageMapper("amqp://localhost:5672", "test");
            //msgMapper = new QueueingMessageMapper("amqp://localhost:5672", "test"); //Uncomment this to only queue messages.

            RestBusClient client = new RestBusClient(msgMapper);

            //Compose message
            var msg = new System.Net.Http.HttpRequestMessage(System.Net.Http.HttpMethod.Post, "/api/test")
            {
                Content = new System.Net.Http.StringContent("{\"Val\":10}", new UTF8Encoding(), "application/json")
            };

            msg.Headers.Add("Accept", "application/json, text/javascript, */*; q=0.01, */*; q=0.01");

            //Send message
            Console.WriteLine("Sending Message ...");

            var res = await client.SendAsync(msg, System.Threading.CancellationToken.None);

            Console.WriteLine("Response Received:\n{0}\nContent:\n{1}\n", res, Encoding.UTF8.GetString((res.Content as ByteArrayContent).ReadAsByteArrayAsync().Result));

            Console.WriteLine("Press any key to quit.");
            Console.ReadKey();

            //Dispose client
            client.Dispose();
            //Dispose servers
            foreach(var server in servers) { server.Dispose(); }
        }
    }
}
