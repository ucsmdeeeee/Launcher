using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;
using MvvmCross.ViewModels;
using WpfApp3.Views.Pages;

namespace WpfApp3.ViewModels;

public class SettingsViewModel : MvxViewModel, INotifyPropertyChanged
{
    
    private int _selectedRAM;
    public int SelectedRAM
    {
        get => _selectedRAM;
        set
        {
            _selectedRAM = value;
            OnPropertyChanged(nameof(SelectedRAM));
        }
    }

    public ICommand SaveSettingsCommand { get; }

    public SettingsViewModel()
    {
        SaveSettingsCommand = new RelayCommand(SaveSettings);
    }

    private void SaveSettings()
    {
        // Логика для сохранения настроек в DashboardViewModel
        var dashboardViewModel = new DashboardViewModel();
        dashboardViewModel.RAM = SelectedRAM;
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => _canExecute == null || _canExecute();
        public void Execute(object parameter) => _execute();

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    
}