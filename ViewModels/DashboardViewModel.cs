using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using MvvmCross.ViewModels;
using WpfApp3.Models;

using CmlLib.Core;
using CmlLib.Core.Auth;
using CmlLib.Core.Version;
using CmlLib.Core.VersionLoader;
using CmlLib.Utils;
using WpfApp3.Views.Pages;

namespace WpfApp3.ViewModels;

public class DashboardViewModel:MvxViewModel,INotifyPropertyChanged
{
    private readonly CMLauncher _launcher;
    private readonly MinecraftPath _minecraftPath = new MinecraftPath();
    
    #region FriendsList
    private ObservableCollection<IFriend> _friendsList = new ObservableCollection<IFriend>();

    public ObservableCollection<IFriend> FriendsList
    {
        get => _friendsList;
        set => SetProperty(ref _friendsList, value);
    }
    #endregion
    
    #region Account
    private ObservableCollection<IAccount> _account = new ObservableCollection<IAccount>();

    public ObservableCollection<IAccount> Account
    {
        get => _account;
        set => SetProperty(ref _account, value);
    }
    #endregion
    
    private int _ram;
    public int RAM
    {
        get => _ram;
        set
        {
            _ram = value;
            OnPropertyChanged(nameof(RAM));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    
    public async Task LaunchMinecraft()
    {
        try
        {
            System.Net.ServicePointManager.DefaultConnectionLimit = 256;
            
            var versionToLaunch = "1.19";
            
            var launchOption = new MLaunchOption
            {
                MaximumRamMb = RAM,
                Session = MSession.GetOfflineSession("ucsmdeeeee"),
            };

            var processInfo = await _launcher.CreateProcessAsync(versionToLaunch, launchOption);
            
            var process = processInfo.Start();
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Error launching Minecraft: " + ex.Message);
        }
    }

    public async Task OpenDiscord()
    {
        try
        {
            var discordUrl = "https://discord.gg/MDcV8hSwrP";
            Process.Start(new ProcessStartInfo
            {
                FileName = discordUrl,
                UseShellExecute = true
            });
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Error opening Discord: " + ex.Message);
        }
    }

    public async Task HideLauncher()
    {
        Application.Current.Dispatcher.Invoke(() =>
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        });
    }

    public async Task CloseLauncher()
    {
        Application.Current.Dispatcher.Invoke(() =>
        {
            Application.Current.MainWindow.Close();
        });
    }
    
    private readonly MainViewModel _mainViewModel;

    public DashboardViewModel(MainViewModel mainViewModel)
    {
        _mainViewModel = mainViewModel;
    }

    public void ShowShop()
    {
        // Меняем ContentPage на новую страницу
        _mainViewModel.ContentPage = new ShopPage();
    }
    
    public async void ShowSetting()
    {
        _mainViewModel.ContentPage = new SettingsPage();
    }
    
    public DashboardViewModel()
    {
        _launcher = new CMLauncher(_minecraftPath);
        
        BitmapImage NewsBackground = new BitmapImage();
        NewsBackground.BeginInit();
        NewsBackground.UriSource =
            new Uri(@"C:\Users\lozik\source\repos\WpfApp3\Views\Resources\Images\NewsBackGround.jpg");
        NewsBackground.CacheOption = BitmapCacheOption.OnLoad;
        NewsBackground.EndInit();
        
        BitmapImage Ivan = new BitmapImage();
        Ivan.BeginInit();
        Ivan.UriSource =
            new Uri(@"C:\Users\lozik\source\repos\WpfApp3\Views\Resources\Images\Ivan.jpg");
        Ivan.CacheOption = BitmapCacheOption.OnLoad;
        Ivan.EndInit();
        
        BitmapImage Ignat = new BitmapImage();
        Ignat.BeginInit();
        Ignat.UriSource =
            new Uri(@"C:\Users\lozik\source\repos\WpfApp3\Views\Resources\Images\Ignat.jpg");
        Ignat.CacheOption = BitmapCacheOption.OnLoad;
        Ignat.EndInit();
        
        BitmapImage Danya = new BitmapImage();
        Danya.BeginInit();
        Danya.UriSource =
            new Uri(@"C:\Users\lozik\source\repos\WpfApp3\Views\Resources\Images\Danya.jpg");
        Danya.CacheOption = BitmapCacheOption.OnLoad;
        Danya.EndInit();
        
        Account.Add(new Account
        {
            Id = 1,
            NickName = "Иван Клюшин",
            Avatar = Ivan
        });
        
        FriendsList.Add(new Friend
        {
            Id = 1,
            TextContent = "Даниил Снопов",
            Image = Danya
        });
        
        FriendsList.Add(new Friend
        {
            Id = 2,
            TextContent = "Игнатий Зайцев",
            Image = Ignat
        });
        
        FriendsList.Add(new Friend
        {
            Id = 3,
            TextContent = "Игнатий Зайцев",
            Image = Ignat
        });
        
    }
}