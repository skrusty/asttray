namespace AstTray
{
    partial class AstTray
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AstTray));
            this.astTrayNotify = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SuspendLayout();
            // 
            // astTrayNotify
            // 
            this.astTrayNotify.ContextMenuStrip = this.contextMenuStrip1;
            this.astTrayNotify.Icon = ((System.Drawing.Icon)(resources.GetObject("astTrayNotify.Icon")));
            this.astTrayNotify.Text = "AstTray";
            this.astTrayNotify.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // AstTray
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 98);
            this.Name = "AstTray";
            this.Text = "AstTray";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon astTrayNotify;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}

