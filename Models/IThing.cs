using System.Windows.Media;

namespace WpfApp3.Models;

public interface IThing
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ImageSource Photo { get; set; }
    public int Price { get; set; }
    public int Count { get; set; }
    public string Category { get; set; }
}