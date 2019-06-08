namespace MidiGameBoi
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
            this.label1 = new System.Windows.Forms.Label();
            this.midiInputBox = new System.Windows.Forms.ComboBox();
            this.midiRefreshBtn = new System.Windows.Forms.Button();
            this.listenBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Midi Device:";
            // 
            // midiInputBox
            // 
            this.midiInputBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.midiInputBox.FormattingEnabled = true;
            this.midiInputBox.Location = new System.Drawing.Point(148, 6);
            this.midiInputBox.Name = "midiInputBox";
            this.midiInputBox.Size = new System.Drawing.Size(246, 33);
            this.midiInputBox.TabIndex = 1;
            // 
            // midiRefreshBtn
            // 
            this.midiRefreshBtn.Location = new System.Drawing.Point(400, 6);
            this.midiRefreshBtn.Name = "midiRefreshBtn";
            this.midiRefreshBtn.Size = new System.Drawing.Size(95, 33);
            this.midiRefreshBtn.TabIndex = 2;
            this.midiRefreshBtn.Text = "Refresh";
            this.midiRefreshBtn.UseVisualStyleBackColor = true;
            this.midiRefreshBtn.Click += new System.EventHandler(this.MidiRefreshBtn_Click);
            // 
            // listenBtn
            // 
            this.listenBtn.Location = new System.Drawing.Point(148, 92);
            this.listenBtn.Name = "listenBtn";
            this.listenBtn.Size = new System.Drawing.Size(162, 39);
            this.listenBtn.TabIndex = 3;
            this.listenBtn.Text = "Start Listening";
            this.listenBtn.UseVisualStyleBackColor = true;
            this.listenBtn.Click += new System.EventHandler(this.ListenBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(316, 92);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(78, 39);
            this.exitBtn.TabIndex = 4;
            this.exitBtn.Text = "Hide";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 134);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.listenBtn);
            this.Controls.Add(this.midiRefreshBtn);
            this.Controls.Add(this.midiInputBox);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "Midi GameBoi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox midiInputBox;
        private System.Windows.Forms.Button midiRefreshBtn;
        private System.Windows.Forms.Button listenBtn;
        private System.Windows.Forms.Button exitBtn;
    }
}

