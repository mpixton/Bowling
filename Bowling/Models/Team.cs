using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Bowling.Models
{
    [Index(nameof(TeamId), Name = "TeamID", IsUnique = true)]
    public partial class Team
    {
        public Team()
        {
            Bowlers = new HashSet<Bowler>();
            TourneyMatchEvenLaneTeams = new HashSet<TourneyMatch>();
            TourneyMatchOddLaneTeams = new HashSet<TourneyMatch>();
        }

        [Key]
        [Column("TeamID", TypeName = "int")]
        public long TeamId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar (50)")]
        public string TeamName { get; set; }

        [Column("CaptainID", TypeName = "int")]
        public long? CaptainId { get; set; }

        [InverseProperty(nameof(Bowler.Team))]
        public virtual ICollection<Bowler> Bowlers { get; set; }

        [InverseProperty(nameof(TourneyMatch.EvenLaneTeam))]
        public virtual ICollection<TourneyMatch> TourneyMatchEvenLaneTeams { get; set; }

        [InverseProperty(nameof(TourneyMatch.OddLaneTeam))]
        public virtual ICollection<TourneyMatch> TourneyMatchOddLaneTeams { get; set; }
    }
}
