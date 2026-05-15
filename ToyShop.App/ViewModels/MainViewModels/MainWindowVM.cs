using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ToyShop.App.ViewModels.MainViewModels.MainCommonViewModels;
using ToyShop.App.ViewModels.MainViewModels.MainUserViewModels;
using ToyShop.App.Views;
using ToyShop.App.Views.MainComponents;
using ToyShop.App.Views.MainComponents.MainAdminComponents;
using ToyShop.Core.Models;

namespace ToyShop.App.ViewModels.MainViewModels
{
    /// <summary>
    /// Класс для логики представления <see cref="MainWindow">MainWindow</see>
    /// </summary>
    public partial class MainWindowVM : ObservableObject
    {
        Window _window;
        
        [ObservableProperty]
        Dictionary<string, Page> _pages;
        [ObservableProperty]
        Page _frameContent;
        


        private MainWindowVM()
        {
            _window = App.Current.MainWindow;

            _pages = new();
            OnStartGenerateButtonsPool();

            App.Current.MainWindow = new MainWindow(this);
            App.Current.MainWindow.Left = _window.Left;
            App.Current.MainWindow.Top = _window.Top;
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        public MainWindowVM(in User user) : this()
        {
            App.admin = null!;
            App.user = user;

            OnStartWriteTitle(in user);
            OnStartGenerateButtonsPoolByRole();
            _frameContent = _pages.First().Value;

            App.Current.MainWindow.Show();
            _window.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="admin"></param>
        public MainWindowVM(in Administration admin) : this()
        {
            App.user = null!;
            App.admin = admin;

            OnStartWriteTitle(admin);
            OnStartGenerateButtonsPoolByRole();
            _frameContent = _pages.First().Value;

            App.Current.MainWindow.Show();
            _window.Close();
        }

        void OnStartWriteTitle(in User user)
        {
            App.Current.MainWindow.Title = $"Учетная запись пользователя {user}.";
        }

        void OnStartWriteTitle(in Administration admin)
        {
            App.Current.MainWindow.Title = $"Учетная запись администратора {admin.LastName} {char.ToUpper(admin.FirstName[0])}.{char.ToUpper(admin.MiddleName[0])}.";
        }

        void OnStartGenerateButtonsPool()
        {
            Pages.Add("Профиль", null!);
            Pages.Add("Категории", new CategoriesPage());
            Pages.Add("Брэнд", new BrandsPage());
            Pages.Add("Товары", new ProductsPage());
            
        }

        void OnStartGenerateButtonsPoolByRole()
        {
            Pages[Pages.First().Key] = new ProfilePage();
            if (App.admin != null)
            {
                Pages.Add("Продажи", new SalesPage());
                Pages.Add("Поставщики", new SuppliersPage());
                Pages.Add("Клиенты", new ClientsPage());
            }
            else
            {
                Pages.Add("Корзина", new CartPage());
            }
        }

        [RelayCommand]
        void GoToComponent(Page page)
        {
            if (FrameContent == page)
            {
                return;
            }
            if (page is ProductsPage)
            {
                GoToProductsComponentWithCondition();
                return;
            }
            FrameContent = page;
        }


        public void GoToProductsComponentWithCondition(string filterObjective = "")
        {
            ProductsVM productsVM = Pages["Товары"].DataContext as ProductsVM;
            if (!string.IsNullOrWhiteSpace(filterObjective))
            {
                productsVM?.SelectedProducts = new System.Collections.ObjectModel.ObservableCollection<Product>(productsVM.AllProducts.Where(ap => ap.Category.Name_cat == filterObjective || ap.Brand.Name == filterObjective));
            }
            else
            {
                productsVM?.SelectedProducts = productsVM?.AllProducts;
            }
            FrameContent = Pages["Товары"];
            
        }

        public void AddProductInCart(Product product)
        {
            (Pages["Корзина"].DataContext as CartVM).Cart.Add(new CartWrapper(product));
        }

        [RelayCommand]
        void LogOut()
        {
            _window = App.Current.MainWindow;
            App.Current.MainWindow = new AuthorizationWindow();
            App.Current.MainWindow.Left = _window.Left;
            App.Current.MainWindow.Top = _window.Top;
            App.Current.MainWindow.Show();
            _window.Close();
        }
    }
}
