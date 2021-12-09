using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AddressBookWebAPI.Models
{
    public partial class Phone
    {
        public int UserId { get; set; }
        [Key]
        [StringLength(11)]
        public string PhonNumber { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("Phones")]
        public virtual User User { get; set; }
    }
}
