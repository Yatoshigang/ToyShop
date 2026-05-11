using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ToyShop.App.Views;
using ToyShop.App.Views.MainComponents;
using ToyShop.Core.Models;

namespace ToyShop.App.ViewModels.MainViewModels
{
    /// <summary>
    /// Класс для логики представления <see cref="MainWindow">MainWindow</see>
    /// </summary>
    public partial class MainWindowVM : ObservableObject
    {
        Window _window;
        List<InStartViewButton> _commonStartViewButtons;
        public List<InStartViewButton> InStartViewButtons { get; private set; }

        [ObservableProperty]
        object _frameContent;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user">Экземпляр класса <see cref="User">User</see></param>
        /// <param name="userIsAdmin">Параметр для проверки пользователя на права администратора</param>
        
        public MainWindowVM(User user, bool userIsAdmin)
        {
            _window = App.Current.MainWindow;

            _commonStartViewButtons = new List<InStartViewButton>()
            {
                new InStartViewButton("Профиль", new ProfilePage()),
                new InStartViewButton("Категории", new CategoriesPage()),
                new InStartViewButton("Бренд", new BrandsPage()),
                new InStartViewButton("Товары", new ProductsPage())
            };
            InStartViewButtons = _commonStartViewButtons;
            _frameContent = InStartViewButtons.First().DependentPage;

            App.user = user;
            App.Current.MainWindow = new MainWindow(this);
            App.Current.MainWindow.Left = _window.Left;
            App.Current.MainWindow.Top = _window.Top;
            App.Current.MainWindow.Title = OnStartAdminValidator(in user, in userIsAdmin);
            _window.Close();
            App.Current.MainWindow.Show();
        }


        string OnStartAdminValidator(in User user, in bool userIsAdmin)
        {
            if (userIsAdmin)
            {
                 return $"Учетная запись администратора {user.LastName} {char.ToUpper(user.FirstName[0])}.{char.ToUpper(user.MiddleName[0])}.";
            }
            else
            {
                return $"Учетная запись пользователя {user.LastName} {char.ToUpper(user.FirstName[0])}.{char.ToUpper(user.MiddleName[0])}.";
            }
        }

        void OnStartGenerateButtonsPool(in bool userIsAdmin)
        {
            if (userIsAdmin)
            {
                
            }
            else
            {
                InStartViewButtons.Add(new InStartViewButton());
            }
        }

        [RelayCommand]
        void GoToComponent(Page page)
        {
            if (FrameContent == page)
            {
                return;
            }
            FrameContent = page;
        }

        [RelayCommand]
        void LogOut()
        {
            _window = App.Current.MainWindow;
            App.Current.MainWindow = new AuthorizationWindow();
            App.Current.MainWindow.Left = _window.Left;
            App.Current.MainWindow.Top = _window.Top;
            App.Current.MainWindow.Show();
            _window.Close();
            GC.Collect();
        }
    }
}
