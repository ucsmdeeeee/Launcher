using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using WpfApp3.Models;
using WpfApp3.ViewModels;
using WpfApp3.Views.Converters;

namespace WpfApp3.Views.Components;

public partial class ThingComponent : UserControl
{
    public ObservableCollection<IThing> Thing
    {
        get { return (ObservableCollection<IThing>)GetValue(ThingProperty); }
        set { SetValue(ThingProperty, value); }
    }

    public static readonly DependencyProperty ThingProperty =
        DependencyProperty.Register("Thing", typeof(ObservableCollection<IThing>), typeof(ThingComponent),
            new PropertyMetadata(null));
    
    public ThingComponent()
    {
        InitializeComponent();
    }
    
}
