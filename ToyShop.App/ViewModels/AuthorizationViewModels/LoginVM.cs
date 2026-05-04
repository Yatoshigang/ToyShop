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

        public LoginVM()
        {
            _login = string.Empty;
            _password = string.Empty;
            _user = null!;
        }


        [RelayCommand]
        void SubmitLogin()
        {
            MainValidation();
            if (_user == null)
            {
                MessageBox.Show("Неправильный логин или пароль");
                return;
            }
            GoToMainWindow();
        }

        void MainValidation()
        {
            _user = App.ctx.users.Where(u => u.Login == _login && u.Password == _password).FirstOrDefault()!;
        }

        bool IsAdminValidation() => App.ctx.Administrations.Where(a => a.Id_adm_user == _user.Id).Any();

        void GoToMainWindow()
        {
            new MainWindowVM(_user, IsAdminValidation());
        }
        
    }
}
