using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using MvvmCross.ViewModels;
using WpfApp3.Models;

namespace WpfApp3.ViewModels;

public class ShopViewModel : MvxViewModel, INotifyPropertyChanged
    {
        #region Thing
        private ObservableCollection<IThing> _thing = new ObservableCollection<IThing>();

        public ObservableCollection<IThing> Thing
        {
            get => _thing;
            set => SetProperty(ref _thing, value);
        }
        #endregion

        #region FilteredThings
        private ObservableCollection<IThing> _filteredThings = new ObservableCollection<IThing>();

        public ObservableCollection<IThing> FilteredThings
        {
            get => _filteredThings;
            set => SetProperty(ref _filteredThings, value);
        }
        #endregion

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
            Application.Current.Dispatcher.Invoke(() => { Application.Current.MainWindow.Close(); });
        }

        public ICommand FilterAllCommand { get; set; }
        public ICommand FilterBlocksCommand { get; set; }
        public ICommand FilterToolsCommand { get; set; }
        public ICommand FilterPetsCommand { get; set; }
        public ICommand FilterArmorCommand { get; set; }
        public ICommand SearchCommand { get; set; }

        private int _selectedPrice;

        public int SelectedPrice
        {
            get { return _selectedPrice; }
            set
            {
                if (_selectedPrice != value)
                {
                    _selectedPrice = value;
                    OnPropertyChanged(nameof(SelectedPrice));
                    FilterThings();
                }
            }
        }

        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    OnPropertyChanged(nameof(SearchText));
                }
            }
        }
        
        public ShopViewModel()
        {
            FilterAllCommand = new RelayCommand(FilterAll);
            FilterBlocksCommand = new RelayCommand(FilterBlocks);
            FilterToolsCommand = new RelayCommand(FilterTools);
            FilterPetsCommand = new RelayCommand(FilterPets);
            FilterArmorCommand = new RelayCommand(FilterArmor);
            SearchCommand = new RelayCommand(Search);

            BitmapImage Bron = new BitmapImage();
            Bron.BeginInit();
            Bron.UriSource = new Uri(@"C:\\Users\\lozik\\source\\repos\\WpfApp3\\Views\\Resources\\Images\\Bron.jpg");
            Bron.CacheOption = BitmapCacheOption.OnLoad;
            Bron.EndInit();
            
            BitmapImage Cat = new BitmapImage();
            Cat.BeginInit();
            Cat.UriSource = new Uri(@"C:\\Users\\lozik\\source\\repos\\WpfApp3\\Views\\Resources\\Images\\Cat.jpg");
            Cat.CacheOption = BitmapCacheOption.OnLoad;
            Cat.EndInit();
            
            BitmapImage Dern = new BitmapImage();
            Dern.BeginInit();
            Dern.UriSource = new Uri(@"C:\\Users\\lozik\\source\\repos\\WpfApp3\\Views\\Resources\\Images\\Dern.jpg");
            Dern.CacheOption = BitmapCacheOption.OnLoad;
            Dern.EndInit();
            
            BitmapImage Diamond = new BitmapImage();
            Diamond.BeginInit();
            Diamond.UriSource = new Uri(@"C:\\Users\\lozik\\source\\repos\\WpfApp3\\Views\\Resources\\Images\\Diamond.jpg");
            Diamond.CacheOption = BitmapCacheOption.OnLoad;
            Diamond.EndInit();
            
            BitmapImage Dog = new BitmapImage();
            Dog.BeginInit();
            Dog.UriSource = new Uri(@"C:\\Users\\lozik\\source\\repos\\WpfApp3\\Views\\Resources\\Images\\Dog.jpg");
            Dog.CacheOption = BitmapCacheOption.OnLoad;
            Dog.EndInit();
            
            BitmapImage Dragon = new BitmapImage();
            Dragon.BeginInit();
            Dragon.UriSource = new Uri(@"C:\\Users\\lozik\\source\\repos\\WpfApp3\\Views\\Resources\\Images\\Dragon.jpg");
            Dragon.CacheOption = BitmapCacheOption.OnLoad;
            Dragon.EndInit();

            BitmapImage Kirk = new BitmapImage();
            Kirk.BeginInit();
            Kirk.UriSource = new Uri(@"C:\\Users\\lozik\\source\\repos\\WpfApp3\\Views\\Resources\\Images\\Kirk.jpg");
            Kirk.CacheOption = BitmapCacheOption.OnLoad;
            Kirk.EndInit();
            
            BitmapImage Mech = new BitmapImage();
            Mech.BeginInit();
            Mech.UriSource = new Uri(@"C:\\Users\\lozik\\source\\repos\\WpfApp3\\Views\\Resources\\Images\\Mech.jpg");
            Mech.CacheOption = BitmapCacheOption.OnLoad;
            Mech.EndInit();
            
            Thing.Add(new Thing { Id = 1, Name = "Дерн", Photo = Dern, Price = 10, Count = 1, Category = "Block" });
            Thing.Add(new Thing { Id = 2, Name = "Щенок белый", Photo = Dog, Price = 15, Count = 7, Category = "Pet" });
            Thing.Add(new Thing { Id = 3, Name = "Алмазный меч", Photo = Mech, Price = 35, Count = 24, Category = "Tool" });
            Thing.Add(new Thing { Id = 4, Name = "Алмазный нагрудник", Photo = Bron, Price = 60, Count = 13, Category = "Armor" });
            Thing.Add(new Thing { Id = 5, Name = "Железная кирка", Photo = Kirk, Price = 20, Count = 330, Category = "Tool" });
            Thing.Add(new Thing { Id = 6, Name = "Котенок черный", Photo = Cat, Price = 10, Count = 11, Category = "Pet" });
            Thing.Add(new Thing { Id = 7, Name = "Дракон красный", Photo = Dragon, Price = 10, Count = 333, Category = "Pet" });
            Thing.Add(new Thing { Id = 8, Name = "Алмаз", Photo = Diamond, Price = 40, Count = 20, Category = "Block" });

            // Initialize the filtered list with all items
            FilterThings();
        }

        

        
        private void FilterThings(string category = null)
        {
            var filtered = Thing.Where(t => t.Price <= SelectedPrice);
            if (!string.IsNullOrEmpty(category))
            {
                filtered = filtered.Where(t => t.Category == category);
            }

            // Создаем временный список
            var tempFilteredThings = new ObservableCollection<IThing>(filtered);

            // Очищаем текущую коллекцию
            FilteredThings.Clear();

            // Копируем элементы из временного списка в FilteredThings
            foreach (var thing in tempFilteredThings)
            {
                FilteredThings.Add(thing);
            }
        }
        

        private void Search()
        {
            var filtered = Thing.Where(t => t.Name.ToLower() == SearchText.ToLower());
            

            // Создаем временный список
            var tempFilteredThings = new ObservableCollection<IThing>(filtered);

            // Очищаем текущую коллекцию
            FilteredThings.Clear();

            // Копируем элементы из временного списка в FilteredThings
            foreach (var thing in tempFilteredThings)
            {
                FilteredThings.Add(thing);
            }
            
        }
        private void FilterAll()
        {
            Console.WriteLine("FilterAll command executed");
            FilterThings();
        }

        private void FilterBlocks()
        {
            Console.WriteLine("FilterBlocks command executed");
            FilterThings("Block");
        }

        private void FilterTools()
        {
            Console.WriteLine("FilterPets command executed");
            FilterThings("Tool");
        }
        
        private void FilterPets()
        {
            Console.WriteLine("FilterPets command executed");
            FilterThings("Pet");
        }

        private void FilterArmor()
        {
            Console.WriteLine("FilterPets command executed");
            FilterThings("Armor");
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
    }

    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
        }

        public void Execute(object parameter)
        {
            _execute();
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }

