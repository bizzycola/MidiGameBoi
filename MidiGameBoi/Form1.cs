using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MidiGameBoi.Utils;
using Midi;
using NLog;

namespace MidiGameBoi
{
    
    /// <summary>
    /// Main form for the program interfact
    /// </summary>
    public partial class Form1 : Form
    {
        private static Logger Logger = LogManager.GetLogger("LogFile");

        public delegate void SetMidiEvent(InputDevice device);
        public delegate void ExitEvent();

        /// <summary>
        /// Called when the user has chosen a MIDI device and started listening
        /// </summary>
        /// <param name="device"></param>
        public event SetMidiEvent OnSetMidi;

        /// <summary>
        /// Called when the user hits the Exit button.
        /// </summary>
        public event ExitEvent OnExitClicked;

        /// <summary>
        /// Is the MIDI device currently engaged and listening
        /// </summary>
        bool isListening { get; set; }
        
        /// <summary>
        /// Selected MIDI device
        /// </summary>
        InputDevice Device { get; set; }

        NotifyIcon _appIcon;
        public Form1(NotifyIcon appIcon)
        {
            _appIcon = appIcon;

            InitializeComponent();

            if (!System.IO.File.Exists("Data\\Binds.json"))
                ConfigUtil.GenerateConfigFile();
            else
                ConfigUtil.LoadConfig();

            if (!System.IO.File.Exists("Data\\Config.json"))
                ConfigUtil.GenerateAppConfig();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadMidiDevices();
        }

        /// <summary>
        /// Loads a list of available MIDI devices and places them in the dropdown box
        /// </summary>
        void LoadMidiDevices()
        {
            var dd = midiInputBox;
            dd.Items.Clear();

            dd.Items.Add(new MidiInputOption() { IsTitle = true });

            var devices = InputDevice.InstalledDevices;
            foreach (var dev in devices)
                dd.Items.Add(new MidiInputOption() { Device = dev });

            if(dd.Items.Count > 1)
                dd.SelectedIndex = 1;
            else
                dd.SelectedIndex = 0;
        }

        /// <summary>
        /// Refreshes the MIDI dropdown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MidiRefreshBtn_Click(object sender, EventArgs e)
        {
            InputDevice.UpdateInstalledDevices();
            LoadMidiDevices();
        }

        /// <summary>
        /// Button to start or stop listening for MIDI events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListenBtn_Click(object sender, EventArgs e)
        {
            if (isListening)
            {
                StopListen();
            }
            else
            {
                var midiIn = (MidiInputOption)midiInputBox.SelectedItem;
                if (midiIn == null || midiIn.Device == null || midiIn.IsTitle)
                {
                    MessageBox.Show("Please select a valid MIDi device.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Device = midiIn.Device;
                StartListen();

                
            }
        }

        /// <summary>
        /// Opens the MIDI device and begins listening for events
        /// </summary>
        void StartListen()
        {
            try
            {
                if (Device == null || isListening) return;

                Device.Open();
                Device.StartReceiving(null);
                OnSetMidi?.Invoke(Device);

                isListening = true;
                listenBtn.Text = "Stop Listening";
                midiInputBox.Enabled = false;
                midiRefreshBtn.Enabled = false;

                Logger.Info("Started MIDI listening.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to open MIDI device: {ex.Message}.\nSee logs for more details.", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Fatal(ex, "Failed to open MIDI device: ");
            }
        }

        /// <summary>
        /// Closes the MIDI device and stops listening for events
        /// </summary>
        void StopListen()
        {
            try
            {
                if (Device == null || !isListening) return;

                Device.StopReceiving();
                Device.Close();

                isListening = false;
                listenBtn.Text = "Start Listening";
                midiInputBox.Enabled = true;
                midiRefreshBtn.Enabled = true;

                Logger.Info("Stopped MIDI listening.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to close MIDI device: {ex.Message}.\nSee logs for more details.", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Fatal(ex, "Failed to close MIDI device: ");
            }
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            if (_appIcon == null) return;

            _appIcon.ShowBalloonTip(1500, "Down Here!", "I'm now hidden in the task tray. Double click this icon to restore me.", ToolTipIcon.Info);
            _appIcon.BalloonTipClicked += delegate { Show(); };
            this.Hide();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopListen();

            OnExitClicked?.Invoke();
        }
    }

    public class MidiInputOption
    {
        public bool IsTitle { get; set; }
        public InputDevice Device { get; set; }

        public override string ToString()
        {
            if (IsTitle)
                return "Select a device..";
            else
                return Device.Name;

        }
    }
}
