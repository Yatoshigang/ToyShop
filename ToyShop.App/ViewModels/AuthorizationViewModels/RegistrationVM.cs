using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using ToyShop.App.Views.AuthorizationComponents;
using ToyShop.App.Views;

namespace ToyShop.App.ViewModels.AuthorizationViewModels
{
    /// <summary>
    /// Класс логики для страницы <see cref="RegistrationPage">RegistrationPage</see> для представления <see cref="AuthorizationWindow">AuthorizationWindow</see>
    /// </summary>
    public partial class RegistrationVM : ObservableObject
    {
        [ObservableProperty]
        string _lastName;
        [ObservableProperty]
        string _firstName;
        [ObservableProperty]
        string _patronymic;
        [ObservableProperty]
        string _email;
        [ObservableProperty]
        string _login;
        [ObservableProperty]
        string _password;


        public RegistrationVM()
        {
            _lastName = _firstName = _patronymic = _email = _login = _password = string.Empty;
        }

        [RelayCommand]
        void SubmitRegistration()
        {
            if (Validation(LastName) && Validation(FirstName) && Validation(Patronymic) && Validation(Email) && Validation(Login) && PasswordValidation())
            {
                
            }
        }

        bool Validation(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || !char.IsLetter(value[0]))
            {
                return false;
            }
            
            for (int index = 1; index < value.Length; index++)
            {
                if (!char.IsLetterOrDigit(value[index]))
                {
                    return false;
                }
            }
            return true;
        }
        bool PasswordValidation()
        {
            if (string.IsNullOrWhiteSpace(Password))
            {
                return false;
            }
            foreach (char ch in Password)
            {
                if (char.IsControl(ch))
                {
                    return false;
                }
            }
            return true;
        }


    }
}
