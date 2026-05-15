using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using ToyShop.Core.Models;

namespace ToyShop.App.ViewModels.MainViewModels.MainUserViewModels
{
    public partial class CartVM : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<CartWrapper> _cart;

        public CartVM()
        {
            _cart = new ObservableCollection<CartWrapper>();
        }

        public void AddToCart(Product product)
        {
            foreach (CartWrapper item in Cart)
            {
                if (item.Product == product)
                {
                    return;
                }
            }
            Cart.Add(new CartWrapper(product));
        }


        [RelayCommand]
        void BuyProduct(string productName)
        {
            MessageBox.Show($"{productName} куплен!");
        }


        [RelayCommand]
        void IncreaseCount(string name_prod)
        {
            ChangeValue(name_prod, true);
        }


        [RelayCommand]
        void DecreaseCount(string name_prod)
        {
            ChangeValue(name_prod, false);
        }

        void ChangeValue(string name_prod, bool isIncrement)
        {
            for (int index = 0; index < Cart.Count; index++)
            {
                if (Cart[index].Product.Name_prod == name_prod)
                {
                    _cart[index].ChangeCount(isIncrement);
                    Cart = new ObservableCollection<CartWrapper>(_cart);
                    
                }

            }
        }


    }

    public class CartWrapper 
    {
        public Product Product { get; set; }
        public int Count { get; set; }

        public CartWrapper(Product product)
        {
            Product = product;
            Count = 1;
        }

        public void ChangeCount(in bool isIncrement)
        {
            if (isIncrement) Count++;
            else if (Count > 1) Count--;
        }
    }
}
