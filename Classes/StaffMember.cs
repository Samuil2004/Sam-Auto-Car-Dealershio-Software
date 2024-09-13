using Logic_layer.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    /// <summary>
    /// Represents a staff member, a specialized type of Person with additional presonal details such as start date, and role.
    /// Inherits from the abstract <see cref="Person"/> class.
    /// </summary>
    public class StaffMember : Person
    {
        private DateTime dateStarted;
        private StaffMemberRoles staffRole;

        /// <summary>
        /// Initializes a new instance of the <see cref="StaffMember"/> class without an ID.
        /// </summary>
        public StaffMember(string firstName, string lastName, string email, string phoneNumber, DateTime dateStarted, StaffMemberRoles StaffRole) : base(firstName, lastName, email, phoneNumber)
        {
            this.dateStarted = dateStarted;
            this.staffRole = StaffRole;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StaffMember"/> class with an ID.
        /// </summary>
        public StaffMember(int personId, string firstName, string lastName, string email, string phoneNumber, DateTime dateStarted, StaffMemberRoles StaffRole) : base(personId,firstName, lastName, email, phoneNumber)
        {
            this.dateStarted = dateStarted;
            this.staffRole = StaffRole;
        }

        /// <summary>
        /// Gets the date when the staff member started working.
        /// </summary>
        public DateTime GetStartedDate
        {
            get { return dateStarted; }
        }

        /// <summary>
        /// Gets the role of the staff member within the organization.
        /// <see cref="StaffMemberRoles"/> enumeration
        /// </summary>
        public StaffMemberRoles GetStaffRole
        {
            get { return staffRole; }
        }
    }
}
