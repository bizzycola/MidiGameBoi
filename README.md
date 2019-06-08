# MidiGameBoi
Simple, configurable, not well written .NET program to convert MIDI notes to keyboard/mouse events.

## Notice
This software works by hooking into a Windows library to handle the fancy under the hood pretend-to-be-a-user stuff and therefore will only work on Windows machines.

## Building From Source
Not much to say. I built it in Visual Studio 2019. Never checked if the project format is backwards compatible, but it'll probably open in 2017 if you try.

Once you build the program, run it once and it will generate config files for you to edit.

## Configuration
There are two configuration files for this program(in the Data folder, auto generated on run if not present):

### Config.json
This file currently contains two options: `MouseSensitivity` and `ScrollWheelClicks`. Those are probably somewhat self explainatory but I will explain anyway!

`MouseSensitivity` is how much on the X or Y axis to move the mouse on each hit of which ever note it is bound to.

`ScrollWheelClicks` is how many mouse wheel 'clicks'(the clicks you feel when you scroll) to scroll the wheel per hit of the bound MIDI note.

### Binds.json
This is the config file where you specify what midi note will be bound to what keyboard/mouse event.

There are two sections, `KeyBinds` and `MouseBinds`. Obviously, one is for binding to keyboard keys and the other mouse buttons/move/scroll events.

the "Key"(or "Event" for `MouseBinds`) should NOT be changed(though you are welcome to remove unused key/mouse binds from the config file assuming you know how to do it properly). This is the name for the ENUM value in the code that detects what key or mouse event it should bind to, so don't change it.

The "Pitch" is the one you want. That is the MIDI pitch note. A value between 0 and 127. If you don't know which note correlates to which note/keyboard key, here are two documents. One contains all the keyboard notes from C-1 to G9, the other contains commonly used MIDI percussion notes.

Keyboard Notes: [Keyboard-Notes](https://github.com/bizzycola/MidiGameBoi/wiki/Keyboard-Notes)

Percussion Notes: [Percussion-Notes](https://github.com/bizzycola/MidiGameBoi/wiki/Percussion-Notes)

