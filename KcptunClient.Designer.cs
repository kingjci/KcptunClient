namespace KcptunClient
{
    partial class KcptunClient
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KcptunClient));
            this.tray = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.trayContextMenuEnable = new System.Windows.Forms.ToolStripMenuItem();
            this.trayContextMenuStartup = new System.Windows.Forms.ToolStripMenuItem();
            this.trayContextMenuServers = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.trayContextMenuServersEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.trayContextMenuLog = new System.Windows.Forms.ToolStripMenuItem();
            this.trayContextMenuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.trayContextMenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.serverAddButton = new System.Windows.Forms.Button();
            this.serverDeleteButton = new System.Windows.Forms.Button();
            this.serverGroupBox = new System.Windows.Forms.GroupBox();
            this.modeComboBox = new System.Windows.Forms.ComboBox();
            this.modeLabel = new System.Windows.Forms.Label();
            this.localPortLabel = new System.Windows.Forms.Label();
            this.localPortTextBox = new System.Windows.Forms.TextBox();
            this.targetProtLabel = new System.Windows.Forms.Label();
            this.remotePortTextBox = new System.Windows.Forms.TextBox();
            this.targetAddressLabel = new System.Windows.Forms.Label();
            this.remoteAddressTextBox = new System.Windows.Forms.TextBox();
            this.confirmButton = new System.Windows.Forms.Button();
            this.cancleButton = new System.Windows.Forms.Button();
            this.serversCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.trayContextMenu.SuspendLayout();
            this.serverGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // tray
            // 
            this.tray.ContextMenuStrip = this.trayContextMenu;
            this.tray.Icon = ((System.Drawing.Icon)(resources.GetObject("tray.Icon")));
            this.tray.Text = "KcptunClient";
            this.tray.Visible = true;
            this.tray.MouseClick += new System.Windows.Forms.MouseEventHandler(this.trayMouseClick);
            // 
            // trayContextMenu
            // 
            this.trayContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trayContextMenuEnable,
            this.trayContextMenuStartup,
            this.trayContextMenuServers,
            this.trayContextMenuLog,
            this.trayContextMenuAbout,
            this.trayContextMenuExit});
            this.trayContextMenu.Name = "trayContextMenu";
            this.trayContextMenu.Size = new System.Drawing.Size(149, 136);
            // 
            // trayContextMenuEnable
            // 
            this.trayContextMenuEnable.CheckOnClick = true;
            this.trayContextMenuEnable.Name = "trayContextMenuEnable";
            this.trayContextMenuEnable.Size = new System.Drawing.Size(148, 22);
            this.trayContextMenuEnable.Text = "启用系统加速";
            this.trayContextMenuEnable.Click += new System.EventHandler(this.trayContextMenuEnableClick);
            // 
            // trayContextMenuStartup
            // 
            this.trayContextMenuStartup.CheckOnClick = true;
            this.trayContextMenuStartup.Name = "trayContextMenuStartup";
            this.trayContextMenuStartup.Size = new System.Drawing.Size(148, 22);
            this.trayContextMenuStartup.Text = "开机启动";
            this.trayContextMenuStartup.Click += new System.EventHandler(this.trayContextMenuStartUpClick);
            // 
            // trayContextMenuServers
            // 
            this.trayContextMenuServers.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.trayContextMenuServersEdit});
            this.trayContextMenuServers.Name = "trayContextMenuServers";
            this.trayContextMenuServers.Size = new System.Drawing.Size(148, 22);
            this.trayContextMenuServers.Text = "服务器";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(142, 6);
            // 
            // trayContextMenuServersEdit
            // 
            this.trayContextMenuServersEdit.Name = "trayContextMenuServersEdit";
            this.trayContextMenuServersEdit.Size = new System.Drawing.Size(145, 22);
            this.trayContextMenuServersEdit.Text = "编辑服务器...";
            this.trayContextMenuServersEdit.Click += new System.EventHandler(this.trayContextMenuServersEditClick);
            // 
            // trayContextMenuLog
            // 
            this.trayContextMenuLog.Name = "trayContextMenuLog";
            this.trayContextMenuLog.Size = new System.Drawing.Size(148, 22);
            this.trayContextMenuLog.Text = "系统日志...";
            // 
            // trayContextMenuAbout
            // 
            this.trayContextMenuAbout.Name = "trayContextMenuAbout";
            this.trayContextMenuAbout.Size = new System.Drawing.Size(148, 22);
            this.trayContextMenuAbout.Text = "关于...";
            // 
            // trayContextMenuExit
            // 
            this.trayContextMenuExit.Name = "trayContextMenuExit";
            this.trayContextMenuExit.Size = new System.Drawing.Size(148, 22);
            this.trayContextMenuExit.Text = "退出";
            this.trayContextMenuExit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trayContextMenuExitMouseDown);
            // 
            // serverAddButton
            // 
            this.serverAddButton.Location = new System.Drawing.Point(27, 204);
            this.serverAddButton.Name = "serverAddButton";
            this.serverAddButton.Size = new System.Drawing.Size(62, 23);
            this.serverAddButton.TabIndex = 11;
            this.serverAddButton.Text = "添加";
            this.serverAddButton.UseVisualStyleBackColor = true;
            this.serverAddButton.Click += new System.EventHandler(this.serverAddButtonClick);
            // 
            // serverDeleteButton
            // 
            this.serverDeleteButton.Location = new System.Drawing.Point(108, 204);
            this.serverDeleteButton.Name = "serverDeleteButton";
            this.serverDeleteButton.Size = new System.Drawing.Size(66, 23);
            this.serverDeleteButton.TabIndex = 12;
            this.serverDeleteButton.Text = "删除";
            this.serverDeleteButton.UseVisualStyleBackColor = true;
            this.serverDeleteButton.Click += new System.EventHandler(this.serverDeleteButtonClick);
            // 
            // serverGroupBox
            // 
            this.serverGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.serverGroupBox.Controls.Add(this.modeComboBox);
            this.serverGroupBox.Controls.Add(this.modeLabel);
            this.serverGroupBox.Controls.Add(this.localPortLabel);
            this.serverGroupBox.Controls.Add(this.localPortTextBox);
            this.serverGroupBox.Controls.Add(this.targetProtLabel);
            this.serverGroupBox.Controls.Add(this.remotePortTextBox);
            this.serverGroupBox.Controls.Add(this.targetAddressLabel);
            this.serverGroupBox.Controls.Add(this.remoteAddressTextBox);
            this.serverGroupBox.Location = new System.Drawing.Point(196, 13);
            this.serverGroupBox.Name = "serverGroupBox";
            this.serverGroupBox.Size = new System.Drawing.Size(256, 185);
            this.serverGroupBox.TabIndex = 5;
            this.serverGroupBox.TabStop = false;
            this.serverGroupBox.Text = "服务器";
            // 
            // modeComboBox
            // 
            this.modeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modeComboBox.FormattingEnabled = true;
            this.modeComboBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.modeComboBox.Items.AddRange(new object[] {
            "FAST1",
            "FAST2",
            "FAST3"});
            this.modeComboBox.Location = new System.Drawing.Point(89, 142);
            this.modeComboBox.Name = "modeComboBox";
            this.modeComboBox.Size = new System.Drawing.Size(121, 20);
            this.modeComboBox.TabIndex = 10;
            // 
            // modeLabel
            // 
            this.modeLabel.AutoSize = true;
            this.modeLabel.Location = new System.Drawing.Point(16, 146);
            this.modeLabel.Name = "modeLabel";
            this.modeLabel.Size = new System.Drawing.Size(53, 12);
            this.modeLabel.TabIndex = 8;
            this.modeLabel.Text = "传输模式";
            // 
            // localPortLabel
            // 
            this.localPortLabel.AutoSize = true;
            this.localPortLabel.Location = new System.Drawing.Point(16, 105);
            this.localPortLabel.Name = "localPortLabel";
            this.localPortLabel.Size = new System.Drawing.Size(53, 12);
            this.localPortLabel.TabIndex = 8;
            this.localPortLabel.Text = "本地端口";
            // 
            // localPortTextBox
            // 
            this.localPortTextBox.Location = new System.Drawing.Point(86, 100);
            this.localPortTextBox.Name = "localPortTextBox";
            this.localPortTextBox.Size = new System.Drawing.Size(164, 21);
            this.localPortTextBox.TabIndex = 9;
            // 
            // targetProtLabel
            // 
            this.targetProtLabel.AutoSize = true;
            this.targetProtLabel.Location = new System.Drawing.Point(16, 67);
            this.targetProtLabel.Name = "targetProtLabel";
            this.targetProtLabel.Size = new System.Drawing.Size(65, 12);
            this.targetProtLabel.TabIndex = 8;
            this.targetProtLabel.Text = "服务器端口";
            // 
            // remotePortTextBox
            // 
            this.remotePortTextBox.Location = new System.Drawing.Point(86, 62);
            this.remotePortTextBox.Name = "remotePortTextBox";
            this.remotePortTextBox.Size = new System.Drawing.Size(164, 21);
            this.remotePortTextBox.TabIndex = 8;
            // 
            // targetAddressLabel
            // 
            this.targetAddressLabel.AutoSize = true;
            this.targetAddressLabel.Location = new System.Drawing.Point(17, 30);
            this.targetAddressLabel.Name = "targetAddressLabel";
            this.targetAddressLabel.Size = new System.Drawing.Size(53, 12);
            this.targetAddressLabel.TabIndex = 8;
            this.targetAddressLabel.Text = "服务器IP";
            // 
            // remoteAddressTextBox
            // 
            this.remoteAddressTextBox.Location = new System.Drawing.Point(86, 26);
            this.remoteAddressTextBox.Name = "remoteAddressTextBox";
            this.remoteAddressTextBox.Size = new System.Drawing.Size(164, 21);
            this.remoteAddressTextBox.TabIndex = 7;
            // 
            // confirmButton
            // 
            this.confirmButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.confirmButton.Location = new System.Drawing.Point(299, 229);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(62, 23);
            this.confirmButton.TabIndex = 13;
            this.confirmButton.Text = "确认";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButtonClick);
            // 
            // cancleButton
            // 
            this.cancleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancleButton.Location = new System.Drawing.Point(380, 229);
            this.cancleButton.Name = "cancleButton";
            this.cancleButton.Size = new System.Drawing.Size(66, 23);
            this.cancleButton.TabIndex = 14;
            this.cancleButton.Text = "取消";
            this.cancleButton.UseVisualStyleBackColor = true;
            this.cancleButton.Click += new System.EventHandler(this.cancleButtonClick);
            // 
            // serversCheckedListBox
            // 
            this.serversCheckedListBox.FormattingEnabled = true;
            this.serversCheckedListBox.HorizontalScrollbar = true;
            this.serversCheckedListBox.Location = new System.Drawing.Point(14, 15);
            this.serversCheckedListBox.Name = "serversCheckedListBox";
            this.serversCheckedListBox.Size = new System.Drawing.Size(176, 180);
            this.serversCheckedListBox.TabIndex = 6;
            this.serversCheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.serversCheckedListBoxItemCheckStateChanged);
            this.serversCheckedListBox.SelectedIndexChanged += new System.EventHandler(this.serversCheckedListBoxSelectedIndexChanged);
            // 
            // KcptunClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 274);
            this.Controls.Add(this.serversCheckedListBox);
            this.Controls.Add(this.serverGroupBox);
            this.Controls.Add(this.cancleButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.serverDeleteButton);
            this.Controls.Add(this.serverAddButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KcptunClient";
            this.Text = "KcptunClient";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.kcptunClientFormClosing);
            this.Load += new System.EventHandler(this.KcptunClientLoad);
            this.trayContextMenu.ResumeLayout(false);
            this.serverGroupBox.ResumeLayout(false);
            this.serverGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon tray;
        private System.Windows.Forms.ContextMenuStrip trayContextMenu;
        private System.Windows.Forms.ToolStripMenuItem trayContextMenuEnable;
        private System.Windows.Forms.ToolStripMenuItem trayContextMenuServers;
        private System.Windows.Forms.ToolStripMenuItem trayContextMenuServersEdit;
        private System.Windows.Forms.ToolStripMenuItem trayContextMenuStartup;
        private System.Windows.Forms.ToolStripMenuItem trayContextMenuLog;
        private System.Windows.Forms.ToolStripMenuItem trayContextMenuAbout;
        private System.Windows.Forms.ToolStripMenuItem trayContextMenuExit;
        private System.Windows.Forms.Button serverAddButton;
        private System.Windows.Forms.Button serverDeleteButton;
        private System.Windows.Forms.GroupBox serverGroupBox;
        private System.Windows.Forms.ComboBox modeComboBox;
        private System.Windows.Forms.Label modeLabel;
        private System.Windows.Forms.Label targetProtLabel;
        private System.Windows.Forms.TextBox remotePortTextBox;
        private System.Windows.Forms.Label targetAddressLabel;
        private System.Windows.Forms.TextBox remoteAddressTextBox;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button cancleButton;
        private System.Windows.Forms.Label localPortLabel;
        private System.Windows.Forms.TextBox localPortTextBox;
        private System.Windows.Forms.CheckedListBox serversCheckedListBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

