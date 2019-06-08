using Midi;
using MidiGameBoi.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiGameBoi.Models
{
    public class BindConfigModel
    {
        public List<KeyboardBindModel> KeyBinds { get; set; }
        public List<MouseBindModel> MouseBinds { get; set; }
    }
    public class KeyboardBindModel
    {
        public string Key { get; set; }
        public int Pitch { get; set; }
    }


    public enum MouseBindType
    {
        LeftClick,
        MiddleClick,
        RightClick,

        WheelUp,
        WheelDown,

        MoveLeft,
        MoveRight,
        MoveUp,
        MoveDown
    }
    public class MouseBindModel
    {
        public string Event { get; set; }
        public int Pitch { get; set; }
    }

    public class KeyBind
    {
        public Pitch Pitch { get; set; }
        public KeyboardUtil.ScanCodeShort Key { get; set; }

        public bool IsCtrl { get; set; }
        public bool IsShift { get; set; }

    }
}
