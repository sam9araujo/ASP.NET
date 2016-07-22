﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sam9araujo.NameProject.UI.Importacao
{
    public class BaseView<T> : System.Windows.Forms.Form
    {
        T _controller;

        public T Controller
        {
            get
            {
                if (_controller == null)
                    _controller = Activator.CreateInstance<T>();

                return _controller;
            }
        }

    }
}
