using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sam9araujo.NameProject.Domain.DTO;

namespace Sam9araujo.NameProject.UI.Controller
{
    public class BaseController<T> where T : BaseDTO
    {
        T _view;

        public T View
        {
            get {
                if (_view == null)
                    _view = Activator.CreateInstance<T>();

                return _view;
            }
        }
    }
}
