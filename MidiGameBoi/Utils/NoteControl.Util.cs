using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Midi;
using MidiGameBoi.Models;

namespace MidiGameBoi.Utils
{
    /// <summary>
    /// Dictionaries for converting between notes and keys.
    /// </summary>
    internal class NoteControl
    {
        /// <summary>
        /// Mapping between MIDI keys and Keyboard keys
        /// </summary>
        public static Dictionary<KeyboardUtil.ScanCodeShort, Pitch> Mappings = new Dictionary<KeyboardUtil.ScanCodeShort, Pitch>();
        public static Dictionary<MouseBindType, Pitch> MouseMappings = new Dictionary<MouseBindType, Pitch>();


        /// <summary>
        /// Mapping between string character(s) and Keyboard keys
        /// </summary>
        public static Dictionary<string, KeyboardUtil.ScanCodeShort> keyToCode = new Dictionary<string, KeyboardUtil.ScanCodeShort>
        {
            { "w", KeyboardUtil.ScanCodeShort.KEY_W },
            { "a", KeyboardUtil.ScanCodeShort.KEY_A },
            { "s", KeyboardUtil.ScanCodeShort.KEY_S },
            { "d", KeyboardUtil.ScanCodeShort.KEY_D },
            { "space", KeyboardUtil.ScanCodeShort.SPACE },
            { "e", KeyboardUtil.ScanCodeShort.KEY_E },
            { "esc", KeyboardUtil.ScanCodeShort.ESCAPE }
        };
    }
}
