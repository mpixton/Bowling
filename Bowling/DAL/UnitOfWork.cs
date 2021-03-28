using Bowling.Models;

namespace Bowling.DAL
{
    /// <summary>
    /// Unit Of Work class. Implements the IUnitOfWork members.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// DbContext to be shared by all Repos in this Unit Of Work. Prevents concurrency issues.
        /// </summary>
        private BowlingDbContext _context;

        /// <summary>
        /// Generic Repo for interacting with all Bowlers.
        /// </summary>
        private GenericRepo<Bowler> _bowlerRepo;

        private GenericRepo<BowlerScore> _bowlerScoreRepo;

        private GenericRepo<MatchGame> _matchGameRepo;

        private GenericRepo<Team> _teamRepo;

        private GenericRepo<Tournament> _tournamentRepo;

        private GenericRepo<TourneyMatch> _tourneyMatchRepo;

        public UnitOfWork(BowlingDbContext context)
        {
            _context = context;
        }


        // If the generic repo doesn't exists, create a new one with the DbContext provided by dependency 
        // injection. If already exists, return the current one. Ensures that all Repos are sharing
        // the same DbContext so that changes to mulitple Repos are saved at the same time.
        public GenericRepo<Bowler> BowlerRepo { get {  return _bowlerRepo ??= new GenericRepo<Bowler>(_context); } }

        public GenericRepo<BowlerScore> BowlerScoreRepo { get { return _bowlerScoreRepo ??= new GenericRepo<BowlerScore>(_context); } }

        public GenericRepo<MatchGame> MatchGameRepo { get { return _matchGameRepo ??= new GenericRepo<MatchGame>(_context); } }

        public GenericRepo<Team> TeamRepo { get { return _teamRepo ??= new GenericRepo<Team>(_context); } }

        public GenericRepo<Tournament> TournamentRepo { get { return _tournamentRepo ??= new GenericRepo<Tournament>(_context); } }

        public GenericRepo<TourneyMatch> TourneyMatchRepo { get { return _tourneyMatchRepo ??= new GenericRepo<TourneyMatch>(_context); } }


        /// <summary>
        /// Saves the chagnes across all Repos in one go.
        /// </summary>
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
