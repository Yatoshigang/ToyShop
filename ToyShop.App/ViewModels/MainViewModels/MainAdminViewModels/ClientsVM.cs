using CommunityToolkit.Mvvm.ComponentModel;
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
        ObservableCollection<Customer> _clients;
        public ClientsVM()
        {
            
        }

        void Refresh()
        {
            Clients = new ObservableCollection<Customer>(App.ctx.Customers.ToList());
        }
    }
}
