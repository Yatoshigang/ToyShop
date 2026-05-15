using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ToyShop.Core.Models;

namespace ToyShop.App.ViewModels.MainViewModels.MainAdminViewModels
{
    public partial class SalesVM : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Sale> _sales;

        public SalesVM()
        {
            _sales = new ObservableCollection<Sale>();
        }

        void Refresh()
        {
            Sales = new ObservableCollection<Sale>(App.ctx.Sales.ToList());
        }
    }
}
