﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;


    
     
            var factory = new ConnectionFactory() {HostName = "localhost"};

            using var connection = await factory.CreateConnectionAsync();
            
                using var channel = await connection.CreateChannelAsync();
                
                  await channel.QueueDeclareAsync(queue:"hello",durable:false,exclusive:false,autoDelete:false, arguments:null);

                    var consumer = new AsyncEventingBasicConsumer(channel);

                    consumer.ReceivedAsync += (model, ea)=>
                    {
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);

                        Console.WriteLine($"[x] Received {message}");
                        return Task.CompletedTask;
                    };
                    await channel.BasicConsumeAsync(queue: "hello", autoAck:true, consumer:consumer);

                    Console.WriteLine("Press any key to exit...");
                    Console.ReadLine();

                
            
 