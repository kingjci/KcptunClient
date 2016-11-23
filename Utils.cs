using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace KcptunClient
{
    static class Utils
    {
        public static void writeTunnels(List<Tunnel> tunnels)
        {
            StreamWriter streamWriter = new StreamWriter("./KcptunClient.json");
            streamWriter.Write("[\n");
            foreach(Tunnel tunnel in tunnels)
            {

                string json = string.Format("  {{\n     \"remoteAddress\": \"{0}\",\n     \"remotePort\": {1},\n     \"localPort\": {2},\n     \"mode\": \"{3}\",\n     \"enable\": {4}\n    }}", tunnel.remoteAddress, tunnel.remotePort.ToString(), tunnel.localPort.ToString(), tunnel.mode, tunnel.enable.ToString());
                streamWriter.Write(json);
                if(tunnels.IndexOf(tunnel) != tunnels.Count - 1)
                {
                    streamWriter.Write(",\n");
                }
            }
            streamWriter.Write("\n]");
            streamWriter.Flush();
            streamWriter.Close();
        }

        public static void writeConfig(Config config)
        {
            StreamWriter streamWriter = new StreamWriter("./Config.json");
            string json = string.Format("{{\n     \"enable\": {0},\n     \"startUp\": {1}\n}}", config.enable, config.startUp);
            streamWriter.Write(json);
            streamWriter.Flush();
            streamWriter.Close();
        }
    }
}