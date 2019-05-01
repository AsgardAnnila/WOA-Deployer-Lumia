using System.Windows;
using System.Windows.Controls;
using Deployer.Lumia.Gui.ViewModels;

namespace Deployer.Lumia.Gui
{
    public class DiskPreparerSelector : DataTemplateSelector
    {
        public DataTemplate ConservativeTemplate { get; set; }
        public DataTemplate DestructiveTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is DiskLayoutPreparerViewModel vm)
            {
                switch (vm.Preparer)
                {
                    case DestructiveLumiaDiskLayoutPreparer _:
                        return DestructiveTemplate;
                    case ConservativeLumiaDiskLayoutPreparer _:
                        return ConservativeTemplate;
                }
            }

            return base.SelectTemplate(item, container);
        }
    }
}