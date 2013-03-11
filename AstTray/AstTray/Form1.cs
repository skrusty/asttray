using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Asterisk.NET.Manager;
using Asterisk.NET.Manager.Action;

using System.Configuration;
using System.Diagnostics;

using AstTray.UserControls;

namespace AstTray
{
    public partial class AstTray : Form
    {

        public ManagerConnection astCon;

        public AstTray()
        {
            InitializeComponent();

            // Add context menu item
            var click2CallMenuItem = new ToolStripClick2Call();
            click2CallMenuItem.Call += click2CallMenuItem_Call;
            contextMenuStrip1.Items.Insert(0, click2CallMenuItem);

            try
            {
                astCon = new ManagerConnection(ConfigurationManager.AppSettings["astHost"], int.Parse(ConfigurationManager.AppSettings["astPort"]),
                    ConfigurationManager.AppSettings["astUser"], ConfigurationManager.AppSettings["astPass"]);

                astCon.NewState +=astCon_NewState;
                astCon.Login();

                astTrayNotify.ShowBalloonTip(3000, "Connected", "Connected to Asterisk", ToolTipIcon.Info);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error connecting to {0}. Error: {1}", 
                    ConfigurationManager.AppSettings["astHost"], 
                    ex.Message));
            }
        }

        void click2CallMenuItem_Call(string numberToCall)
        {
            try
            {
                astCon.SendAction(new OriginateAction()
                {
                    Channel = "Sip/" + ConfigurationManager.AppSettings["astExten"],
                    Exten = numberToCall,
                    Context = ConfigurationManager.AppSettings["astExtenContext"],
                    Priority = 1,
                    CallerId = ConfigurationManager.AppSettings["astExten"],
                    Timeout = 30000
                });
            }
            catch { }

        }

        private void astCon_NewState(object sender, Asterisk.NET.Manager.Event.NewStateEvent e)
        {
            Debug.Print("New state: " + e.ChannelStateDesc);
            if (e.Channel.ToUpper().StartsWith("SIP/" + ConfigurationManager.AppSettings["astExten"]))
            {
                // this event related to me
                switch (e.ChannelStateDesc.ToLower())
                {
                    case "ringing":
                        astTrayNotify.ShowBalloonTip(3000, "Incoming Call", string.Format("Incoming call from {0}", e.CallerIdNum), ToolTipIcon.Info);
                        break;
                }
            }
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

    }
}
