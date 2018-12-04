using libCecCore;
using System;

namespace TestLibCec
{
    class Program
    {
        static void Main(string[] args)
        {
            var lirc = new WinLirc();
            lirc.SendMessage("LG_TV Power");

            using (var cecManager = new CecManager())
            {
                cecManager.Start();

                foreach(var device in cecManager.Scan())
                {
                    Console.WriteLine($"Device {device}");
                    //Console.WriteLine($"Name: {cecManager.GetName(device)}");
                    Console.WriteLine($"Vendor: {cecManager.GetVendor(device)}");
                    Console.WriteLine($"Power: {cecManager.GetPower(device)}");
                }
                //cecManager.SetStandby(CecLogicalAddress.TV);
                //Console.ReadKey();
                //cecManager.SetOn(CecLogicalAddress.TV);

                Console.ReadKey();
            }
        }
    }
}
