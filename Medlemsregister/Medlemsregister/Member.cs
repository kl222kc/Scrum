using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medlemsregister
{
    class Member
    {
        private string _firstName;
        private string _lastName;
        private string _phoneNumber;

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Förnamnet är felaktigt");
                }
                _firstName = value;
            }
        }

        public int Id
        {
            get;
            set;
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Efternamnet är felaktigt");
                }
                _lastName = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Telefonnumret är felaktigt");
                }
                _phoneNumber = value;
            }
        }

        public Member(int id, string firstName, string lastName, string phoneNumber)
        {
            FirstName = firstName;
            Id = id;
            LastName = lastName;
            PhoneNumber = phoneNumber;
        }
    }
}
