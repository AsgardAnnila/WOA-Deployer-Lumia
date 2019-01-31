﻿using Deployer.Lumia.Gui.Properties;
using Installer.Wpf.Core;

namespace Deployer.Lumia.Gui
{
    public class SettingsService : ISettingsService
    {
        public string DriverPackFolder
        {
            get => Settings.Default.DriverPackFolder;
            set => Settings.Default.DriverPackFolder = value;
        }

        public string WimFolder
        {
            get => Settings.Default.WimFolder;
            set => Settings.Default.WimFolder = value;
        }

        public double SizeReservedForWindows
        {
            get => Settings.Default.SizeReservedForWindows;
            set => Settings.Default.SizeReservedForWindows = value;
        }

        public void Save()
        {
            Settings.Default.Save();
        }
    }
}