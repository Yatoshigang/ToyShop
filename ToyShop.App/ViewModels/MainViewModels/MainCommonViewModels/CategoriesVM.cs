using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ToyShop.Core.Models;

namespace ToyShop.App.ViewModels.MainViewModels.MainCommonViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public partial class CategoriesVM : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Category> _categories;


        public CategoriesVM()
        {
            Categories = new ObservableCollection<Category>(App.ctx.Categories.ToList());
        }

        [RelayCommand]
        void GoToProducts(string category)
        {
            (App.Current.MainWindow.DataContext as MainWindowVM)?.GoToProductsComponentWithCondition(category);
        }
    }
}
