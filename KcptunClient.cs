using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;

using System.IO;
using TinyJson;

namespace KcptunClient
{
    public partial class KcptunClient : Form
    {
        
        List<Tunnel> tunnels;
        Config config;

        public KcptunClient()
        {
            
            Process[] kcptunClients = Process.GetProcessesByName("KcptunClient");
            if (kcptunClients.Length > 1)
            {
                MessageBox.Show("KcptunClient已经在运行", "错误");
                System.Environment.Exit(0);
            }

            InitializeComponent();
            
            //清理已经存在kcptun进程
            Process[] legency = Process.GetProcessesByName("kcptun");
            if (legency.Length > 0)
            {
                foreach (Process process in legency)
                {
                    try
                    {
                        process.Kill();
                    }
                    catch (Exception ee)
                    {

                    }

                }
            }

            string path = AppDomain.CurrentDomain.BaseDirectory;

            string configPath = string.Format("{0}\\Config.json", path);
            if (!File.Exists(configPath))
            {
                FileStream fileStream = File.Create(configPath);  //创建文件
                fileStream.Close();
                StreamWriter streamWriter = new StreamWriter(configPath);  //创建写入流
                streamWriter.Write("{\n    \"enable\": True,\n    \"startUp\": False\n}");
                streamWriter.Flush();
                streamWriter.Close();
            }

            string configJSON = File.ReadAllText(configPath);
            config = configJSON.FromJson<Config>();
            trayContextMenuEnable.Checked = config.enable;
            trayContextMenuStartup.Checked = config.startUp;

            string kcptunClient = string.Format("{0}\\KcptunClient.json", path);
            if (!File.Exists(kcptunClient))
            {
                FileStream fileStream = File.Create(kcptunClient);
                fileStream.Close();
                StreamWriter streamWriter = new StreamWriter(kcptunClient);
                streamWriter.Write("[\n]");
                streamWriter.Flush();
                streamWriter.Close();
            }

            string serversJSON = File.ReadAllText(kcptunClient);
            try
            {
                tunnels = serversJSON.FromJson<List<Tunnel>>();
            }
            catch (IndexOutOfRangeException ee)
            {
                // 配置文件中还没有服务器，会引发一个System.IndexOutOfRangeException异常
                tunnels = new List<Tunnel>();
            }


            serversCheckedListBox.Items.Clear();
            foreach (Tunnel tunnel in tunnels)
            {
                string tip = String.Format("{0}->{1}:{2}", tunnel.localPort, tunnel.remoteAddress, tunnel.remotePort);
                serversCheckedListBox.Items.Add(tip);
                serversCheckedListBox.SetItemChecked(tunnels.IndexOf(tunnel), tunnel.enable);
                ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
                toolStripMenuItem.Name = string.Format("trayContextMenuServers{0}", tunnels.IndexOf(tunnel));
                toolStripMenuItem.Text = tip;
                toolStripMenuItem.CheckOnClick = true;
                toolStripMenuItem.Checked = tunnel.enable;
                toolStripMenuItem.Click += new EventHandler(trayContextMenuServersClick);
                trayContextMenuServers.DropDownItems.Insert(tunnels.IndexOf(tunnel), toolStripMenuItem);
                if (config.enable && tunnel.enable)
                {
                    toolStripMenuItem.Checked = true;
                    tunnel.connect();
                }
            }
            if (serversCheckedListBox.Items.Count != 0)
            {
                serversCheckedListBox.SelectedIndex = 0;
            }

            WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            tray.Visible = true;
            this.Hide();
        }

        private void trayContextMenuExitMouseDown(object sender, MouseEventArgs e)
        {
            foreach(Tunnel tunnel in tunnels)
            {
                if (tunnel.enable)
                {
                    tunnel.disconnect();
                }
                
            }

            //清理遗留进程
            Process[] legency = Process.GetProcessesByName("kcptun");
            if (legency.Length > 0)
            {
                foreach (Process process in legency)
                {
                    try
                    {
                        process.Kill();
                    }
                    catch(Exception ee)
                    {

                    }
                    
                }
            }

            this.Dispose();
            this.Close();
        }

        private void kcptunClientFormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            tray.Visible = true;
            this.Hide();
        }

        private void KcptunClientLoad(object sender, EventArgs e)
        {

            

        }

