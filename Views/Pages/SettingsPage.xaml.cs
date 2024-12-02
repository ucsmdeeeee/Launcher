using System.Windows.Controls;
using System.Windows;
using System.Windows.Controls;
using WpfApp3.ViewModels;

namespace WpfApp3.Views.Pages
{
    public partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            InitializeComponent();
        }
        public async Task OnSliderValueChanged(int newValue)
        {
            // Log the new value
            Console.WriteLine($"Slider value changed to: {newValue}");

            // You can also add any additional logic here if needed
        }
        private void LauncherShowButton_Click(object sender, RoutedEventArgs e)
        {
            ((MainViewModel)Application.Current.MainWindow.DataContext).ShowLauncher();
        }
        public async void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (sender is Slider slider)
            {
                await OnSliderValueChanged((int)slider.Value);
            }
        }
    }
}