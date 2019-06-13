using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Midi;

namespace MidiGameBoi
{
    public partial class NoteViewer : Form
    {
        private bool _canClose = false;
        public NoteViewer()
        {
            InitializeComponent();
        }

        private void NoteViewer_Load(object sender, EventArgs e)
        {

        }

        public void AddNote(NoteOnMessage msg)
        {
            if (!Visible) return;

            if (this.InvokeRequired)
            {
                Invoke(new MethodInvoker(() => AddNote(msg)));
                return;
            }

            if(noteListBox.Items.Count > 100)
                noteListBox.Items.Clear();

            noteListBox.Items.Add(new ListViewItem(new string[] 
            {
                Enum.GetName(typeof(Pitch), msg.Pitch),
                ((int)msg.Pitch).ToString(),
                msg.Channel.Name()
            }));
        }

        public void CloseViewer()
        {
            _canClose = true;
            Close();
        }

        private void NoteViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_canClose)
            {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
