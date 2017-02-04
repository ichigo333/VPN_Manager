using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;

namespace VPN_Manager {
  class MainClass {
    public static void Main() {

      for (int i = 0; i < 20; i++) {
        Console.WriteLine("Is VPN Connected : " + IsVPNConnected());
        Console.WriteLine("Current IP       : " + GetCurrentIP());

        Thread.Sleep(10000);
      }
      Console.WriteLine("DONE");
      Console.ReadKey();
    }

    public static bool IsVPNConnected() {
      if (NetworkInterface.GetIsNetworkAvailable()) {
        
        NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
        foreach (NetworkInterface Interface in interfaces) {
          if (Interface.OperationalStatus == OperationalStatus.Up &&
              Interface.Description == "TAP-Windows Adapter V9") {
            
            IPv4InterfaceStatistics statistics = Interface.GetIPv4Statistics();
            Console.WriteLine("================================================");
            Console.WriteLine("Name        : " + Interface.Name);
            Console.WriteLine("Description : " + Interface.Description);
            Console.WriteLine("ID          : " + Interface.Id);
            Console.WriteLine("Status      : " + Interface.OperationalStatus);
            Console.WriteLine("================================================");
                             
            return true;
          }
        }
      }
      return false;
    }

    public static string GetCurrentIP() {
      var client = new WebClient();
      client.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.BypassCache);

      string downloadString = client.DownloadString("https://api.ipify.org");
      return downloadString;
    }
  }
}
