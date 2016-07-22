using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sam9araujo.NameProject.Service.WebService.Contracts
{
    public class InterfaceStatus
    {
        public InterfaceStatus(){}

        public InterfaceStatus(FinalizeOrderEnum status)
        {
            _status = (int)status;
        }

        public InterfaceStatus(RefundPointsEnum status)
        {
            _status = (int)status;
        }

        private int _status;
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }
    }
}