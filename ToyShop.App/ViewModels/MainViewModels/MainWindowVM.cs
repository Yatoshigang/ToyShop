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
    /// <summary>
    /// Класс для логики представления <see cref="MainWindow">MainWindow</see>
    /// </summary>
    public partial class MainWindowVM : ObservableObject
    {
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
            InStartViewButtons = new();
            

            App.user = user;
            App.Current.MainWindow = new MainWindow(this);
            App.Current.MainWindow.Title = AdminValidator(in user, in userIsAdmin);


            App.Current.MainWindow.Show();
            
            
        }


        string AdminValidator(in User user, in bool userIsAdmin)
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

        void CreateInStartButtonsPool(in bool userIsAdmin)
        {
            if (userIsAdmin)
            {
                
            }
            else
            {
                InStartViewButtons.Add(new InStartViewButton());
            }
        }

        void GoToComponent<T>()
        {
            
        }

    }
}
