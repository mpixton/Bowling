using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Bowling.Models
{
    [Table("Tourney_Matches")]
    [Index(nameof(OddLaneTeamId), Name = "TourneyMatchesOdd")]
    [Index(nameof(TourneyId), Name = "TourneyMatchesTourneyID")]
    [Index(nameof(EvenLaneTeamId), Name = "Tourney_MatchesEven")]
    public partial class TourneyMatch
    {
        public TourneyMatch()
        {
            MatchGames = new HashSet<MatchGame>();
        }

        [Key]
        [Column("MatchID", TypeName = "int")]
        public long MatchId { get; set; }

        [Column("TourneyID", TypeName = "int")]
        public long? TourneyId { get; set; }

        [Column(TypeName = "nvarchar (5)")]
        public string Lanes { get; set; }

        [Column("OddLaneTeamID", TypeName = "int")]
        public long? OddLaneTeamId { get; set; }

        [Column("EvenLaneTeamID", TypeName = "int")]
        public long? EvenLaneTeamId { get; set; }

        [ForeignKey(nameof(EvenLaneTeamId))]
        [InverseProperty(nameof(Team.TourneyMatchEvenLaneTeams))]
        public virtual Team EvenLaneTeam { get; set; }

        [ForeignKey(nameof(OddLaneTeamId))]
        [InverseProperty(nameof(Team.TourneyMatchOddLaneTeams))]
        public virtual Team OddLaneTeam { get; set; }

        [ForeignKey(nameof(TourneyId))]
        [InverseProperty(nameof(Tournament.TourneyMatches))]
        public virtual Tournament Tourney { get; set; }

        [InverseProperty(nameof(MatchGame.Match))]
        public virtual ICollection<MatchGame> MatchGames { get; set; }
    }
}
