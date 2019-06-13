namespace MidiGameBoi
{
    partial class NoteViewer
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
            this.noteNameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.noteNumHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.noteChanHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.noteListBox = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // noteNameHeader
            // 
            this.noteNameHeader.Text = "Note Name";
            this.noteNameHeader.Width = 200;
            // 
            // noteNumHeader
            // 
            this.noteNumHeader.Text = "Note Number";
            this.noteNumHeader.Width = 200;
            // 
            // noteChanHeader
            // 
            this.noteChanHeader.Text = "Channel";
            this.noteChanHeader.Width = 200;
            // 
            // noteListBox
            // 
            this.noteListBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.noteNameHeader,
            this.noteNumHeader,
            this.noteChanHeader});
            this.noteListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.noteListBox.HideSelection = false;
            this.noteListBox.Location = new System.Drawing.Point(0, 0);
            this.noteListBox.Name = "noteListBox";
            this.noteListBox.Size = new System.Drawing.Size(606, 395);
            this.noteListBox.TabIndex = 0;
            this.noteListBox.UseCompatibleStateImageBehavior = false;
            this.noteListBox.View = System.Windows.Forms.View.Details;
            // 
            // NoteViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 395);
            this.Controls.Add(this.noteListBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "NoteViewer";
            this.Text = "NoteViewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NoteViewer_FormClosing);
            this.Load += new System.EventHandler(this.NoteViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColumnHeader noteNameHeader;
        private System.Windows.Forms.ColumnHeader noteNumHeader;
        private System.Windows.Forms.ColumnHeader noteChanHeader;
        private System.Windows.Forms.ListView noteListBox;
    }
}