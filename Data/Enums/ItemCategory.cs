using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace storeapp.Data.Enums
{
    public enum ItemCategory
    {
        [Description("Dog Food")]
        Dog_Food,
        [Description("Cat Food")]
        Cat_Food,
        [Description("Dog Toys")]
        Dog_Toys,
        [Description("Cat Food")]
        Cat_Toys,
        Hygene,
        [Description("Dog Accessories")]
        Dog_Accessories,
        [Description("Cat Accessories")]
        Cat_Accessories



    }
}
