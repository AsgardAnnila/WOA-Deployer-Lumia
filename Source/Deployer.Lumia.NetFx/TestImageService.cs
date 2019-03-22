﻿using System.Threading.Tasks;
using Deployer.FileSystem;
using Deployer.Services;

namespace Deployer.Lumia.NetFx
{
    public class TestImageService : IWindowsImageService
    {
        public Task ApplyImage(Volume windowsVolume, string imagePath, int imageIndex = 1, bool useCompact = false,
            IDownloadProgress progressObserver = null)
        {
            return Task.Delay(5000);
        }

        public Task InjectDrivers(string path, Volume windowsPartition)
        {
            return Task.Delay(5000);
        }

        public Task RemoveDriver(string path, Volume volume)
        {
            return Task.Delay(5000);
        }

        public Task CaptureImage(Volume windowsVolume, string destination, IDownloadProgress progressObserver = null)
        {
            return Task.Delay(5000);
        }
    }
}