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
                var power = cecManager.GetPower(0);
                Console.WriteLine(power);
                Console.ReadKey();
                power = cecManager.GetPower(0);
                Console.WriteLine(power);
                Console.ReadKey();
                power = cecManager.GetPower(0);
                Console.WriteLine(power);
                Console.ReadKey();
                power = cecManager.GetPower(0);
                Console.WriteLine(power);
                Console.ReadKey();
                power = cecManager.GetPower(0);
                Console.WriteLine(power);
                Console.ReadKey();
            }
        }
    }
}