        private void trayContextMenuServersClick(Object sender, EventArgs e)
        {
            ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
            int index = trayContextMenuServers.DropDownItems.IndexOf(toolStripMenuItem);
            Tunnel tunnel = tunnels[index];
            tunnel.enable = !tunnel.enable;
            serversCheckedListBox.SetItemChecked(index, tunnel.enable);
            toolStripMenuItem.Checked = tunnel.enable;
            if (tunnel.enable)
            {
                tunnel.connect();
            }
            else
            {
                tunnel.disconnect();
            }
        }

        private void confirmButtonClick(object sender, EventArgs e)
        {

            string remoteAddress = remoteAddressTextBox.Text;
            if (remoteAddress != null && !"".Equals(remoteAddress))
            {
                int remotePort = int.Parse(remotePortTextBox.Text);
                int localPort = int.Parse(localPortTextBox.Text);
                string mode = modeComboBox.Text.ToLower();

                Tunnel t = tunnels[serversCheckedListBox.FindString(serversCheckedListBox.SelectedItem.ToString())];
                bool noChange = remoteAddress.Equals(t.remoteAddress) && remotePort == t.remotePort && localPort == t.localPort && mode.Equals(t.mode);
                if (!noChange)
                {
                    t.remoteAddress = remoteAddress;
                    t.remotePort = remotePort;
                    t.localPort = localPort;
                    t.mode = mode;
                    Utils.writeTunnels(tunnels);

                    if (config.enable && t.enable)
                    {
                        t.reConnect();
                    }
                }

                bool[] checkStates = new bool[tunnels.Count];
                foreach (string item in serversCheckedListBox.CheckedItems)
                {
                    int index = serversCheckedListBox.FindString(item);
                    checkStates[index] = true;
                }

                foreach (Tunnel tunnel in tunnels)
                {
                    int index = tunnels.IndexOf(tunnel);
                    if (tunnel.enable != checkStates[index])
                    {
                        tunnel.enable = checkStates[index];
                        Utils.writeTunnels(tunnels);

                        trayContextMenuServers.DropDownItems.RemoveAt(index);
                        ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
                        toolStripMenuItem.Name = string.Format("trayContextMenuServers{0}", tunnels.IndexOf(tunnel));
                        toolStripMenuItem.Text = string.Format("{0}->{1}:{2}", tunnel.localPort, tunnel.remoteAddress, tunnel.remotePort);
                        toolStripMenuItem.CheckOnClick = true;
                        toolStripMenuItem.Checked = tunnel.enable;
                        toolStripMenuItem.Click += new EventHandler(trayContextMenuServersClick);
                        trayContextMenuServers.DropDownItems.Insert(tunnels.IndexOf(tunnel), toolStripMenuItem);

                        if (config.enable && tunnel.enable)
                        {
                            tunnel.connect();
                        }
                        else
                        {
                            tunnel.disconnect();
                        }
                    }

                }
            }

            WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            tray.Visible = true;
            this.Hide();
        }

        private void cancleButtonClick(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            tray.Visible = true;
            this.Hide();
        }

