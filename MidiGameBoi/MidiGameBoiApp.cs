using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using MidiGameBoi.Utils;
using Midi;
using NLog;

namespace MidiGameBoi
{
    /// <summary>
    /// Main class for the program
    /// </summary>
    internal class MidiGameBoiApp : ApplicationContext
    {
        public NotifyIcon AppIcon { get { return _appIcon; } }
        public NoteViewer NoteViewerForm { get { return _noteViewer; } }

        private static Logger Logger = LogManager.GetLogger("LogFile");

        private readonly Form1 _mainForm;
        private readonly NotifyIcon _appIcon;
        private readonly NoteViewer _noteViewer;


        private readonly IntPtr _gameWindow;
        private bool _canQuit = false;
        private bool _mouseClickOn = false;

        public MidiGameBoiApp()
        {
            LogManager.ThrowConfigExceptions = true;
            LogManager.ThrowExceptions = true;
            Logger logger = LogManager.GetLogger("LogFile");
            //logger.Info("hi");

            _appIcon = new NotifyIcon();
            _noteViewer = new NoteViewer();

            _mainForm = new Form1(this);
            _mainForm.FormClosing += _mainForm_FormClosing;
            _mainForm.OnSetMidi += _mainForm_OnSetMidi;
            _mainForm.Show();

            this.MainForm = _mainForm;

            _appIcon.Icon = SystemIcons.Question;
            _appIcon.Visible = true;

            _appIcon.DoubleClick += _appIcon_DoubleClick;

            _appIcon.ContextMenu = new ContextMenu();

            var quitItem = new MenuItem("Exit");
            quitItem.Click += delegate { _canQuit = true; _mainForm.Close(); };
            _appIcon.ContextMenu.MenuItems.Add(quitItem);

            _gameWindow = WindowUtil.FindWindowByTitle("Minecraft");
   
        }

        private void _mainForm_OnSetMidi(InputDevice device)
        {
            InitMidi(device);
        }

        private void _mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        private void _appIcon_DoubleClick(object sender, EventArgs e)
        {
            _mainForm.Show();
        }

        /// <summary>
        /// Initalize MIDI input device if present
        /// </summary>
        bool InitMidi(InputDevice midiIn)
        {
            midiIn.NoteOn += MidiIn_NoteOn;
            midiIn.NoteOff += MidiIn_NoteOff;

            Logger.Info("Initalized MIDI device '{0}'", midiIn?.Name);

            return true;
        }

        /// <summary>
        /// "Key Up" midi event handler
        /// </summary>
        /// <param name="msg"></param>
        private void MidiIn_NoteOff(NoteOffMessage msg)
        {
            try
            {
                var maps = NoteControl.Mappings.Where(p => p.Value == msg.Pitch);
                foreach(var map in maps)
                    KeyboardUtil.Send(map.Key, true);

                var mouseMaps = NoteControl.MouseMappings.Where(p => p.Value == msg.Pitch);
                foreach (var map in mouseMaps)
                {
                    if(map.Key == Models.MouseBindType.LeftClick || map.Key == Models.MouseBindType.MiddleClick || map.Key == Models.MouseBindType.RightClick)
                    {
                        MouseButton btn = MouseButton.Left;
                        if (map.Key == Models.MouseBindType.LeftClick && (ConfigUtil.AppConfig.HoldLeftMouseClick || ConfigUtil.AppConfig.ToggleLeftMouseClick))
                            return;
                        if (map.Key == Models.MouseBindType.MiddleClick)
                            btn = MouseButton.Middle;
                        else if (map.Key == Models.MouseBindType.RightClick)
                            btn = MouseButton.Right;

                        KeyboardUtil.MouseClick(btn, true);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Midi note conversion failed(keyup): ");
            }
        }

        /// <summary>
        /// "Key Down" midi event handler
        /// </summary>
        /// <param name="msg"></param>
        private void MidiIn_NoteOn(NoteOnMessage msg)
        {
            try
            {
                var maps = NoteControl.Mappings.Where(p => p.Value == msg.Pitch);
                foreach (var map in maps)
                    KeyboardUtil.Send(map.Key);

                var mouseMaps = NoteControl.MouseMappings.Where(p => p.Value == msg.Pitch);
                foreach (var map in mouseMaps)
                {
                    if (map.Key == Models.MouseBindType.LeftClick || map.Key == Models.MouseBindType.MiddleClick || map.Key == Models.MouseBindType.RightClick)
                    {
                        MouseButton btn = MouseButton.Left;
                        if(btn == MouseButton.Left)
                        {
                            if (ConfigUtil.AppConfig.ToggleLeftMouseClick)
                            {
                                KeyboardUtil.MouseClick(btn, !_mouseClickOn);
                                _mouseClickOn = !_mouseClickOn;
                                Logger.Info("Mouse Click Toggle");

                                return;
                            }
                            else if (ConfigUtil.AppConfig.HoldLeftMouseClick)
                            {
                                if (_mouseClickOn) return;
                                _mouseClickOn = true;

                                var delay = ConfigUtil.AppConfig.HoldLeftMouseDelay;
                                Logger.Info("Mouse Delay On");
                                DelayReleaseMouse(delay);
                            }
                        }
                        else if (map.Key == Models.MouseBindType.MiddleClick)
                            btn = MouseButton.Middle;
                        else if (map.Key == Models.MouseBindType.RightClick)
                            btn = MouseButton.Right;

                        KeyboardUtil.MouseClick(btn, false);
                    }
                    else if (map.Key == Models.MouseBindType.WheelUp || map.Key == Models.MouseBindType.WheelDown)
                    {
                        ScrollWheelDirection dn = (map.Key == Models.MouseBindType.WheelUp) ? ScrollWheelDirection.Up : ScrollWheelDirection.Down;

                        KeyboardUtil.ScrollMouseWheel(dn, ConfigUtil.AppConfig.ScrollWheelClicks);
                    }
                    else
                    {
                        MouseMoveDirection md = MouseMoveDirection.Left;

                        if (map.Key == Models.MouseBindType.MoveLeft)
                            md = MouseMoveDirection.Left;

                        else if (map.Key == Models.MouseBindType.MoveRight)
                            md = MouseMoveDirection.Right;
                        else if (map.Key == Models.MouseBindType.MoveUp)
                            md = MouseMoveDirection.Up;
                        else if (map.Key == Models.MouseBindType.MoveDown)
                            md = MouseMoveDirection.Down;

                        KeyboardUtil.MouseMove(md, ConfigUtil.AppConfig.MouseSensitivity);
                    }
                }

                _noteViewer.AddNote(msg);
            }
            catch(Exception ex)
            {
                Logger.Error(ex, "Midi note conversion failed(keydown): ");
            }
        }

        async void DelayReleaseMouse(int delay)
        {
            await Task.Delay(delay * 1000);
            KeyboardUtil.MouseClick(MouseButton.Left, true);
            _mouseClickOn = false;

            Logger.Info("Mouse Delay Off");
        }


        protected override void Dispose(bool disposing)
        {
            _appIcon.Dispose();
            base.Dispose(disposing);
        }
    }
}
