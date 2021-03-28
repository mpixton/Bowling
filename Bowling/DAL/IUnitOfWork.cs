using Bowling.Models;

namespace Bowling.DAL
{
    /// <summary>
    /// Defines the members for the Unit Of Work class. 
    /// </summary>
    public interface IUnitOfWork
    {
        // All Generic Repos for the project.
        /// <summary>
        /// Generic Repo for Bowlers.
        /// </summary>
        GenericRepo<Bowler> BowlerRepo { get; }

        GenericRepo<BowlerScore> BowlerScoreRepo { get; }

        GenericRepo<MatchGame> MatchGameRepo { get; }

        GenericRepo<Team> TeamRepo { get; }

        GenericRepo<Tournament> TournamentRepo { get; }

        GenericRepo<TourneyMatch> TourneyMatchRepo { get; }

        /// <summary>
        /// Saves the changes made to the Repos in this Unit Of Work to the Db.
        /// </summary>
        void Save();
    }
}