using System;
using System.Collections.Generic;
using System.Text;

namespace ToyShop.Core.Representations
{
    [Flags]
    public enum Statuses
    {
        Pending = 0 << 0,
        Adopted = 0 << 1,
        PaymentAwait = 0 << 2,
        Paid = 0 << 3,
        Completed = Adopted | Paid
    }
}
