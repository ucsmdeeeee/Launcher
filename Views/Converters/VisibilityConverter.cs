using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using WpfApp3.ViewModels;

namespace WpfApp3.Views.Converters
{
    public class VisibilityConverter : DependencyObject, IValueConverter, INotifyPropertyChanged
    {
        public static readonly DependencyProperty SelectedPriceProperty =
            DependencyProperty.Register(nameof(SelectedPrice), typeof(int), typeof(VisibilityConverter), 
                new PropertyMetadata(100));

        public event PropertyChangedEventHandler? PropertyChanged;

        public int SelectedPrice
        {
            get { return (int)GetValue(SelectedPriceProperty); }
            set 
            { 
                SetValue(SelectedPriceProperty, value); 
                OnPropertyChanged("SelectedPrice");
            }
        }

        private static void OnSelectedPriceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var converter = d as VisibilityConverter;
            converter?.OnPropertyChanged(nameof(SelectedPrice));
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null || SelectedPrice <= 0)
                return Visibility.Collapsed;

            if (int.TryParse(value.ToString(), out int price))
            {
                return price <= SelectedPrice ? Visibility.Visible : Visibility.Collapsed;
            }

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
