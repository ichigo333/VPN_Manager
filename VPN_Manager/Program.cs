using System;
using System.Diagnostics;
using System.Net;
using System.Threading;

namespace VPN_Manager {
  class MainClass {
    public static void Main() {
      var vpn = new Vpn();
      var vpnPath = "C:\\Program Files\\pia_manager\\pia_manager.exe";

      while (true) {
        KillApplication("pia_manager.exe");
        //KillApplication("pia_nw");
        //KillApplication("openvpn");
        Thread.Sleep(10000);
        StartVpn(vpn, vpnPath);

        while (vpn.IsConnected()) {
          Console.Write("VPN is connected");
          for (int i=0; i < 20; i++) {
            Console.Write(".");
            Thread.Sleep(1000);
          }
          Console.WriteLine();
        }
      }
     
    }

    public static void StartVpn(Vpn vpn, string vpnPath) {
      StartApplication(vpnPath);

      while (!vpn.IsConnected()) {
        Console.WriteLine("Is VPN Connected : " + vpn.IsConnected());
        Thread.Sleep(10000);
      }

      Console.WriteLine("Is VPN Connected : " + vpn.IsConnected());
      Console.WriteLine(vpn);
    }

    public static void StartApplication(string path) {
      Process.Start(path);
    }

    public static void KillApplication(string name) {
      var processes = Process.GetProcessesByName(name);
 
      foreach (var process in processes) {
        process.
        process.Kill();
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
