using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Bowling.Models;

#nullable disable

namespace Bowling.DAL
{
    /// <summary>
    /// DbContext provided by scaffolding.
    /// </summary>
    public partial class BowlingDbContext : DbContext
    {
        public BowlingDbContext()
        {
        }

        public BowlingDbContext(DbContextOptions<BowlingDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bowler> Bowlers { get; set; }

        public virtual DbSet<BowlerScore> BowlerScores { get; set; }

        public virtual DbSet<MatchGame> MatchGames { get; set; }

        public virtual DbSet<Team> Teams { get; set; }

        public virtual DbSet<Tournament> Tournaments { get; set; }

        public virtual DbSet<TourneyMatch> TourneyMatches { get; set; }

        public virtual DbSet<ZtblBowlerRating> ZtblBowlerRatings { get; set; }

        public virtual DbSet<ZtblSkipLabel> ZtblSkipLabels { get; set; }

        public virtual DbSet<ZtblWeek> ZtblWeeks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bowler>(entity =>
            {
                entity.Property(e => e.BowlerId).ValueGeneratedNever();
            });

            modelBuilder.Entity<BowlerScore>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.GameNumber, e.BowlerId });

                entity.Property(e => e.HandiCapScore).HasDefaultValueSql("0");

                entity.Property(e => e.RawScore).HasDefaultValueSql("0");

                entity.Property(e => e.WonGame).HasDefaultValueSql("0");

                entity.HasOne(d => d.Bowler)
                    .WithMany(p => p.BowlerScores)
                    .HasForeignKey(d => d.BowlerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<MatchGame>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.GameNumber });

                entity.Property(e => e.WinningTeamId).HasDefaultValueSql("0");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.MatchGames)
                    .HasForeignKey(d => d.MatchId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.Property(e => e.TeamId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Tournament>(entity =>
            {
                entity.Property(e => e.TourneyId).ValueGeneratedNever();
            });

            modelBuilder.Entity<TourneyMatch>(entity =>
            {
                entity.Property(e => e.MatchId).ValueGeneratedNever();

                entity.Property(e => e.EvenLaneTeamId).HasDefaultValueSql("0");

                entity.Property(e => e.OddLaneTeamId).HasDefaultValueSql("0");

                entity.Property(e => e.TourneyId).HasDefaultValueSql("0");
            });

            modelBuilder.Entity<ZtblSkipLabel>(entity =>
            {
                entity.Property(e => e.LabelCount).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
