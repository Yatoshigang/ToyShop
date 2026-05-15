using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;
using ToyShop.Core.Models;

namespace ToyShop.App.ViewModels.MainViewModels.MainCommonViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ProfileVM : ObservableObject
    {
        [ObservableProperty]
        string _firstName;
        [ObservableProperty]
        string _lastName;
        [ObservableProperty]
        string _patronymic;
        [ObservableProperty]
        string _email;

        private ProfileVM(string firstName = "", string lastName = "", string patronymic = "", string email = "")
        {
            FirstName = firstName;
            LastName = lastName;
            Patronymic = patronymic;
            Email = email;
        }

        public ProfileVM(in Administration admin) : this(admin.FirstName, admin.LastName, admin.MiddleName, admin.Email)
        {

        }

        public ProfileVM(in User user) : this(user.FirstName, user.LastName, user.MiddleName, user.Email)
        {
            
        }
    }
}
