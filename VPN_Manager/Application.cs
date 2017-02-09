using System.Diagnostics;
using System;
using System.Threading;

namespace VPN_Manager {
  public class Application {
    public void Start(string path) {
      Process.Start(path);
    }

    public void Kill(string name) {
      var processes = Process.GetProcessesByName(name);

      foreach (var process in processes) {
        process.Kill();
      }
    }

    public void StartVpn(Vpn vpn, string vpnPath) {
      Process.Start(vpnPath);

      while (!vpn.IsConnected()) {
        Console.WriteLine("Is VPN Connected : " + vpn.IsConnected());
        Thread.Sleep(10000);
      }

      Console.WriteLine("Is VPN Connected : " + vpn.IsConnected());
      Console.WriteLine(vpn);
    }
  }
}
