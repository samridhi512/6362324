﻿using System;
using Confluent.Kafka;

class Program
{
    static async Task Main(string[] args)
    {
        var config = new ProducerConfig { BootstrapServers = "localhost:9092" };

        using var producer = new ProducerBuilder<Null, string>(config).Build();

        Console.WriteLine("Kafka Chat - Type your messages below (type 'exit' to quit):");

        while (true)
        {
            var input = Console.ReadLine();
            if (input == "exit") break;

            var message = new Message<Null, string> { Value = input };
            await producer.ProduceAsync("chat-topic", message);

            Console.WriteLine($"[Sent] {input}");
        }
    }
}
