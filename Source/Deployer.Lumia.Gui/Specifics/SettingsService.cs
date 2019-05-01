using System.Collections.Generic;
using Deployer.Gui;
using Deployer.Lumia.Gui.Properties;
using Deployer.Tasks;
using Grace.DependencyInjection;

namespace Deployer.Lumia.Gui.Specifics
{
    public class SettingsService : ISettingsService
    {
        private readonly IDeploymentContext context;
        private readonly IEnumerable<Meta<IHighLevelWindowsDeployer>> windowsDeployers;

        public SettingsService(IDeploymentContext context, IEnumerable<Meta<IHighLevelWindowsDeployer>> windowsDeployers)
        {
            this.context = context;
            this.windowsDeployers = windowsDeployers;
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

        public bool UseCompactDeployment
        {
            get => Settings.Default.UseCompactDeployment;
            set => Settings.Default.UseCompactDeployment = value;
        }

        public bool CleanDownloadedBeforeDeployment
        {
            get => Settings.Default.CleanDownloadedBeforeDeployment;
            set => Settings.Default.CleanDownloadedBeforeDeployment = value;
        }

        public IHighLevelWindowsDeployer WindowsDeployer { get; set; }

        public void Save()
        {
            Settings.Default.Save();
        }
    }
}