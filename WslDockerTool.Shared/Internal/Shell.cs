using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace WslDockerTool.Shared.Internal
{
    internal class Shell
    {
        public static String Execute(string progrem, string args)
        {
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = progrem;
            info.Arguments = args;
            info.RedirectStandardOutput = true;
            info.UseShellExecute = false;
            info.CreateNoWindow = true;

            Process p = new Process();
            p.StartInfo = info;
            p.Start();

            return p.StandardOutput.ReadToEnd();
        }
        public static string PowerShell(string command)
        {
            return Execute("powershell.exe", command);
        }
    }

    public class WSLCommand
    {
        static string wsl = "wsl ";

        public static string GetIfconfigEth0Inet()
        {
            var ret = Run("ifconfig eth0");
            var arr = ret.Split('\r', '\n').Where(o => !string.IsNullOrEmpty(o)).Where(o=>o.Contains("inet ")).ToList();
            if (arr.Count > 0) return arr[0];
            return "没有查询到转发地址";
        }
        

        public static string Run(string command)
        {
            if (string.IsNullOrEmpty(command))
                throw new ArgumentNullException(nameof(command));
            return Shell.PowerShell(wsl + command);
        }
    }

    internal class NetshInterfacePortProxyCommand
    {
        static string NetshInterfacePortProxy = "netsh interface portproxy ";

        public static string Add(PortProxyType portProxyType, string listenport,string listenaddress,string connectport,string connectaddress) 
            => Run($"add {Enum.GetName(typeof(PortProxyType),portProxyType)} listenport={listenport} listenaddress={listenaddress} connectport={connectport} connectaddress={connectaddress}");
        public static string Delete(PortProxyType portProxyType, string listenport, string listenaddress)
            => Run($"delete {Enum.GetName(typeof(PortProxyType), portProxyType)} listenport={listenport} listenaddress={listenaddress}");
        public static string Set(PortProxyType portProxyType, string listenport, string listenaddress, string connectport, string connectaddress)
            => Run($"set {Enum.GetName(typeof(PortProxyType), portProxyType)} listenport={listenport} listenaddress={listenaddress} connectport={connectport} connectaddress={connectaddress}");
        public static string All(PortProxyType portProxyType= PortProxyType.all) 
            => Run($"show {Enum.GetName(typeof(PortProxyType), portProxyType)}");
        public static string Reset()=>Run("reset");

        public static string Run(string command)
        {
            if (string.IsNullOrEmpty(command))
                throw new ArgumentNullException(nameof(command));
            return Shell.PowerShell(NetshInterfacePortProxy + command);
        }
    }

    public enum PortProxyType
    {
        all=0,
        v4tov4 =1, 
        v4tov6=2,
        v6tov4=3, 
        v6tov6=4
    }


}
