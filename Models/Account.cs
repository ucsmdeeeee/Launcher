using System.Windows.Media;

namespace WpfApp3.Models;

public class Account : IAccount
{
    public int Id { get; set; }
    public string NickName { get; set; }
    public ImageSource Avatar { get; set; }
}