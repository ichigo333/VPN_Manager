using System;
using System.Net;
using System.Threading;

namespace VPN_Manager {
  class MainClass {
    public static void Main() {
      var vpn = new Vpn();
      var vpnPath = "C:\\Program Files\\pia_manager\\pia_manager.exe";
      var application = new Application();


      while (true) {
        application.Kill("pia_nw");
        application.Kill("pia_manager.exe");

        Thread.Sleep(10000);
        application.StartVpn(vpn, vpnPath);

        while (vpn.IsConnected()) {
          Console.Write("VPN is connected");
          for (int i = 0; i < 20; i++) {
            Console.Write(".");
            Thread.Sleep(1000);
          }
          Console.WriteLine();
        }
      }

    }

    public static string GetCurrentIP() {
      var client = new WebClient();
      client.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.BypassCache);

      string downloadString = client.DownloadString("https://api.ipify.org");
      return downloadString;
    }
  }
}
