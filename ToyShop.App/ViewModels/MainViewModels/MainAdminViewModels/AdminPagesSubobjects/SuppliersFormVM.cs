using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using ToyShop.Core.Models;

namespace ToyShop.App.ViewModels.MainViewModels.MainAdminViewModels.AdminPagesSubobjects
{
    public partial class SuppliersFormVM : ObservableObject
    {
        Supplier _supplier = new();
        bool _isAdd;
        Window _window;
        [ObservableProperty]
        string _title;
        [ObservableProperty]
        string _country;
        [ObservableProperty]
        string _phone;
        
        public SuppliersFormVM(Window windowInstance, in bool isAdd, Supplier supplier)
        {
            _supplier = isAdd ? new() : supplier;
            _window = windowInstance;
            _isAdd = isAdd;
        }


        [RelayCommand]
        void Submit()
        {
            if (string.IsNullOrWhiteSpace(Title) && string.IsNullOrWhiteSpace(Country) && PhoneValidation())
            {
                if (_isAdd)
                {
                    ChangeSupplier();
                    App.ctx.Suppliers.Add(_supplier);
                }
                else
                {
                    ChangeSupplier();
                    _supplier = App.ctx.Suppliers.Where(s => s.Id == _supplier.Id).First();
                    
                }
                _window.Close();
            }
        }

        void ChangeSupplier()
        {
            _supplier.Name_sup = Title;
            _supplier.Country_sup = Country;
            _supplier.Number = Phone;
        }

        bool PhoneValidation()
        {
            Regex template = new("^[+7 || 8][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]$", RegexOptions.Compiled);
            return template.IsMatch(Phone);
        }
    }
}
