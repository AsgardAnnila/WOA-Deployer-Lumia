using System.Windows;
using System.Windows.Controls;

namespace Deployer.Lumia.Gui
{
    public class DeployerSelector : DataTemplateSelector
    {
        public DataTemplate DefaultTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            return DefaultTemplate;

            return base.SelectTemplate(item, container);
        }
    }
}