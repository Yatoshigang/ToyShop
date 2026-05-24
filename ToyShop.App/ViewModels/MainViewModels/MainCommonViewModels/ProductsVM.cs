using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Controls;
using ToyShop.App.ViewModels.MainViewModels.MainUserViewModels;
using ToyShop.Core.Models;

namespace ToyShop.App.ViewModels.MainViewModels.MainCommonViewModels
{
    public partial class ProductsVM : ObservableObject
    {
        [ObservableProperty]
        string _search;
        [ObservableProperty]
        ObservableCollection<string> _sorts;
        [ObservableProperty]
        int _selectedSort;
        [ObservableProperty]
        ObservableCollection<string> _filters;
        [ObservableProperty]
        int _selectedFilter;

        [ObservableProperty]
        ObservableCollection<Product> _allProducts;
        [ObservableProperty]
        ObservableCollection<Product> _selectedProducts;

        [ObservableProperty]
        Product _selectedProduct;

        public ProductsVM()
        {
            _search = "";
            _sorts = new()
            {
                "Без сортировки",
                "От А",
                "От Я"
            };
            _selectedSort = 0;
            _filters = new()
            {
                "Без фильтров",
                "Цена от 1000",
                "Цена до 1000"
            };
            _selectedFilter = 0;

            _selectedProduct = null!;
            Refresh();
            
        }

        [RelayCommand]
        void AddToCartByDoubleClick()
        {
            if (App.admin == null && SelectedProduct != null)
            {
                ((App.Current.MainWindow.DataContext as MainWindowVM).Pages["Корзина"].DataContext as CartVM).AddToCart(SelectedProduct);
            }
        }


        void ApplyModificators()
        {
            UseFilter();
            UseSort();
            UseSearch();
        }

        void UseFilter()
        {
            switch (SelectedFilter)
            {
                case 0: SelectedProducts = new ObservableCollection<Product>(AllProducts);return;
                case 1: SelectedProducts = new ObservableCollection<Product>(AllProducts.Where(ap => ap.Price >= 1000));return;
                case 2: SelectedProducts = new ObservableCollection<Product>(AllProducts.Where(ap => ap.Price <= 1000));return;
            }
        }

        void UseSort()
        {
            switch (SelectedSort)
            {
                case 0: SelectedProducts = new ObservableCollection<Product>(SelectedProducts);return;
                case 1: SelectedProducts = new ObservableCollection<Product>(SelectedProducts.OrderBy(ap => ap.Name_prod));return;
                case 2: SelectedProducts = new ObservableCollection<Product>(SelectedProducts.OrderByDescending(ap => ap.Name_prod));return;
            }
        }

        void UseSearch()
        {
            if (!string.IsNullOrWhiteSpace(Search))
            {
                SelectedProducts = new ObservableCollection<Product>(SelectedProducts.Where(ap => ap.Name_prod.Contains(Search)));
            }
        }


        partial void OnSearchChanged(string value)
        {
            ApplyModificators();
        }

        [RelayCommand]
        void Refresh()
        {
            AllProducts = new ObservableCollection<Product>(App.ctx.Products.ToList());
            SelectedProducts = new ObservableCollection<Product>(AllProducts);
            ApplyModificators();
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
