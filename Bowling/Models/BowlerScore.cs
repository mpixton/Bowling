using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Bowling.Models
{
    [Table("Bowler_Scores")]
    [Index(nameof(BowlerId), Name = "BowlerID")]
    [Index(nameof(MatchId), nameof(GameNumber), Name = "MatchGamesBowlerScores")]
    public partial class BowlerScore
    {
        [Key]
        [Column("MatchID", TypeName = "int")]
        public long MatchId { get; set; }
        [Key]
        [Column(TypeName = "smallint")]
        public long GameNumber { get; set; }
        [Key]
        [Column("BowlerID", TypeName = "int")]
        public long BowlerId { get; set; }
        [Column(TypeName = "smallint")]
        public long? RawScore { get; set; }
        [Column(TypeName = "smallint")]
        public long? HandiCapScore { get; set; }
        [Required]
        [Column(TypeName = "bit")]
        public bool WonGame { get; set; }

        [ForeignKey(nameof(BowlerId))]
        [InverseProperty("BowlerScores")]
        public virtual Bowler Bowler { get; set; }
    }
}
