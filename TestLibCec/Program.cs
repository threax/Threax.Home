using libCecCore;
using System;

namespace TestLibCec
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var cecManager = new CecManager())
            {
                cecManager.Start();

                foreach(var device in cecManager.Scan())
                {
                    Console.WriteLine($"Device {device}");
                    Console.WriteLine($"Name: {cecManager.GetVendor(device)}");
                    Console.WriteLine($"Power: {cecManager.GetPower(device)}");
                }
                Console.ReadKey();
            }
        }
    }
}
