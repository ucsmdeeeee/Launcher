using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using WpfApp3.Models;

namespace WpfApp3.Views.Components;

public partial class FriendsListComponent : UserControl
{

    public ObservableCollection<IFriend> FriendsList
    {
        get { return (ObservableCollection<IFriend>)GetValue(FriendsListProperty); }
        set{SetValue(FriendsListProperty, value);}
    }
    public static readonly DependencyProperty FriendsListProperty = 
        DependencyProperty.Register("FriendsList", typeof(ObservableCollection<IFriend>), typeof(FriendsListComponent), new PropertyMetadata(null));
    
    public FriendsListComponent()
    {
        InitializeComponent();
    }
}