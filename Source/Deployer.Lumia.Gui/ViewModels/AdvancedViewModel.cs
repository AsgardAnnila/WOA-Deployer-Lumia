using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using ByteSizeLib;
using Deployer.Gui;
using Deployer.Gui.ViewModels;
using Deployer.Tasks;
using Grace.DependencyInjection;
using ReactiveUI;

namespace Deployer.Lumia.Gui.ViewModels
{
    public class AdvancedViewModel : ReactiveObject, IBusy
    {
        public StatusViewModel StatusViewModel { get; }
        private readonly ISettingsService settingsService;
        private readonly UIServices uiServices;
        private readonly IDeviceProvider deviceProvider;
        private readonly IOperationProgress progress;
        private readonly IPhone phone;
        private readonly IDeploymentContext context;

        private DiskLayoutPreparerViewModel selectedPreparer;

        public AdvancedViewModel(ISettingsService settingsService, IFileSystemOperations fileSystemOperations,
            UIServices uiServices,
            IDeviceProvider deviceProvider, IOperationProgress progress, StatusViewModel statusViewModel, IPhone phone,
            IDeploymentContext context,
                IEnumerable<Meta<IDiskLayoutPreparer>> diskPreparers)
        {
            StatusViewModel = statusViewModel;
            this.settingsService = settingsService;
            this.uiServices = uiServices;
            this.deviceProvider = deviceProvider;
            this.progress = progress;
            this.phone = phone;
            this.context = context;

            DiskPreparers = diskPreparers
                .Where(x => !x.Metadata.Keys.Contains("IsNull"))
                .Select(x => new DiskLayoutPreparerViewModel((string) x.Metadata["Name"], x.Value))
                .ToList();

            DeleteDownloadedWrapper = new CommandWrapper<Unit, Unit>(this, ReactiveCommand.CreateFromTask(() => DeleteDownloaded(fileSystemOperations)), uiServices.Dialog);
            ForceDualBootWrapper = new CommandWrapper<Unit, Unit>(this, ReactiveCommand.CreateFromTask(ForceDualBoot), uiServices.Dialog);
            ForceSingleBootWrapper = new CommandWrapper<Unit, Unit>(this, ReactiveCommand.CreateFromTask(ForceDisableDualBoot), uiServices.Dialog);

            BackupCommandWrapper = new CommandWrapper<Unit, Unit>(this, ReactiveCommand.CreateFromTask(Backup), uiServices.Dialog);
            RestoreCommandWrapper = new CommandWrapper<Unit, Unit>(this, ReactiveCommand.CreateFromTask(Restore), uiServices.Dialog);

            IsBusyObservable = Observable.Merge(new []
            {
                DeleteDownloadedWrapper.Command.IsExecuting,
                BackupCommandWrapper.Command.IsExecuting,
                RestoreCommandWrapper.Command.IsExecuting,
                ForceDualBootWrapper.Command.IsExecuting,
                ForceSingleBootWrapper.Command.IsExecuting,
            });

            SelectedPreparer = DiskPreparers.First(x => x.Preparer == settingsService.DiskPreparer);
        }

        public DiskLayoutPreparerViewModel SelectedPreparer
        {
            get => selectedPreparer;
            set => this.RaiseAndSetIfChanged(ref selectedPreparer, value);
        }

        private async Task ForceDualBoot()
        {
            await phone.ToogleDualBoot(true, true);

            await uiServices.Dialog.ShowAlert(this, Resources.Done, Resources.DualBootEnabled);
        }

        private async Task ForceDisableDualBoot()
        {
            await phone.ToogleDualBoot(false, true);

            await uiServices.Dialog.ShowAlert(this, Resources.Done, Resources.DualBootDisabled);
        }

        public CommandWrapper<Unit, Unit> RestoreCommandWrapper { get; set; }

        public CommandWrapper<Unit, Unit> BackupCommandWrapper { get; set; }

        private async Task Backup()
        {
            uiServices.SaveFilePicker.DefaultExt = "*.wim";
            uiServices.SaveFilePicker.Filter = "Windows Images (.wim)|*.wim";
            var imagePath = uiServices.SaveFilePicker.PickFile();
            if (imagePath == null)
            {
                return;
            }

            context.DeploymentOptions = new SlimWindowsDeploymentOptions()
            {
                ImageIndex = 1,
                ImagePath = imagePath,
                UseCompact = settingsService.UseCompactDeployment,
            };

            //await deployer.Capture(imagePath, progress);

            await uiServices.Dialog.ShowAlert(this, Resources.Done, Resources.ImageCaptured);
        }

        private async Task Restore()
        {
            var filters = new List<(string, IEnumerable<string>)>
            {
                ("install.wim", new[]
                {
                    "install.wim",
                }),
                ("Windows Images", new[]
                {
                    "*.wim",
                    "*.esd"
                }),
                ("All files", new[]
                {
                    "*.*",
                }),
            };

            var fileName = uiServices.OpenFilePicker.Pick(filters, () => settingsService.WimFolder, x =>
            {
                settingsService.WimFolder = x;
                settingsService.Save();
            });

            if (fileName == null)
            {
                return;
            }

            context.DeploymentOptions = new SlimWindowsDeploymentOptions
            {
                ImageIndex = 1,
                ImagePath = fileName,
                UseCompact = settingsService.UseCompactDeployment,
            };

            //await preparer.Prepare(await deviceProvider.Device.GetDeviceDisk());
            //await deployer.Deploy(progress);

            await uiServices.Dialog.ShowAlert(this, Resources.Done, Resources.ImageRestored);
        }
        
        public CommandWrapper<Unit, Unit> DeleteDownloadedWrapper { get; }

        public bool UseCompactDeployment
        {
            get => settingsService.UseCompactDeployment;
            set
            {
                settingsService.UseCompactDeployment = value;
                settingsService.Save();
                this.RaisePropertyChanged(nameof(UseCompactDeployment));
            }
        }

        public bool CleanDownloadedBeforeDeployment
        {
            get => settingsService.CleanDownloadedBeforeDeployment;
            set
            {
                settingsService.CleanDownloadedBeforeDeployment = value;
                settingsService.Save();
                this.RaisePropertyChanged(nameof(CleanDownloadedBeforeDeployment));
            }
        }

        public IObservable<bool> IsBusyObservable { get; }

        private async Task DeleteDownloaded(IFileSystemOperations fileSystemOperations)
        {
            if (fileSystemOperations.DirectoryExists(AppPaths.DownloadedFolderName))
            {
                await fileSystemOperations.DeleteDirectory(AppPaths.DownloadedFolderName);
                await uiServices.Dialog.ShowAlert(this, Resources.Done, Resources.DownloadedFolderDeleted);
            }
            else
            {
                await uiServices.Dialog.ShowAlert(this, Resources.DownloadedFolderNotFoundTitle,
                    Resources.DownloadedFolderNotFound);
            }
        }

        public CommandWrapper<Unit, Unit> ForceDualBootWrapper { get; }

        public CommandWrapper<Unit, Unit> ForceSingleBootWrapper { get; }

        public IEnumerable<DiskLayoutPreparerViewModel> DiskPreparers { get; set; }
    }
}