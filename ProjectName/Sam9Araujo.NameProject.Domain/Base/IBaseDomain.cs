﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sam9araujo.NameProject.Domain
{
    public interface IBaseDomain<T>
    {
        T Id
        {
            get;
            set;
        }
    }
}
