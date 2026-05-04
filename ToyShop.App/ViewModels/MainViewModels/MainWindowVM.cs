using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using ToyShop.App.Views;
using ToyShop.Core.Models;

namespace ToyShop.App.ViewModels.MainViewModels
{
    public partial class MainWindowVM : ObservableObject
    {
        Window _window;
        string _windowTitle;
        
        public MainWindowVM(User user, bool userIsAdmin)
        {
            App.user = user;
            App.Current.MainWindow = _window = new MainWindow(this);
            if (userIsAdmin)
            {
                _windowTitle = $"Учетная запись администратора {user.LastName} {char.ToUpper(user.FirstName[0])}.{char.ToUpper(user.MiddleName[0])}.";
            }
            else
            {
                _windowTitle = $"Учетная запись пользователя {user.LastName} {char.ToUpper(user.FirstName[0])}.{char.ToUpper(user.MiddleName[0])}.";
            }
            _window.Title = _windowTitle;
            App.Current.MainWindow.Show();
            
            
        }
    }
}
