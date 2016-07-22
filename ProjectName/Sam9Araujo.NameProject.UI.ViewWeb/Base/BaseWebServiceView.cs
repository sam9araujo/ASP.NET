using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboris.Cosan.UI.ViewWeb
{
    public class BaseWebServiceView<T> : System.Web.Services.WebService
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
