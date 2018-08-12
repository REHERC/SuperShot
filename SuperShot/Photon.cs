using System;
using System.IO;
using Spectrum.API.Interfaces.Plugins;
using Spectrum.API.Interfaces.Systems;
using UnityEngine;

namespace SuperShot
{
    public class Photon : IPlugin
    {
        public void Initialize(IManager manager, string ipcIdentifier)
        {
            Console.WriteLine($"Initializing ... ({ipcIdentifier})");
            CurrentPlugin.Initialize();
            CurrentPlugin.Log.Info("Initialization done!");
            CurrentPlugin.Log.Info("Adding key bindings ...");

            Parameters();

            manager.Hotkeys.Bind(CurrentPlugin.Config.GetItem<string>("KeyBinding"), () =>
            {
                TakeScreenshot();
            });
            CurrentPlugin.Log.Info("Added key bindings!");
        }

        private void Parameters()
        {
            SuperSize = Math.Max(CurrentPlugin.Config.GetItem<int>("ScaleFactor"), 1);
        }



        private int SuperSize = 1;
        
        private void TakeScreenshot()
        {
            string path = CurrentPlugin.Files.RootDirectory + @"\Data";
            string name = $"Screenshot {DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss")}";

            if (!Directory.Exists(path)) {
                Directory.CreateDirectory(path);
            }
            
            UnityEngine.Application.CaptureScreenshot($@"{path}\{name}.png", SuperSize);
        }
    }
}
