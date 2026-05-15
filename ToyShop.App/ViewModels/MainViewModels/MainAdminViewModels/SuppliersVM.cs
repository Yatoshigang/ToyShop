using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ToyShop.Core.Models;

namespace ToyShop.App.ViewModels.MainViewModels.MainAdminViewModels
{
    public partial class SuppliersVM : ObservableObject
    {
        [ObservableProperty]
        string _search;
        [ObservableProperty]
        ObservableCollection<Supplier> _suppliers = new();
        
        public SuppliersVM()
        {
            _search = "";
            RefreshSuppliersCollection();
        }

        [RelayCommand]
        void RefreshSuppliersCollection()
        {
            Suppliers = new ObservableCollection<Supplier>(App.ctx.Suppliers.ToList());
        }

        [RelayCommand]
        void Refresh()
        {
            
        }

        [RelayCommand]
        void Add()
        {

        }
        [RelayCommand]
        void Manage()
        {

        }
        [RelayCommand]
        void Delete()
        {

        }
    }
}
