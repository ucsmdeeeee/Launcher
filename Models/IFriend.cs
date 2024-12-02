using System.Windows.Media;

namespace WpfApp3.Models;

public interface IFriend
{
    public int Id { get; set; } 
    public ImageSource Image { get; set; }
    public string TextContent { get; set; }
}