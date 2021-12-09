using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AddressBookWebAPI.Models
{
    public partial class Friend
    {
        public int UserId { get; set; }
        [Key]
        public int Id { get; set; }
        public int FriendId { get; set; }

        [ForeignKey(nameof(FriendId))]
        [InverseProperty(nameof(User.Friends))]
        public virtual User FriendNavigation { get; set; }
    }
}
