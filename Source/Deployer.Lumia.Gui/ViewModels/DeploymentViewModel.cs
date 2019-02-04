using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Deployer.Gui.Core;
using ReactiveUI;

namespace Deployer.Lumia.Gui.ViewModels
{
    public class DeploymentViewModel : ReactiveObject, IBusy
    {
        private readonly IWindowsOptionsProvider optionsProvider;
        private readonly IWoaDeployer deploymentTasks;
        private readonly UIServices uiServices;
        private readonly AdvancedViewModel advancedViewModel;
        private readonly WimPickViewModel wimPickViewModel;
        private readonly ObservableAsPropertyHelper<bool> isBusyHelper;

        public DeploymentViewModel(
            IWindowsOptionsProvider optionsProvider,
            IWoaDeployer deploymentTasks, UIServices uiServices, AdvancedViewModel advancedViewModel,
            WimPickViewModel wimPickViewModel)
        {
            this.optionsProvider = optionsProvider;
            this.deploymentTasks = deploymentTasks;
            this.uiServices = uiServices;
            this.advancedViewModel = advancedViewModel;
            this.wimPickViewModel = wimPickViewModel;

            var isSelectedWim = wimPickViewModel.WhenAnyObservable(x => x.WimMetadata.SelectedImageObs)
                .Select(metadata => metadata != null);

            FullInstallWrapper = new CommandWrapper<Unit, Unit>(this,
                ReactiveCommand.CreateFromTask(Deploy, isSelectedWim), uiServices.DialogService);
            IsBusyObservable = FullInstallWrapper.Command.IsExecuting;
            isBusyHelper = IsBusyObservable.ToProperty(this, model => model.IsBusy);
        }

        public bool IsBusy => isBusyHelper.Value;

        private async Task Deploy()
        {
            var windowsDeploymentOptions = new WindowsDeploymentOptions
            {
                ImagePath = wimPickViewModel.WimMetadata.Path,
                ImageIndex = wimPickViewModel.WimMetadata.SelectedDiskImage.Index,
                SizeReservedForWindows = advancedViewModel.SizeReservedForWindows,
            };

            optionsProvider.Options = windowsDeploymentOptions;

            await deploymentTasks.Deploy();

            await uiServices.DialogService.ShowAlert(this, Resources.Finished,
                Resources.WindowsDeployedSuccessfully);
        }

        public CommandWrapper<Unit, Unit> FullInstallWrapper { get; set; }
        public IObservable<bool> IsBusyObservable { get; }
    }
}