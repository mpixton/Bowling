using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Bowling.Models
{
    [Index(nameof(BowlerLastName), Name = "BowlerLastName")]
    [Index(nameof(TeamId), Name = "BowlersTeamID")]
    public partial class Bowler
    {
        public Bowler()
        {
            BowlerScores = new HashSet<BowlerScore>();
        }

        [Key]
        [Column("BowlerID", TypeName = "int")]
        public long BowlerId { get; set; }

        [Column(TypeName = "nvarchar (50)")]
        public string BowlerLastName { get; set; }

        [Column(TypeName = "nvarchar (50)")]
        public string BowlerFirstName { get; set; }

        [Column(TypeName = "nvarchar (1)")]
        public string BowlerMiddleInit { get; set; }

        [Column(TypeName = "nvarchar (50)")]
        public string BowlerAddress { get; set; }

        [Column(TypeName = "nvarchar (50)")]
        public string BowlerCity { get; set; }

        [Column(TypeName = "nvarchar (2)")]
        public string BowlerState { get; set; }

        [Column(TypeName = "nvarchar (10)")]
        public string BowlerZip { get; set; }

        [Column(TypeName = "nvarchar (14)")]
        public string BowlerPhoneNumber { get; set; }

        [Column("TeamID", TypeName = "int")]
        public long? TeamId { get; set; }

        [ForeignKey(nameof(TeamId))]
        [InverseProperty("Bowlers")]
        public virtual Team Team { get; set; }

        [InverseProperty(nameof(BowlerScore.Bowler))]
        public virtual ICollection<BowlerScore> BowlerScores { get; set; }
    }
}
