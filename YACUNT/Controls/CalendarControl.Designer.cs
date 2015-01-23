namespace YACUNT.Controls
{
    partial class CalendarControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listEvents = new System.Windows.Forms.ListBox();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // listEvents
            // 
            this.listEvents.Dock = System.Windows.Forms.DockStyle.Left;
            this.listEvents.FormattingEnabled = true;
            this.listEvents.Location = new System.Drawing.Point(0, 0);
            this.listEvents.Name = "listEvents";
            this.listEvents.Size = new System.Drawing.Size(182, 256);
            this.listEvents.TabIndex = 0;
            this.listEvents.DoubleClick += new System.EventHandler(this.listEvents_DoubleClick);
            // 
            // panelInfo
            // 
            this.panelInfo.AutoScroll = true;
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInfo.Location = new System.Drawing.Point(182, 0);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(560, 256);
            this.panelInfo.TabIndex = 1;
            // 
            // CalendarControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelInfo);
            this.Controls.Add(this.listEvents);
            this.Name = "CalendarControl";
            this.Size = new System.Drawing.Size(742, 256);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listEvents;
        private System.Windows.Forms.Panel panelInfo;
    }
}
