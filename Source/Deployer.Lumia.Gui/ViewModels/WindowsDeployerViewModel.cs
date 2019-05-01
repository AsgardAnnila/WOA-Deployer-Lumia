using Deployer.Tasks;

namespace Deployer.Lumia.Gui.ViewModels
{
    public class WindowsDeployerViewModel
    {
        public string Name { get; }
        public IHighLevelWindowsDeployer Deployer { get; }

        public WindowsDeployerViewModel(string name, IHighLevelWindowsDeployer deployer)
        {
            Name = name;
            Deployer = deployer;
        }
    }
}