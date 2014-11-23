using AstTray.DirectoryHelpers;
using AstTray.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using AsterNET.Manager;
using AsterNET.Manager.Action;
using AsterNET.Manager.Event;

namespace AstTray
{
    public partial class AstTray : Form
    {

        #region Public Properties
        public ManagerConnection astCon;
        public List<DirectoryEntry> sharedDiretory = new List<DirectoryEntry>();
        public List<DirectoryEntry> localDiretory = new List<DirectoryEntry>();
        #endregion
        
        #region UI Events

        private void toolStripTextBox2_TextChanged(object sender, EventArgs e)
        {
            FilterListView(myDirectoryListView, localDiretory, this.myDirectoryFitlerTxt.Text);
        }

        void click2CallMenuItem_Call(string numberToCall)
        {
            DialNumber(numberToCall);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            astCon.Logoff();
            astCon = null;

            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://asttray.codeplex.com");
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
            string calledNumber = callHistoryListView.SelectedItems[0].Text;
            FrmDirectoryEditor dirEditor = new FrmDirectoryEditor();
            if (dirEditor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // Create the entry
            }
        }

        private void addDirectoryEntryBtn_Click(object sender, EventArgs e)
        {
            FrmDirectoryEditor dirEditor = new FrmDirectoryEditor();
            if (dirEditor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // Create the entry
            }
        }

        private void DialNumber(string numberToCall)
        {
            try
            {
                astCon.SendAction(new OriginateAction()
                {
                    Channel = ConfigurationManager.AppSettings["astPeerType"] + "/" + ConfigurationManager.AppSettings["astPeerID"],
                    Exten = numberToCall,
                    Context = ConfigurationManager.AppSettings["astExtenContext"],
                    Priority = "1",
                    CallerId = ConfigurationManager.AppSettings["astExten"],
                    Timeout = 30000
                });
            }
            catch { }
        }
        #endregion

        #region Asterisk Events

        void astCon_ConnectionState(object sender, ConnectionStateEvent e)
        {
            // Connection state has changed
            if (astCon.IsConnected())
                this.connectionStateLbl.Text = string.Format("Connected to: {0}@{1}", astCon.Username, astCon.Hostname);
            else
                this.connectionStateLbl.Text = string.Format("Disconnected, reconnecting to {0}...", astCon.Hostname);
        }
 
        private void astCon_NewState(object sender, NewStateEvent e)
        {
            if (e.ChannelStateDesc != null)
            {
                Debug.Print("New state: " + e.ChannelStateDesc);
                if (e.Channel.ToUpper().StartsWith(ConfigurationManager.AppSettings["astPeerType"] + "/" + ConfigurationManager.AppSettings["astPeerID"]))
                {
                    // this event related to me
                    switch (e.ChannelStateDesc.ToLower())
                    {
                        case "ringing":
                            astTrayNotify.ShowBalloonTip(3000, "Incoming Call",
                                string.Format("Incoming call from {0} ({1})",
                                    e.Attributes["connectedlinenum"], e.Attributes["connectedlinename"]), ToolTipIcon.Info);

                            // Screen Popping
                            // Simple implementation at the moment
                            if (ConfigurationManager.AppSettings["ScreenPopPath"] != null)
                            {
                                string runString = ConfigurationManager.AppSettings["ScreenPopPath"];
                                runString = runString.Replace("{callerid-number}", e.Attributes["connectedlinenum"]);
                                runString = runString.Replace("{callerid-name}", e.Attributes["connectedlinename"]);
                                runString = runString.Replace("{uniqueid}", e.UniqueId);

                                System.Diagnostics.Process.Start(runString);
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

                String[] arrRegEx = System.Text.RegularExpressions.Regex.Split(e.Channel2, "/.+-");
                String extn = e.Channel2;

                foreach (String foo in arrRegEx)
                {
                    extn = extn.Replace(foo, "");
                }

                extn = extn.Replace("/", "");
                extn = extn.Replace("-", "");

                astTrayNotify.ShowBalloonTip(3000, "Answered Call", string.Format("AMI 1.0 - Answered call from {0} on extn {1}", e.CallerId1, extn), ToolTipIcon.Info);

            }
        }


        #endregion

        #region Private Methods
        private void FilterListView(ListView list, List<DirectoryEntry> source, string filter)
        {
            list.BeginUpdate();

            list.Items.Clear();

            List<DirectoryEntry> filteredList = source;

            if (!string.IsNullOrEmpty(filter))
            {
                filteredList = source.Where(x => x.Name.Contains(filter) || x.Number.Contains(filter)).ToList();
            }

            foreach (var item in filteredList)
            {
                list.Items.Add(new ListViewItem(new string[] { item.Name, item.Number }));
            }

            list.EndUpdate();
        }
        #endregion
        
        public AstTray()
        {
            InitializeComponent();

            // Add context menu item
            var click2CallMenuItem = new ToolStripClick2Call();
            click2CallMenuItem.Call += click2CallMenuItem_Call;
            contextMenuStrip1.Items.Insert(0, click2CallMenuItem);
            // this.toolStrip1.Items.Add(click2CallMenuItem);

            if (ConfigurationManager.AppSettings["astHost"] == null)
            {
                MessageBox.Show("Unable to read configuration file. Maybe you need to rename App.config.example to App.config and add your own details to it?");
                Environment.Exit(0);
            }

            try
            {
                astCon = new ManagerConnection(ConfigurationManager.AppSettings["astHost"], int.Parse(ConfigurationManager.AppSettings["astPort"]),
                    ConfigurationManager.AppSettings["astUser"], ConfigurationManager.AppSettings["astPass"]);

                astCon.NewState +=astCon_NewState;
                astCon.Link += astCon_Link;         // added to support AMI 1.0 (Asterisk 1.4)
                astCon.ConnectionState += astCon_ConnectionState;
                astCon.Login();
                
                // Load Directories
                if(ConfigurationManager.AppSettings["sharedDirectoryType"] !=null)
                    switch (ConfigurationManager.AppSettings["sharedDirectoryType"].ToUpper())
                    {
                        case "CISCODIRECTORY":
                            sharedDiretory = CiscoDirectoryHelper.GetCiscoDirectory(ConfigurationManager.AppSettings["sharedDirectoryPath"]);
                            break;
                    }

                // Load into views
                if(sharedDiretory!=null)
                    foreach (var item in sharedDiretory)
                    {
                        this.sharedDirectoryListView.Items.Add(new ListViewItem(new string[] { item.Name, item.Number }));
                    }

                astTrayNotify.ShowBalloonTip(3000, "Connected", "Connected to Asterisk", ToolTipIcon.Info);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error connecting to {0}. Error: {1}", 
                    ConfigurationManager.AppSettings["astHost"], 
                    ex.Message));

                // Terminate Application
                Application.Exit();
            }
        }

    }
}
