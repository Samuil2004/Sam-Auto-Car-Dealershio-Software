using Logic_layer.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class StaffMember : Person
    {
        private DateTime dateStarted;
        private StaffMemberRoles staffRole;

        public StaffMember(string firstName, string lastName, string email, string phoneNumber, DateTime dateStarted, StaffMemberRoles StaffRole) : base(firstName, lastName, email, phoneNumber)
        {
            this.dateStarted = dateStarted;
            this.staffRole = StaffRole;
        }
        public StaffMember(int personId, string firstName, string lastName, string email, string phoneNumber, DateTime dateStarted, StaffMemberRoles StaffRole) : base(personId,firstName, lastName, email, phoneNumber)
        {
            this.dateStarted = dateStarted;
            this.staffRole = StaffRole;
        }

        public DateTime GetStartedDate
        {
            get { return dateStarted; }
        }

        public StaffMemberRoles GetStaffRole
        {
            get { return staffRole; }
        }
    }
}
