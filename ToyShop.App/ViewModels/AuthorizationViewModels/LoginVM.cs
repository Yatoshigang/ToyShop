using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using ToyShop.App.ViewModels.MainViewModels;
using ToyShop.App.Views;
using ToyShop.Core.Models;
using ToyShop.App.Views.AuthorizationComponents;
using Microsoft.EntityFrameworkCore;
namespace ToyShop.App.ViewModels.AuthorizationViewModels
{
    /// <summary>
    /// Класс логики страницы <see cref="LoginPage">LoginPage</see> для окна <see cref="AuthorizationWindow">AuthorizationWindow</see>
    /// </summary>
    public partial class LoginVM : ObservableObject
    {
        [ObservableProperty]
        string _login;
        [ObservableProperty]
        string _password;
        User _user;
        Administration _admin;

        public LoginVM()
        {
#if DEBUG
            _login = "LilTom";
            _password = "qwerty";
#else
            _login = string.Empty;
            _password = string.Empty;
            
#endif
            _user = null!;
            _admin = null!;
        }


        [RelayCommand]
        void SubmitLogin()
        {
            _user = App.ctx.Users.Where(u => u.Login == Login && u.Password == Password).FirstOrDefault()!;
            _admin = App.ctx.Administrations.Where(a => a.Login == Login && a.Password == Password).FirstOrDefault()!;

            if (_user == null && _admin == null)
            {
                MessageBox.Show("Неправильный логин или пароль");
                return;
            }
            else if (_admin != null)
            {
                GoToMainWindow(true);
                _user = null!;
                return;
            }
            else if (_user != null)
            {
                GoToMainWindow(false);
                _admin = null!;
                return;
            }
        }



        void GoToMainWindow(bool isAdmin)
        {
            if (isAdmin)
            {
                new MainWindowVM(in _admin);
            }
            else
            {
                new MainWindowVM(in _user);
            }
        }
        
    }
}
