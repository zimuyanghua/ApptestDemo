using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.VisualTree;
using System.Linq;

namespace AvaloniaApptest.Views;

public partial class RadorManageView : UserControl
{
    public RadorManageView()
    {
        InitializeComponent();
    }

    private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var listBox = sender as ListBox;

        if (listBox.SelectedItem != null )
        {
            
            foreach (var box in this.GetVisualDescendants().OfType<ListBox>())
            {
                if (box != listBox)
                {
                    box.SelectedItem = null;
                }
            }
        }

    }
}