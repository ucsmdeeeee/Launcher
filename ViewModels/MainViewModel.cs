using System.Windows;
using System.Windows.Controls;
using MvvmCross.ViewModels;
using WpfApp3.Views.Pages;


namespace WpfApp3.ViewModels;

public class MainViewModel : MvxViewModel
{
    private Page _dashboardPage = new DashboardPage();
    private Page _shopPage = new ShopPage();
    private Page _settingsPage = new SettingsPage();

    private Page _contentPage;

    public Page ContentPage
    {
        get => _contentPage;
        set => SetProperty(ref _contentPage, value);
    }

    public MainViewModel()
    {
        ContentPage = _dashboardPage;
    }

    public void ShowLauncher()
    {
        ContentPage = _dashboardPage;
    }
        
    public void ShowShop()
    {
        ContentPage = _shopPage;
    }
    
    
    public void ShowSettings()
    {
        ContentPage = _settingsPage;
    }
    
}