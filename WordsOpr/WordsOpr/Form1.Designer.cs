namespace WordsOpr
{
    partial class Form1
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
            this.btnSourceRead = new System.Windows.Forms.Button();
            this.btnTargetWrite = new System.Windows.Forms.Button();
            this.btnSwitch = new System.Windows.Forms.Button();
            this.txtSourceAddr = new System.Windows.Forms.TextBox();
            this.txtTargetAddr = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSourceRead
            // 
            this.btnSourceRead.Location = new System.Drawing.Point(456, 54);
            this.btnSourceRead.Name = "btnSourceRead";
            this.btnSourceRead.Size = new System.Drawing.Size(139, 49);
            this.btnSourceRead.TabIndex = 0;
            this.btnSourceRead.Text = "SourceRead";
            this.btnSourceRead.UseVisualStyleBackColor = true;
            this.btnSourceRead.Click += new System.EventHandler(this.btnSourceRead_Click);
            // 
            // btnTargetWrite
            // 
            this.btnTargetWrite.Location = new System.Drawing.Point(456, 125);
            this.btnTargetWrite.Name = "btnTargetWrite";
            this.btnTargetWrite.Size = new System.Drawing.Size(139, 54);
            this.btnTargetWrite.TabIndex = 1;
            this.btnTargetWrite.Text = "TargetWrite";
            this.btnTargetWrite.UseVisualStyleBackColor = true;
            this.btnTargetWrite.Click += new System.EventHandler(this.btnTargetWrite_Click);
            // 
            // btnSwitch
            // 
            this.btnSwitch.Location = new System.Drawing.Point(456, 208);
            this.btnSwitch.Name = "btnSwitch";
            this.btnSwitch.Size = new System.Drawing.Size(139, 54);
            this.btnSwitch.TabIndex = 2;
            this.btnSwitch.Text = "Switch";
            this.btnSwitch.UseVisualStyleBackColor = true;
            this.btnSwitch.Click += new System.EventHandler(this.btnSwitch_Click);
            // 
            // txtSourceAddr
            // 
            this.txtSourceAddr.Location = new System.Drawing.Point(82, 65);
            this.txtSourceAddr.Name = "txtSourceAddr";
            this.txtSourceAddr.Size = new System.Drawing.Size(333, 26);
            this.txtSourceAddr.TabIndex = 3;
            // 
            // txtTargetAddr
            // 
            this.txtTargetAddr.Location = new System.Drawing.Point(82, 125);
            this.txtTargetAddr.Name = "txtTargetAddr";
            this.txtTargetAddr.Size = new System.Drawing.Size(333, 26);
            this.txtTargetAddr.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 390);
            this.Controls.Add(this.txtTargetAddr);
            this.Controls.Add(this.txtSourceAddr);
            this.Controls.Add(this.btnSwitch);
            this.Controls.Add(this.btnTargetWrite);
            this.Controls.Add(this.btnSourceRead);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSourceRead;
        private System.Windows.Forms.Button btnTargetWrite;
        private System.Windows.Forms.Button btnSwitch;
        private System.Windows.Forms.TextBox txtSourceAddr;
        private System.Windows.Forms.TextBox txtTargetAddr;
    }
}

