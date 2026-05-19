using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using ToyShop.App.Views.AuthorizationComponents;
using ToyShop.App.Views;
using ToyShop.Core.Models;
using System.Windows;
using System.Text.RegularExpressions;

namespace ToyShop.App.ViewModels.AuthorizationViewModels
{
    /// <summary>
    /// Класс логики для страницы <see cref="RegistrationPage">RegistrationPage</see> для представления <see cref="AuthorizationWindow">AuthorizationWindow</see>
    /// </summary>
    public partial class RegistrationVM : ObservableObject
    {
        User _user;

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
#if DEBUG
            _lastName = "Иванов";
            _firstName = "Иван";
            _patronymic = "Иванович";
            _email = "Ivan@mail.com";
            _login = "Ivan";
            _password = "qwerty";
#else
            _lastName = _firstName = _patronymic = _email = _login = _password = string.Empty;
#endif
            _user = new();
        }

        [RelayCommand]
        void SubmitRegistration()
        {
            if (PasswordValidation() && Validation(LastName) && Validation(FirstName) && Validation(Patronymic) && Validation(Login) && Validation(Password) && EmailValidation())
            {
                SaveData();
                MessageBox.Show("Успех");
            }
            else
            {
                MessageBox.Show("Неправильно введены данные");
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

        bool EmailValidation()
        {
            Regex pattern = new Regex(@"^\w+@[A-z]+.[a-z]+$", RegexOptions.Compiled);
            return pattern.IsMatch(Email);
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

        
        void SaveData()
        {
            _user = new();
            _user.LastName = LastName;
            _user.FirstName = FirstName;
            _user.MiddleName = Patronymic;
            _user.Email = Email;
            _user.Login = Login;
            _user.Password = Password;
            App.ctx.Users.Add(_user);
            App.ctx.SaveChanges();
        }
    }
}
