using System.Net.NetworkInformation;
using System.Text;

namespace VPN_Manager {
    public class Vpn {

        public bool IsConnected() {
            if (GetVpnInterface() != null) {
                return true;
            }
            return false;
        }

        NetworkInterface GetVpnInterface() {
            if (NetworkInterface.GetIsNetworkAvailable()) {
                NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface Interface in interfaces) {
                    if (Interface.OperationalStatus == OperationalStatus.Up && Interface.Description == "TAP-Windows Adapter V9") {
                        return Interface;
                    }
                }
            }
            return null;
        }

        public override string ToString() {
            var Interface = GetVpnInterface();
            var stringBuilder = new StringBuilder();

            if (Interface != null) {
                stringBuilder.AppendLine("================================================");
                stringBuilder.AppendLine("Name        : " + Interface.Name);
                stringBuilder.AppendLine("Description : " + Interface.Description);
                stringBuilder.AppendLine("ID          : " + Interface.Id);
                stringBuilder.AppendLine("Status      : " + Interface.OperationalStatus);
                stringBuilder.AppendLine("================================================");
            }

            return stringBuilder.ToString();
        }

    }
}
