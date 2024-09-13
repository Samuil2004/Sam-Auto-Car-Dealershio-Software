using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    /// <summary>
    /// Represents an abstract base class for a person, providing common properties and methods such as first name, last name, email, and phone number.
    /// This class is designed to be inherited by other classes that represent specific types of people by roles that work within the company and have access to the application.
    /// </summary>
    public abstract class Person
    {
        private string firstName;
        private string lastName;
        private string email;
        private int id;
        private string phoneNumber;

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class with basic personal information.
        /// </summary>
        public Person(string firstName, string lastName, string email,string phoneNumber)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.phoneNumber = phoneNumber;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class with a unique identifier and personal information.
        /// </summary>
        public Person(int personId, string firstName, string lastName, string email, string phoneNumber)
        {
            this.id = personId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.phoneNumber = phoneNumber;
        }

        /// <summary>
        /// Gets the first name of the person.
        /// </summary>
        public string GetFirstName
        {
            get { return firstName; }
        }

        /// <summary>
        /// Gets the last name of the person.
        /// </summary>
        public string GetLastName
        {
            get { return lastName;}
        }

        /// <summary>
        /// Gets the email address of the person.
        /// </summary>
        public string GetEmail
        {
            get { return email;}
        }

        /// <summary>
        /// Gets the unique identifier of the person.
        /// </summary>
        public int GetId
        {
            get { return id;}
        }

        /// <summary>
        /// Gets the phone number of the person.
        /// </summary>
        public string GetPhoneNumber
        {
            get { return phoneNumber;}
        }

        /// <summary>
        /// Gets a string containing the person's identifying information (email and full name).
        /// </summary>
        public string GetIdentifyingInfo
        {
            get { return $"{email} - {firstName} {lastName}"; }
        }
    }
}
