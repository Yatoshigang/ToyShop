using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ToyShop.Core.Models;

namespace ToyShop.App.ViewModels.MainViewModels.MainCommonViewModels
{
    public partial class BrandsVM : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Brand> _brands;
        public BrandsVM()
        {
            _brands = new ObservableCollection<Brand>(App.ctx.Brands.ToList());
        }

        [RelayCommand]
        void GoToProducts(string brand)
        {
            (App.Current.MainWindow.DataContext as MainWindowVM).GoToProductsComponentWithCondition(brand);
        }
    }
}
