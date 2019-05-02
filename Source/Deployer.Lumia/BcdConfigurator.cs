using Deployer.FileSystem;
using Deployer.Services;

namespace Deployer.Lumia
{
    public class BcdConfigurator
    {
        private readonly IBcdInvoker invoker;
        private readonly Volume mainOsVolume;


        public BcdConfigurator(IBcdInvoker invoker, Volume mainOsVolume)
        {
            this.invoker = invoker;
            this.mainOsVolume = mainOsVolume;
        }

        public void SetupBcd()
        {
            SetupBootShim();
            SetupBootMgr();
            SetDisplayOptions();
        }

        private void SetDisplayOptions()
        {
            invoker.Invoke($@"/displayorder {{{BcdGuids.BootShim}}}");
            invoker.Invoke($@"/default {{{BcdGuids.BootShim}}}");
            invoker.Invoke($@"/timeout 30");
        }

        private void SetupBootShim()
        {
            EnsureBootShim();

            invoker.Invoke($@"/set {{{BcdGuids.BootShim}}} path \EFI\boot\BootShim.efi");
            invoker.Invoke($@"/set {{{BcdGuids.BootShim}}} device partition={mainOsVolume.Root}\EFIESP");
            invoker.Invoke($@"/set {{{BcdGuids.BootShim}}} testsigning on");
            invoker.Invoke($@"/set {{{BcdGuids.BootShim}}} nointegritychecks on");
        }
        
        private void SetupBootMgr()
        {
            invoker.Invoke($@"/set {{bootmgr}} displaybootmenu on");
            invoker.Invoke($@"/deletevalue {{bootmgr}} customactions");
            invoker.Invoke($@"/deletevalue {{bootmgr}} custom:54000001");
            invoker.Invoke($@"/deletevalue {{bootmgr}} custom:54000002");
            invoker.Invoke($@"/deletevalue {{bootmgr}} processcustomactionsfirst");
        }
        
        private void EnsureBootShim()
        {
            if (invoker.Invoke("enum {{{BootShimEntryGuid}}}").Contains(BcdGuids.BootShim.ToString()))
            {
                invoker.Invoke($@"/create {{{BcdGuids.BootShim}}} /d ""Windows 10"" /application BOOTAPP");            
            }            
        }
    }
}
