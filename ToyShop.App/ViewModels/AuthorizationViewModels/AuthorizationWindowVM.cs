using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Text;
using ToyShop.App.Views.AuthorizationComponents;
using ToyShop.App.Views;

namespace ToyShop.App.ViewModels.AuthorizationViewModels
{
    /// <summary>
    /// Класс для логики представления <see cref="AuthorizationWindow">AuthorizationWindow</see> 
    /// </summary>
    public partial class AuthorizationWindowVM : ObservableObject
    {
        [ObservableProperty]
        string _buttonTitle;

        object _loginPage = new LoginPage();
        object _registrationPage = new RegistrationPage();

        [ObservableProperty]
        object _frameContent;

        public AuthorizationWindowVM()
        {
            _buttonTitle = "Регистрация";
            _frameContent = new LoginPage();
        }

        [RelayCommand]
        void ChangePage()
        {
            
            if (FrameContent is LoginPage)
            {
                FrameContent = _registrationPage;
            }
            else
            {
                FrameContent = _loginPage;
            }
        }

        partial void OnFrameContentChanged(object value)
        {
            if (value is RegistrationPage)
            {
                ButtonTitle = "Вход";
            }
            else 
            {
                ButtonTitle = "Регистрация";

            }
        }
    }
}
