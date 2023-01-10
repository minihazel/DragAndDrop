namespace DragAndDrop
{
    partial class mainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.lblplaceholder = new System.Windows.Forms.Label();
            this.successtimer = new System.Windows.Forms.Timer(this.components);
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lbldetected = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblplaceholder
            // 
            this.lblplaceholder.AllowDrop = true;
            this.lblplaceholder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblplaceholder.Location = new System.Drawing.Point(12, 9);
            this.lblplaceholder.Name = "lblplaceholder";
            this.lblplaceholder.Size = new System.Drawing.Size(560, 443);
            this.lblplaceholder.TabIndex = 0;
            this.lblplaceholder.Text = "Drag and drop your mod folder(s) here";
            this.lblplaceholder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblplaceholder.DragDrop += new System.Windows.Forms.DragEventHandler(this.lblplaceholder_DragDrop);
            this.lblplaceholder.DragEnter += new System.Windows.Forms.DragEventHandler(this.lblplaceholder_DragEnter);
            // 
            // successtimer
            // 
            this.successtimer.Interval = 2000;
            this.successtimer.Tick += new System.EventHandler(this.successtimer_Tick);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 459);
            this.progressBar.Maximum = 30;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(560, 10);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 1;
            this.progressBar.Visible = false;
            // 
            // lbldetected
            // 
            this.lbldetected.AllowDrop = true;
            this.lbldetected.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbldetected.AutoSize = true;
            this.lbldetected.Location = new System.Drawing.Point(13, 10);
            this.lbldetected.Name = "lbldetected";
            this.lbldetected.Size = new System.Drawing.Size(91, 15);
            this.lbldetected.TabIndex = 2;
            this.lbldetected.Text = "Detected server:";
            this.lbldetected.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.lbldetected);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblplaceholder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Drag & Drop";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblplaceholder;
        private System.Windows.Forms.Timer successtimer;
        private ProgressBar progressBar;
        private Label lbldetected;
    }
}