using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Bowling.Models
{
    [Table("ztblWeeks")]
    public partial class ZtblWeek
    {
        [Key]
        [Column(TypeName = "date")]
        public byte[] WeekStart { get; set; }
        [Column(TypeName = "date")]
        public byte[] WeekEnd { get; set; }
    }
}
