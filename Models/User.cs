using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AddressBookWebAPI.Models
{
    public partial class User
    {
        public User()
        {
            Friends = new HashSet<Friend>();
            Phones = new HashSet<Phone>();
        }

        [Key]
        public int UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public DateTime UserDateOfBirth { get; set; }
        public string UserPhoneNumber { get; set; }
        public string UserEmail { get; set; }

        [InverseProperty("User")]
        public virtual Parent Parent { get; set; }
        [InverseProperty(nameof(Friend.FriendNavigation))]
        public virtual ICollection<Friend> Friends { get; set; }
        [InverseProperty(nameof(Phone.User))]
        public virtual ICollection<Phone> Phones { get; set; }
    }
}
