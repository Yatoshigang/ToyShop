using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ToyShop.App.ViewModels.MainViewModels.MainAdminViewModels.AdminPagesSubobjects;

namespace ToyShop.App.Views.Windows.Forms.Admin
{
    /// <summary>
    /// Логика взаимодействия для ClientFormWindow.xaml
    /// </summary>
    public partial class ClientFormWindow : Window
    {
        public ClientFormWindow()
        {
            InitializeComponent();
            DataContext = new ClientsFormVM();
        }
    }
}
