using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace storeapp.Data.Enums
{
    public enum Status
    {
        [Description("Order Submitted")]
        Submited = 1,
        New,
        Sent

    }
}
