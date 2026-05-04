using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToyShop.App.ViewModels.MainViewModels.MainCommonViewModels
{
    public partial class ProfileVM : ObservableObject
    {
        string _firstName;
        string _lastName;
        string _patronymic;
        string _email;

        public ProfileVM()
        {
            
        }
    }
}
