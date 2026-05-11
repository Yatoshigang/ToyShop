using System;
using System.Collections.Generic;
using System.Text;
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
        public string Content { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public ICommand Command { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="command"></param>
        public InStartViewButton(string content)
        {
            Content = content;
        }



    }
}
