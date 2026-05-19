using System;
using System.Collections.Generic;
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
using ToyShop.Core.Models;

namespace ToyShop.App.Views.Windows.Forms.Admin
{
    /// <summary>
    /// Логика взаимодействия для SupplierFormWindow.xaml
    /// </summary>
    public partial class SupplierFormWindow : Window
    {
        public SupplierFormWindow(in bool isAdd, Supplier supplier)
        {
            InitializeComponent();
            DataContext = new SuppliersFormVM(this, in isAdd, supplier);
        }
    }
}
