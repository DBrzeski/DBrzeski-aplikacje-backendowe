﻿using storeapp.Data.Base;
using storeapp.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace storeapp.Models
{
    public class Item:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        //Basic information-----------------------------------
        public string PictureUrl { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        //Basic information-----------------------------------

        public ItemCategory ItemCategory { get; set; }

    }
}
