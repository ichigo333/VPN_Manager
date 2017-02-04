using System;
using System.Net;
using System.Threading;

namespace VPN_Manager {
  class MainClass {
    public static void Main() {
      var vpn = new Vpn();

      for (int i = 0; i < 20; i++) {
        Console.WriteLine("Is VPN Connected : " + vpn.IsConnected());
        Console.WriteLine(vpn);
        //Console.WriteLine("Current IP       : " + GetCurrentIP());

        Thread.Sleep(10000);
      }
      Console.WriteLine("DONE");
      Console.ReadKey();
    }



    public static string GetCurrentIP() {
      var client = new WebClient();
      client.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.BypassCache);

      string downloadString = client.DownloadString("https://api.ipify.org");
      return downloadString;
    }
  }
}
