using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace ToyShop.App.ViewModels.MainViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public struct InStartViewButton
    {
        /// <summary>
        /// 
        /// </summary>
        public string Content { get; }

        /// <summary>
        /// 
        /// </summary>
        public Page DependentPage { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="dependentPage"></param>
        public InStartViewButton(string content, Page dependentPage)
        {
            Content = content;
            DependentPage = dependentPage;
        }

        
    }
}
