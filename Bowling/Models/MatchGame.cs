using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Bowling.Models
{
    [Table("Match_Games")]
    [Index(nameof(WinningTeamId), Name = "Team1ID")]
    [Index(nameof(MatchId), Name = "TourneyMatchesMatchGames")]
    public partial class MatchGame
    {
        [Key]
        [Column("MatchID", TypeName = "int")]
        public long MatchId { get; set; }

        [Key]
        [Column(TypeName = "smallint")]
        public long GameNumber { get; set; }

        [Column("WinningTeamID", TypeName = "int")]
        public long? WinningTeamId { get; set; }

        [ForeignKey(nameof(MatchId))]
        [InverseProperty(nameof(TourneyMatch.MatchGames))]
        public virtual TourneyMatch Match { get; set; }
    }
}
