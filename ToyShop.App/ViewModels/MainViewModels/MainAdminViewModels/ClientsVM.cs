using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ToyShop.Core.Models;

namespace ToyShop.App.ViewModels.MainViewModels.MainAdminViewModels
{
    public partial class ClientsVM : ObservableObject
    {
        [ObservableProperty]
        string _search;
        [ObservableProperty]
        ObservableCollection<Customer> _clients;
        public ClientsVM()
        {
            RefreshClientsCollection();
        }

        void RefreshClientsCollection()
        {
            Clients = new ObservableCollection<Customer>(App.ctx.Customers.ToList());
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
