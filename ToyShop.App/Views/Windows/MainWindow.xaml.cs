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
using ToyShop.App.ViewModels.MainViewModels;

namespace ToyShop.App.Views
{
    /// <summary>
    /// Класс для взаимодействия с окном MainWindow.xaml
    /// </summary>
    /// <remarks>
    /// Создается посредством создания экземпляра модели представления MainWindowVM
    /// </remarks>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vm">Представляет экземпляр <see cref="MainWindowVM">модели представления</see></param>
        /// 
        public MainWindow(MainWindowVM vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}
