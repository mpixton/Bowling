using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Bowling.Models
{
    [Table("ztblBowlerRatings")]
    public partial class ZtblBowlerRating
    {
        [Key]
        [Column(TypeName = "nvarchar (15)")]
        public string BowlerRating { get; set; }
        [Column(TypeName = "smallint")]
        public long? BowlerLowAvg { get; set; }
        [Column(TypeName = "smallint")]
        public long? BowlerHighAvg { get; set; }
    }
}
