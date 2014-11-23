using System.Windows.Forms;

namespace AstTray.UserControls
{
    public class ToolStripClick2Call : ToolStripControlHost
    {

        public ToolStripClick2Call() : base(new Click2CallControl()) { }

        public Click2CallControl Click2CallControl
        {
            get { return Control as Click2CallControl; }
        }

        // Subscribe and unsubscribe the control events you wish to expose. 
        protected override void OnSubscribeControlEvents(Control c)
        {
            // Call the base so the base events are connected. 
            base.OnSubscribeControlEvents(c);

            Click2CallControl callControl = (Click2CallControl)c;

            // Add the event.
            callControl.Call +=
                new Click2CallControl.CallEventHandler(OnClick2Call);
        }

        protected override void OnUnsubscribeControlEvents(Control c)
        {
            // Call the base method so the basic events are unsubscribed. 
            base.OnUnsubscribeControlEvents(c);

            // Cast the control to a MonthCalendar control.
            Click2CallControl callControl = (Click2CallControl)c;

            // Remove the event.
            callControl.Call -=
                new Click2CallControl.CallEventHandler(OnClick2Call);
        }

        public event Click2CallControl.CallEventHandler Call;

        public void OnClick2Call(string numberToCall)
        {
            if (Call != null)
                Call(numberToCall);
        }

    }
}
