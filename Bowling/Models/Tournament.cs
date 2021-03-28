using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Bowling.Models
{
    public partial class Tournament
    {
        public Tournament()
        {
            TourneyMatches = new HashSet<TourneyMatch>();
        }

        [Key]
        [Column("TourneyID", TypeName = "int")]
        public long TourneyId { get; set; }

        [Column(TypeName = "date")]
        public byte[] TourneyDate { get; set; }

        [Column(TypeName = "nvarchar (50)")]
        public string TourneyLocation { get; set; }


        [InverseProperty(nameof(TourneyMatch.Tourney))]
        public virtual ICollection<TourneyMatch> TourneyMatches { get; set; }
    }
}
