﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.DTOs
{
    public class CarDetailDto :IDto
    {
        public int Id { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
        public string BrandName { get; set; }
  


    }
}
