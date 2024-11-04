# MidiGameBoi
Simple, configurable, .NET program to convert MIDI notes to keyboard/mouse events.

Recently updated to run on .NET Core 9 (though still only works on Windows).

## Notice
This software works by hooking into a Windows library to handle the fancy under the hood pretend-to-be-a-user stuff and therefore will only work on Windows machines.

## Building From Source
Built with VS 2022. Standard process for building a .NET 9 project, the .NET 9 SDK is required.

Releases are published self-contained and single-file.

## Issues
* This app will not work at all if the Windows Task Manager has focus. 
This is a security precaution to prevent software overriding inputs when trying to exit them.

## Configuration
There are two configuration files for this program (in the Data folder, auto generated on run if not present):

### Config.json
This file currently contains 5 options:

`MouseSensitivity` is how much on the X or Y axis to move the mouse on each hit of which ever note it is bound to.

`ScrollWheelClicks` is how many mouse wheel 'clicks'(the clicks you feel when you scroll) to scroll the wheel per hit of the bound MIDI note.

`ToggleLeftMouseClick` Causes the left mouse button to be toggled on and off by the note hit(NoteOff event will be ignored)


`HoldLeftMouseClick` Causes the left mouse button to be held down until the binded MIDI note is triggered again. Also ignores NoteOff event.

`HoldLeftMouseDelay` Number of seconds to hold the mouse button down if the above option is enabled.

**Notice**: If you enabled ToggleLeftMouseButton and HoldLeftMouseButton, then the app will automatically disable HoldLeftMouseButton and log a warning to the log file. This will not overwrite your config, it will only be done internally.

### Binds.json
This is the config file where you specify what midi note will be bound to what keyboard/mouse event.

There are two sections, `KeyBinds` and `MouseBinds`. The first is for binding to keyboard keys and the other mouse buttons/move/scroll events.

the "Key" (or "Event" for `MouseBinds`) should NOT be changed (though you are welcome to remove unused key/mouse binds from the config file assuming you know how to do it properly). This is the name for the ENUM value in the code that detects what key or mouse event it should bind to, so don't change it.

The "Pitch" is the one you want. That is the MIDI pitch note. A value between 0 and 127. If you don't know which note correlates to which note/keyboard key, here are two documents. One contains all the keyboard notes from C-1 to G9, the other contains commonly used MIDI percussion notes.

Keyboard Notes: [Keyboard-Notes](https://github.com/bizzycola/MidiGameBoi/wiki/Keyboard-Notes)

Percussion Notes: [Percussion-Notes](https://github.com/bizzycola/MidiGameBoi/wiki/Percussion-Notes)
