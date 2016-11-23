using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace KcptunClient
{
    class Tunnel
    {
        public string remoteAddress;
        public int remotePort;
        public int localPort;
        public string mode;
        public bool enable;
        public string args;
        public Process process;

        public void connect()
        {

               process = new Process();
               args = string.Format("-r \"{0}:{1}\" -l \":{2}\" -mode \"{3}\"", remoteAddress, remotePort, localPort, mode);
               process.StartInfo.FileName = "kcptun";
               process.StartInfo.Arguments = args;
               process.StartInfo.WorkingDirectory = "./";
               process.StartInfo.UseShellExecute = false;
               process.StartInfo.CreateNoWindow = true;
               process.Start();
        }

        public void disconnect()
        {
            try
            {
                process.Kill();
            }
            catch (Exception e)
            {
                
            }
            
        }

        public void reConnect()
        {
            disconnect();
            connect();
        }


    }
}
