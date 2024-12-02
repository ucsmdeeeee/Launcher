using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using WpfApp3.ViewModels;

namespace WpfApp3.Views.Pages;

public partial class ShopPage : Page
{
    public ShopPage()
    {
        InitializeComponent();
    }
    
    private void DiscordOpenButton_Click(object sender, RoutedEventArgs e)
    {
        ((ShopViewModel)this.DataContext).OpenDiscord();
    }
    
    private void LauncherHideButton_Click(object sender, RoutedEventArgs e)
    {
        ((ShopViewModel)this.DataContext).HideLauncher();
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
        ((ShopViewModel)this.DataContext).CloseLauncher();
    }

    public async Task OnSliderValueChanged(int newValue)
    {
        // Log the new value
        Console.WriteLine($"Slider value changed to: {newValue}");

        // You can also add any additional logic here if needed
    }

    public async void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        if (sender is Slider slider)
        {
            await OnSliderValueChanged((int)slider.Value);
        }
    }

    
}