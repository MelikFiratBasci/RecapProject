using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete
{
    public class Color : IEntity
    {
        public int ColorId { get; set; }
        public int ColorName { get; set; }

    }
}
