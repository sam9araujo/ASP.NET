using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sam9araujo.NameProject.Service.WebService.Contracts
{
    public class InterfacePoints
    {
        public InterfacePoints(){}
        
        public InterfacePoints(decimal points, GetPointsEnum status)
        {
            _points = points;
            _status = (int)status;
        }


        private decimal _points;
        public decimal Points
        {
            get { return _points; }
            set { _points = value; }
        }

        private int _status;
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }
    }
}