        private void serversCheckedListBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            if (serversCheckedListBox.SelectedItem != null)
            {
                string item = serversCheckedListBox.SelectedItem.ToString();
                if (!"未配置的服务器".Equals(item))
                {
                    int index = serversCheckedListBox.FindString(item);
                    Tunnel tunnel = tunnels[index];
                    remoteAddressTextBox.Text = tunnel.remoteAddress;
                    remotePortTextBox.Text = tunnel.remotePort.ToString();
                    localPortTextBox.Text = tunnel.localPort.ToString();
                    modeComboBox.Text = tunnel.mode.ToUpper();
                }
                else
                {
                    remoteAddressTextBox.Text = "";
                    remotePortTextBox.Text = "";
                    localPortTextBox.Text = "";
                    modeComboBox.Text = "FAST1";
                }
            }
            else
            {
                remoteAddressTextBox.Text = "";
                remotePortTextBox.Text = "";
                localPortTextBox.Text = "";
                modeComboBox.Text = "FAST1";
            }
            
        }

        private void serverAddButtonClick(object sender, EventArgs e)
        {
            if (serversCheckedListBox.SelectedItem == null)
            {
                    bool isNull = (remoteAddressTextBox.Text.Equals("")) ||
                            (remotePortTextBox.Text.Equals("")) ||
                            (localPortTextBox.Text.Equals("")) ||
                            (modeComboBox.Text.Equals(""));
                    if (!isNull)
                    {

                        Tunnel tunnel = new Tunnel();
                        tunnel.remoteAddress = remoteAddressTextBox.Text;
                        try
                        {
                            tunnel.remotePort = Int32.Parse(remotePortTextBox.Text);
                            tunnel.localPort = Int32.Parse(localPortTextBox.Text);
                        }
                        catch
                        {
                            MessageBox.Show("请输入正确的端口号", "错误");
                            return;
                        }

                        tunnel.mode = modeComboBox.Text.ToLower();
                        tunnel.enable = true;


                        foreach (Tunnel t in tunnels)
                        {
                            if(t.localPort == tunnel.localPort)
                            {
                                string message = string.Format("本地端口{0}已被占用", tunnel.localPort);
                                MessageBox.Show(message, "错误");
                                return;
                            }
                        }
                        
                        tunnels.Add(tunnel);
                        Utils.writeTunnels(tunnels);

                        string tip = String.Format("{0}->{1}:{2}", tunnel.localPort, tunnel.remoteAddress, tunnel.remotePort);
                        serversCheckedListBox.Items.Insert(tunnels.Count - 1, tip);
                        serversCheckedListBox.SelectedIndex = 0;

                        serversCheckedListBox.SetItemChecked(0, true);
                        if (config.enable && tunnel.enable)
                        {
                            tunnel.connect();
                        }

                        ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
                        toolStripMenuItem.Name = string.Format("trayContextMenuServers{0}", tunnels.IndexOf(tunnel));
                        toolStripMenuItem.Text = tip;
                        toolStripMenuItem.CheckOnClick = true;
                        toolStripMenuItem.Checked = tunnel.enable;
                        toolStripMenuItem.Click += new EventHandler(trayContextMenuServersClick);
                        trayContextMenuServers.DropDownItems.Insert(tunnels.IndexOf(tunnel), toolStripMenuItem);
                    }
                    else
                    {
                        // 对应全部为空的情况
                        serversCheckedListBox.Items.Add("未配置的服务器");
                        serversCheckedListBox.SelectedIndex = 0;
                    }
                    
            }
            else
            {
                string item = serversCheckedListBox.SelectedItem.ToString();
                bool isNull = (remoteAddressTextBox.Text.Equals("")) ||
                    (remotePortTextBox.Text.Equals("")) ||
                    (localPortTextBox.Text.Equals("")) ||
                    (modeComboBox.Text.Equals(""));
                if ("未配置的服务器".Equals(item))
                {
                    if (!isNull)
                    {
                        Tunnel tunnel = new Tunnel();
                        tunnel.remoteAddress = remoteAddressTextBox.Text;
                        try
                        {
                            tunnel.remotePort = Int32.Parse(remotePortTextBox.Text);
                            tunnel.localPort = Int32.Parse(localPortTextBox.Text);
                        }
                        catch
                        {
                            MessageBox.Show("请输入正确的端口号", "错误");
                            return;
                        }
                        tunnel.mode = modeComboBox.Text.ToLower();
                        tunnel.enable = true;
                       
                        foreach (Tunnel t in tunnels)
                        {
                            if (t.localPort == tunnel.localPort)
                            {
                                string message = string.Format("本地端口{0}已被占用", tunnel.localPort);
                                MessageBox.Show(message, "错误");
                                return;
                            }
                        }

                        tunnels.Add(tunnel);
                        Utils.writeTunnels(tunnels);

                        string tip = String.Format("{0}->{1}:{2}", tunnel.localPort, tunnel.remoteAddress, tunnel.remotePort);
                        //serversCheckedListBox.SelectedIndex = tunnels.Count - 1;
                        //serversCheckedListBox.Items[tunnels.Count - 1] = tip;
                        serversCheckedListBox.Items.Insert(tunnels.Count - 1, tip);
                        serversCheckedListBox.SelectedIndex = tunnels.Count - 1;
                        serversCheckedListBox.Items.RemoveAt(tunnels.Count);
                        serversCheckedListBox.SetItemChecked(tunnels.Count - 1, true);
                        if (config.enable && tunnel.enable)
                        {
                            tunnel.connect();
                        }

                        ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
                        toolStripMenuItem.Name = string.Format("trayContextMenuServers{0}", tunnels.IndexOf(tunnel));
                        toolStripMenuItem.Text = tip;
                        toolStripMenuItem.CheckOnClick = true;
                        toolStripMenuItem.Checked = tunnel.enable;
                        toolStripMenuItem.Click += new EventHandler(trayContextMenuServersClick);
                        trayContextMenuServers.DropDownItems.Insert(tunnels.IndexOf(tunnel), toolStripMenuItem);
                    }

                }
                else
                {
                    serversCheckedListBox.Items.Add("未配置的服务器");
                    serversCheckedListBox.SelectedIndex = serversCheckedListBox.Items.Count - 1;
                }
            }
            
        }

        private void trayContextMenuServersEditClick(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            tray.Visible = true;
            this.Activate();
            this.Show();
        }

        private void trayContextMenuEnableClick(object sender, EventArgs e)
        {
            if (config.enable)
            {
                config.enable = false;
                trayContextMenuEnable.Checked = false;
                foreach(Tunnel tunnel in tunnels)
                {
                    if (tunnel.enable)
                    {
                        tunnel.disconnect();
                    }
                }
                Utils.writeConfig(config);
            }
            else
            {
                config.enable = true;
                trayContextMenuEnable.Checked = true;
                foreach (Tunnel tunnel in tunnels)
                {
                    if (tunnel.enable)
                    {
                        tunnel.connect();
                    }
                }
                Utils.writeConfig(config);
            }

        }

        private void trayContextMenuStartUpClick(object sender, EventArgs e)
        {
            
            config.startUp = !config.startUp;
            trayContextMenuStartup.Checked = config.startUp;
            ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
            toolStripMenuItem.Checked = config.startUp;

            string path = Process.GetCurrentProcess().MainModule.FileName;
            //RegistryKey localMachineKey = Registry.LocalMachine;
            //RegistryKey runKey = localMachineKey.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");

            RegistryKey runKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser,
                        Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32)
                    .OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);


            if (config.startUp)
            {
                runKey.SetValue("KcptunClient", path);
            }
            else
            {
                runKey.DeleteValue("KcptunClient", false);
            }
            
            runKey.Close();
            //localMachineKey.Close();
            Utils.writeConfig(config);
        }

        private void serverDeleteButtonClick(object sender, EventArgs e)
        {
            if(serversCheckedListBox.SelectedItem != null)
            {
                string item = serversCheckedListBox.SelectedItem.ToString();
                int index = serversCheckedListBox.SelectedIndex;
                if (!"未配置的服务器".Equals(item))
                {
                    
                    if(serversCheckedListBox.Items.Count != 1)
                    {
                        if (serversCheckedListBox.SelectedIndex == 0)
                        {
                            serversCheckedListBox.SelectedIndex = 1;
                        }
                        else if(serversCheckedListBox.SelectedIndex == serversCheckedListBox.Items.Count - 1)
                        {
                            serversCheckedListBox.SelectedIndex = index - 1;
                        }
                        else
                        {
                            serversCheckedListBox.SelectedIndex = index + 1;
                        }
                    }
                  
                    serversCheckedListBox.Items.RemoveAt(index);
                    trayContextMenuServers.DropDownItems.RemoveAt(index);
                    Tunnel tunnel = tunnels[index];
                    if (tunnel.enable)
                    {
                        tunnel.disconnect();
                    }
                    tunnels.RemoveAt(index);
                    Utils.writeTunnels(tunnels);
                }
                else
                {
                    serversCheckedListBox.SelectedIndex = index - 1;
                    serversCheckedListBox.Items.RemoveAt(index);
                }

            }
            
        }

        private void serversCheckedListBoxItemCheckStateChanged(object sender, ItemCheckEventArgs e)
        {
           
        }


        private void trayMouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                if (this.WindowState == FormWindowState.Normal)
                {
                    this.Hide();
                    tray.Visible = true;
                    this.WindowState = FormWindowState.Minimized;
                }
                else if (this.WindowState == FormWindowState.Minimized)
                {
                    this.Show();
                    this.Activate();
                    tray.Visible = true;
                    this.WindowState = FormWindowState.Normal;
                }
            }
        }
    }
}
