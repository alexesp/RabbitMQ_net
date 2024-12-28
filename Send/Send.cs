using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using RabbitMQ.Client;


   
        var factory = new ConnectionFactory() {HostName = "localhost"};
        //Console.Writeline("Send message!");
        using var connection = await factory.CreateConnectionAsync();
     
            using var channel = await connection.CreateChannelAsync();
           
               await channel.QueueDeclareAsync(queue: "hello", durable: false, exclusive:false,autoDelete:false,arguments:null);
                string message = "Hola Alex from RabbitMQ";
                var body = Encoding.UTF8.GetBytes(message);

               await channel.BasicPublishAsync(exchange: string.Empty,routingKey: "hello", body:body);
                Console.WriteLine($"[x] Sent {message}");
        
 
        Console.WriteLine("Press anty key to ext....");
        Console.ReadLine();
    