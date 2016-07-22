using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sam9araujo.NameProject.Service.WebService.Contracts
{
    public class InterfaceCustomer
    {
        public InterfaceCustomer() { }
        public InterfaceCustomer(int status)
        {
            Status = status;
        }
        public InterfaceCustomer(
            int status,
            string govId,
            string firstName,
            string lastName,
            string address,
            string number,
            string complement,
            string cityRegion,
            string addressReference,
            string city,
            string state,
            string zipCode,
            string phone,
            string ddd,
            string email)
        {

            _status = status;
            _govId = govId;
            _firstName = firstName;
            _lastName = lastName;
            _address = address;
            _number = number;
            _complement = complement;
            _cityRegion = cityRegion;
            _addressReference = addressReference;
            _city = city;
            _state = state;
            _zipCode = zipCode;
            _phone = phone;
            _ddd = ddd;
            _email = email;        
        }

        private int _status;
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private string _govId;
        public string GovId
        {
            get { return _govId; }
            set { _govId = value; }
        }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        private string _address;
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        private string _number;
        public string Number
        {
            get { return _number; }
            set { _number = value; }
        }

        private string _complement;
        public string Complement
        {
            get { return _complement; }
            set { _complement = value; }
        }

        private string _cityRegion;
        public string CityRegion
        {
            get { return _cityRegion; }
            set { _cityRegion = value; }
        }

        private string _addressReference;
        public string AddressReference
        {
            get { return _addressReference; }
            set { _addressReference = value; }
        }

        private string _city;
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        private string _state;
        public string State
        {
            get { return _state; }
            set { _state = value; }
        }

        private string _zipCode;
        public string ZipCode
        {
            get { return _zipCode; }
            set { _zipCode = value; }
        }

        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        private string _ddd;
        public string DDD
        {
            get { return _ddd; }
            set { _ddd = value; }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
    }
}