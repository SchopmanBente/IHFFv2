﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectIHFFv2.Models
{
    interface IEventRepository
    {
        Event GetById(int id);
    }
}