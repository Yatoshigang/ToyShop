using System.Configuration;
using System.Data;
using System.Windows;
using ToyShop.Core.Context;
using ToyShop.Core.Models;

namespace ToyShop.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ShopContext ctx = new();
        public static User user = null!;
    }

}
