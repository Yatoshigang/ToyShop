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
        /// <value>
        /// Свойство для контекста базы данных
        /// </value>
        public static ShopContext ctx;
        /// <value>
        /// Свойство для сохранения экземпляра вошедшего пользователя
        /// </value>
        public static User user;
        /// <summary>
        /// 
        /// </summary>
        public static Administration admin;

        static App()
        {
            ctx = new();
            user = null!;
            admin = null!;
        }
    }

}
