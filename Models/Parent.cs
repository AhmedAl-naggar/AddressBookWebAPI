using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AddressBookWebAPI.Models
{
    public partial class Parent
    {
        [Key]
        public int UserId { get; set; }
        public int FatherId { get; set; }
        public int MotherId { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("Parent")]
        public virtual User User { get; set; }
    }
}
