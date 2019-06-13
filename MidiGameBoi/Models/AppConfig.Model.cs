using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiGameBoi.Models
{
    public class AppConfigModel
    {
        /// <summary>
        /// How many x/y positions to move the mouse per hit
        /// </summary>
        public int MouseSensitivity { get; set; }

        /// <summary>
        /// How many scroll wheel clicks to move per hit
        /// </summary>
        public int ScrollWheelClicks { get; set; }

        /// <summary>
        /// Whether or not to toggle the left mouse click on hit
        /// </summary>
        public bool ToggleLeftMouseClick { get; set; }

        /// <summary>
        /// Whether or not to hold the left mouse button down for a delay
        /// 
        /// Notice: using this and ToggleLeftClick at the same time will result in the app
        /// automatically disabling HoldLeftMouseClick and outputting a warning to the logs.
        /// 
        /// You can't do both at once. That's just silly.
        /// </summary>
        public bool HoldLeftMouseClick { get; set; }

        /// <summary>
        /// If HoldLeftMouseClick is enabled, how long to hold the mouse button down(in seconds) before releasing it.
        /// </summary>
        public int HoldLeftMouseDelay { get; set; }
    }
}
