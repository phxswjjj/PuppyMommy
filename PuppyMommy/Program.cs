using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace EDC
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = (Configuration.DomainConfig)ConfigurationManager.GetSection("DomainConfig");
            var dogs = config.Dogs;
            foreach (Configuration.DogSection dog in dogs)
            {
                Console.WriteLine($"Watch={dog.Watch}");
                foreach (Configuration.SniffSection sniff in dog)
                {
                    Console.WriteLine($"Loader={sniff.Loader}, Feeder={sniff.Feeder}");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
