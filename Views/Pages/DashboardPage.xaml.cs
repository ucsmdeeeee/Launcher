using System.Windows;
using System.Windows.Controls;
using WpfApp3.ViewModels;

namespace WpfApp3.Views.Pages;

public partial class DashboardPage : Page
{
    public DashboardPage()
    {
        InitializeComponent();
        
    }

    private void StartGameButton_Click(object sender, RoutedEventArgs e)
    {
        ((DashboardViewModel)this.DataContext).LaunchMinecraft();
    }
    
    private void DiscordOpenButton_Click(object sender, RoutedEventArgs e)
    {
        ((DashboardViewModel)this.DataContext).OpenDiscord();
    }
    
    private void LauncherHideButton_Click(object sender, RoutedEventArgs e)
    {
        ((DashboardViewModel)this.DataContext).HideLauncher();
    }
    private void ShopShowButton_Click(object sender, RoutedEventArgs e)
    {
        ((MainViewModel)Application.Current.MainWindow.DataContext).ShowShop();
    }
        
    private void LauncherShowButton_Click(object sender, RoutedEventArgs e)
    {
        ((MainViewModel)Application.Current.MainWindow.DataContext).ShowLauncher();
    }

    
    private void LauncherCloseButton_Click(object sender, RoutedEventArgs e)
    {
        ((DashboardViewModel)this.DataContext).CloseLauncher();
    }
    private void SettingsOpenButton_Click(object sender, RoutedEventArgs e)
    {
        ((MainViewModel)Application.Current.MainWindow.DataContext).ShowSettings();
    }
    
}