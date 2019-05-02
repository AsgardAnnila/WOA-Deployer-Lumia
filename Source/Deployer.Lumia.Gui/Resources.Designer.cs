﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Deployer.Lumia.Gui {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Deployer.Lumia.Gui.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to WOA Deployer for Lumia v{0}.
        /// </summary>
        public static string AppTitle {
            get {
                return ResourceManager.GetString("AppTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to install the GPU. Please, ensure that WOA is installed..
        /// </summary>
        public static string CannotInstallGpu {
            get {
                return ResourceManager.GetString("CannotInstallGpu", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Finished.
        /// </summary>
        public static string DeploymentFinished {
            get {
                return ResourceManager.GetString("DeploymentFinished", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Done.
        /// </summary>
        public static string Done {
            get {
                return ResourceManager.GetString("Done", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The downloaded files have been deleted successfully.
        /// </summary>
        public static string DownloadedFolderDeleted {
            get {
                return ResourceManager.GetString("DownloadedFolderDeleted", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The &apos;Downloaded&apos; folder hasn&apos;t been found..
        /// </summary>
        public static string DownloadedFolderNotFound {
            get {
                return ResourceManager.GetString("DownloadedFolderNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Nothing to delete.
        /// </summary>
        public static string DownloadedFolderNotFoundTitle {
            get {
                return ResourceManager.GetString("DownloadedFolderNotFoundTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Dual Boot Disabled!.
        /// </summary>
        public static string DualBootDisabled {
            get {
                return ResourceManager.GetString("DualBootDisabled", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Dual Boot Enabled!.
        /// </summary>
        public static string DualBootEnabled {
            get {
                return ResourceManager.GetString("DualBootEnabled", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Image captured.
        /// </summary>
        public static string ImageCaptured {
            get {
                return ResourceManager.GetString("ImageCaptured", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Image restored.
        /// </summary>
        public static string ImageRestored {
            get {
                return ResourceManager.GetString("ImageRestored", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Disclaimer Notice and Terms of Use.
        /// </summary>
        public static string TermsOfUseTitle {
            get {
                return ResourceManager.GetString("TermsOfUseTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to - This tool comes with no warranty. 
        ///- The authors can&apos;t be hold responsible for any damage it may cause to your device.    
        ///- This tool intended for usage with Lumia 950 and 950 XL **ONLY**.
        ///    
        ///By clicking &quot;OK&quot; you accept the aforementioned risks..
        /// </summary>
        public static string WarningNotice {
            get {
                return ResourceManager.GetString("WarningNotice", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to # Done!
        ///Now, follow these directions:
        ///
        ///1. **Eject the phone safely** to avoid data corruption issues
        ///2. Reboot the phone by pressing the **[Power]** and holding it until it vibrates
        ///3. The phone will reboot
        ///4. Inside the Boot Menu, choose **&quot;Windows 10&quot;** by using the **[Camera]** button to start the Windows 10 ARM Setup
        ///  - If you don&apos;t see any boot menu and the screen is completely black, press the **[Camera]** button to continue. It&apos;s a known issue. 
        ///5. **Wait patiently** until the Windows Setup  [rest of string was truncated]&quot;;.
        /// </summary>
        public static string WindowsDeployedSuccessfully {
            get {
                return ResourceManager.GetString("WindowsDeployedSuccessfully", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Deployment successful.
        /// </summary>
        public static string WindowsDeployedSuccessfullyTitle {
            get {
                return ResourceManager.GetString("WindowsDeployedSuccessfullyTitle", resourceCulture);
            }
        }
    }
}
