using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using AsterNET.Manager;
using AsterNET.Manager.Action;
using AsterNET.Manager.Event;
using AstTray.DirectoryHelpers;
using AstTray.UserControls;

namespace AstTray
{
    public partial class AstTray : Form
    {
        public AstTray()
        {
            InitializeComponent();

            // Add context menu item
            var click2CallMenuItem = new ToolStripClick2Call();
            click2CallMenuItem.Call += click2CallMenuItem_Call;
            // contextMenuStrip1.Items.Insert(0, click2CallMenuItem);
            this.toolStrip3.Items.Add(click2CallMenuItem);

            if (ConfigurationManager.AppSettings["astHost"] == null)
            {
                MessageBox.Show(
                    "Unable to read configuration file. Maybe you need to rename App.config.example to App.config and add your own details to it?");
                Environment.Exit(0);
            }

            try
            {
                AstCon = new ManagerConnection(ConfigurationManager.AppSettings["astHost"],
                    int.Parse(ConfigurationManager.AppSettings["astPort"]),
                    ConfigurationManager.AppSettings["astUser"], ConfigurationManager.AppSettings["astPass"]);

                AstCon.NewState += astCon_NewState;
                AstCon.Link += astCon_Link; // added to support AMI 1.0 (Asterisk 1.4)
                AstCon.ConnectionState += astCon_ConnectionState;
                AstCon.Login();

                // Load Directories
                if (ConfigurationManager.AppSettings["sharedDirectoryType"] != null)
                    switch (ConfigurationManager.AppSettings["sharedDirectoryType"].ToUpper())
                    {
                        case "CISCODIRECTORY":
                            SharedDiretory =
                                CiscoDirectoryHelper.GetCiscoDirectory(
                                    ConfigurationManager.AppSettings["sharedDirectoryPath"]);
                            break;
                    }

                // Load into views
                if (SharedDiretory != null)
                    foreach (var item in SharedDiretory)
                    {
                        sharedDirectoryListView.Items.Add(new ListViewItem(new[] {item.Name, item.Number}));
                    }

                astTrayNotify.ShowBalloonTip(3000, "Connected", "Connected to Asterisk", ToolTipIcon.Info);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error connecting to {ConfigurationManager.AppSettings["astHost"]}. Error: {ex.Message}");

                // Terminate Application
                Application.Exit();
            }
        }

        #region Private Methods

        private void FilterListView(ListView list, List<DirectoryEntry> source, string filter)
        {
            list.BeginUpdate();

            list.Items.Clear();

            var filteredList = source;

            if (!string.IsNullOrEmpty(filter))
            {
                filteredList = source.Where(x => x.Name.Contains(filter) || x.Number.Contains(filter)).ToList();
            }

            foreach (var item in filteredList)
            {
                list.Items.Add(new ListViewItem(new[] {item.Name, item.Number}));
            }

            list.EndUpdate();
        }

        #endregion

        #region Public Properties

        public ManagerConnection AstCon;
        public List<DirectoryEntry> SharedDiretory = new List<DirectoryEntry>();
        public List<DirectoryEntry> LocalDiretory = new List<DirectoryEntry>();

        #endregion

        #region UI Events

        private void toolStripTextBox2_TextChanged(object sender, EventArgs e)
        {
            FilterListView(myDirectoryListView, LocalDiretory, myDirectoryFitlerTxt.Text);
        }

        void click2CallMenuItem_Call(string numberToCall)
        {
            DialNumber(numberToCall);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AstCon.Logoff();
            AstCon = null;

            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://asttray.codeplex.com");
        }

        private void sharedDirectoryListView_DoubleClick(object sender, EventArgs e)
        {
            if (sharedDirectoryListView.SelectedItems.Count > 0)
            {
                DialNumber(sharedDirectoryListView.SelectedItems[0].SubItems[1].Text);
            }
        }

        private void callHistoryContextMenu_Opening(object sender, CancelEventArgs e)
        {
            if (callHistoryListView.SelectedItems.Count == 0)
                e.Cancel = true;
        }

        private void addToMyDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var calledNumber = callHistoryListView.SelectedItems[0].Text;
            var dirEditor = new FrmDirectoryEditor();
            if (dirEditor.ShowDialog() == DialogResult.OK)
            {
                // Create the entry
            }
        }

        private void addDirectoryEntryBtn_Click(object sender, EventArgs e)
        {
            var dirEditor = new FrmDirectoryEditor();
            if (dirEditor.ShowDialog() == DialogResult.OK)
            {
                // Create the entry
            }
        }

        private void DialNumber(string numberToCall)
        {
            try
            {
                var resp = AstCon.SendAction(new OriginateAction
                {
                    Channel =
                        ConfigurationManager.AppSettings["astPeerType"] + "/" +
                        ConfigurationManager.AppSettings["astPeerID"],
                    Exten = numberToCall,
                    Context = ConfigurationManager.AppSettings["astExtenContext"],
                    Priority = "1",
                    CallerId = ConfigurationManager.AppSettings["astExten"],
                    Timeout = 30000,
                    Async = true
                });
            }
            catch
            {
            }
        }

        #endregion

        #region Asterisk Events

        void astCon_ConnectionState(object sender, ConnectionStateEvent e)
        {
            // Connection state has changed
            connectionStateLbl.Text = AstCon.IsConnected() ? $"Connected to: {AstCon.Username}@{AstCon.Hostname}" : $"Disconnected, reconnecting to {AstCon.Hostname}...";
        }

        private void astCon_NewState(object sender, NewStateEvent e)
        {
            if (e.ChannelStateDesc != null)
            {
                Debug.Print("New state: " + e.ChannelStateDesc);
                if (
                    e.Channel.ToUpper()
                        .StartsWith(ConfigurationManager.AppSettings["astPeerType"] + "/" +
                                    ConfigurationManager.AppSettings["astPeerID"]))
                {
                    // this event related to me
                    switch (e.ChannelStateDesc.ToLower())
                    {
                        case "ringing":
                            astTrayNotify.ShowBalloonTip(3000, "Incoming Call",
                                $"Incoming call from {e.Connectedlinenum} ({e.ConnectedLineName})", ToolTipIcon.Info);

                            // Screen Popping
                            // Simple implementation at the moment
                            if (ConfigurationManager.AppSettings["ScreenPopPath"] != null)
                            {
                                var runString = ConfigurationManager.AppSettings["ScreenPopPath"];
                                runString = runString.Replace("{callerid-number}", e.Connectedlinenum);
                                runString = runString.Replace("{callerid-name}", e.ConnectedLineName);
                                runString = runString.Replace("{uniqueid}", e.UniqueId);

                                Process.Start(runString);
                            }
                            break;
                    }
                }
            }
        }

        private void astCon_Link(object sender, LinkEvent e)
        {
            if ((e.CallerId1 != e.CallerId2) && (e.Channel1 != e.Channel2))
            {
                // We have something to show.... the IDs are different....
                // Callerid1 is the callerid
                // Channel2 is the extn that answered

                var arrRegEx = Regex.Split(e.Channel2, "/.+-");
                var extn = e.Channel2;

                foreach (var foo in arrRegEx)
                {
                    extn = extn.Replace(foo, "");
                }

                extn = extn.Replace("/", "");
                extn = extn.Replace("-", "");

                astTrayNotify.ShowBalloonTip(3000, "Answered Call",
                    $"AMI 1.0 - Answered call from {e.CallerId1} on extn {extn}", ToolTipIcon.Info);
            }
        }

        #endregion
    }
}