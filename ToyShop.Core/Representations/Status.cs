using System;
using System.Collections.Generic;
using System.Text;

namespace ToyShop.Core.Representations
{
    /// <summary>
    /// Перечисление статусов заказа
    /// </summary>
    public enum Status
    {
        Pending = 0,
        Adopted = 1,
        PaymentAwait = 2,
        Paid = 3,
        Completed = 4
    }
}
