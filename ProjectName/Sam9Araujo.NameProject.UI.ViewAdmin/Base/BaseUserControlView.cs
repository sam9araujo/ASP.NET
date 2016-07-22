using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboris.Cosan.UI.ViewAdmin
{
    public class BaseUserControlView<T> : System.Web.UI.UserControl
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
