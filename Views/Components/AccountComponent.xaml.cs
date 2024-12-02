using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using WpfApp3.Models;

namespace WpfApp3.Views.Components;

public partial class AccountComponent : UserControl
{
    
    public ObservableCollection<IAccount> Account
    {
        get { return (ObservableCollection<IAccount>)GetValue(AccountProperty); }
        set{SetValue(AccountProperty, value);}
    }
    public static readonly DependencyProperty AccountProperty = 
        DependencyProperty.Register("Account", typeof(ObservableCollection<IAccount>), typeof(AccountComponent), new PropertyMetadata(null));

    
    public AccountComponent()
    {
        InitializeComponent();
    }
}