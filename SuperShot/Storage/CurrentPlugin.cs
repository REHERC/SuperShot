using System.Collections.Generic;
using Spectrum.API.Configuration;
using Spectrum.API.Logging;
using Spectrum.API.Storage;

namespace SuperShot
{
    class CurrentPlugin
    {
        public static void Initialize()
        {
            Log = new Logger("SuperShot.log");
            Log.WriteToConsole = true;
            Config = new Settings("Config");
            InitConfig();
            Files = new FileSystem();
        }

        public static void InitConfig()
        {
            var DefaultConfig = new Dictionary<string, object>
            {
                {"KeyBinding", "LeftControl+Alpha1"},
                {"ScaleFactor", 2}
            };

            foreach (var entry in DefaultConfig)
            {
                if (!Config.ContainsKey(entry.Key))
                {
                    Config.Add(entry.Key, entry.Value);
                }
            }

            Config.Save();
        }

        public static Logger Log;
        public static Settings Config;
        public static FileSystem Files;
    }
}
