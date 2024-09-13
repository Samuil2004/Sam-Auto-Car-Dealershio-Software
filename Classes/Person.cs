using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public abstract class Person
    {
        private string firstName;
        private string lastName;
        private string email;
        private int id;
        private string phoneNumber;

        public Person(string firstName, string lastName, string email,string phoneNumber)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.phoneNumber = phoneNumber;
        }
        public Person(int personId, string firstName, string lastName, string email, string phoneNumber)
        {
            this.id = personId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.phoneNumber = phoneNumber;
        }

        public string GetFirstName
        {
            get { return firstName; }
        }
        public string GetLastName
        {
            get { return lastName;}
        }
        public string GetEmail
        {
            get { return email;}
        }
        public int GetId
        {
            get { return id;}
        }
        public string GetPhoneNumber
        {
            get { return phoneNumber;}
        }
        public string GetIdentifyingInfo
        {
            get { return $"{email} - {firstName} {lastName}"; }
        }
    }
}
