using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using MidiGameBoi.Models;
using Newtonsoft.Json;
using Midi;
using NLog;

namespace MidiGameBoi.Utils
{
    /// <summary>
    /// Handles configuration files
    /// </summary>
    internal class ConfigUtil
    {
        private static Logger Logger = LogManager.GetLogger("LogFile");

        public static BindConfigModel Config { get; set; }
        public static AppConfigModel AppConfig { get; set; }

        /// <summary>
        /// Loads the bind config
        /// </summary>
        public static void LoadConfig()
        {
            try
            {
                using (var sr = File.OpenText("Data\\Binds.json"))
                {
                    var js = new JsonSerializer();
                    Config = (BindConfigModel)js.Deserialize(sr, typeof(BindConfigModel));
                }

                using (var sr = File.OpenText("Data\\Config.json"))
                {
                    var js = new JsonSerializer();
                    AppConfig = (AppConfigModel)js.Deserialize(sr, typeof(AppConfigModel));
                }

                KeyboardUtil.ScanCodeShort kbs;
                NoteControl.Mappings.Clear();

                foreach (var kb in Config?.KeyBinds)
                {
                    if (kb.Pitch == -1) continue;

                    try
                    {
                        if (Enum.TryParse(kb.Key, out kbs))
                            NoteControl.Mappings.Add(kbs, (Pitch)kb.Pitch);
                    }
                    catch (ArgumentException ex)
                    {

                        Logger.Error(ex, "Failed to load bind config: ");
                    }
                }

                MouseBindType mbs;
                NoteControl.MouseMappings.Clear();

                foreach(var mb in Config?.MouseBinds)
                {
                    try
                    {
                        if (Enum.TryParse(mb.Event, out mbs))
                            NoteControl.MouseMappings.Add(mbs, (Pitch)mb.Pitch);
                    }
                    catch (ArgumentException ex)
                    {
                        Logger.Error(ex, "Failed to load bind config: ");
                    }
                }
            }
            catch(Exception ex)
            {
                Logger.Error(ex, "Failed to load bind config file: ");
            }
        }

        /// <summary>
        /// Saves the bind config
        /// </summary>
        public static void SaveConfig()
        {
            try
            {
                if (!Directory.Exists("Data"))
                    Directory.CreateDirectory("Data");

                using (StreamWriter sw = File.CreateText("Data\\Binds.json"))
                {
                    var js = new JsonSerializer();
                    js.Formatting = Formatting.Indented;
                    js.Serialize(sw, Config);
                }

                
            } catch(Exception ex)
            {
                Logger.Error(ex, "Failed to save bind config file: ");
            }
        }
        public static void SaveAppConfig()
        {
            try
            {
                using (StreamWriter sw = File.CreateText("Data\\Config.json"))
                {
                    var js = new JsonSerializer();
                    js.Formatting = Formatting.Indented;
                    js.Serialize(sw, AppConfig);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to save app config file: ");
            }
        }

        /// <summary>
        /// Generates a new bind config file
        /// </summary>
        public static void GenerateConfigFile()
        {
            try
            {
                var opts = Enum.GetNames(typeof(KeyboardUtil.ScanCodeShort));               
                var bindsModel = new List<KeyboardBindModel>();

                foreach (var opt in opts)
                {
                    bindsModel.Add(new KeyboardBindModel()
                    {
                        Key = opt,
                        Pitch = -1
                    });
                }

                var mOpts = Enum.GetNames(typeof(MouseBindType));
                var mouseModel = new List<MouseBindModel>();
                foreach(var opt in mOpts)
                {
                    mouseModel.Add(new MouseBindModel()
                    {
                        Event = opt,
                        Pitch = -1
                    });
                }


                var confModel = new BindConfigModel()
                {
                    KeyBinds = bindsModel,
                    MouseBinds = mouseModel
                };

                Config = confModel;
                SaveConfig();

                Logger.Info("Generated empty config file.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to generate default config: ");
            }
        }

        public static void GenerateAppConfig()
        {
            try
            {
                AppConfig = new AppConfigModel()
                {
                    MouseSensitivity = 15,
                    ScrollWheelClicks = 1
                };

                SaveAppConfig();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to generate default app config: ");
            }
        }
    }
}
