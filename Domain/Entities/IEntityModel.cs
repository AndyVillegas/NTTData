﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public interface IEntityModel
    {
        public int Id { get; set; }
        public bool? Estado { get; set; }
    }
}
