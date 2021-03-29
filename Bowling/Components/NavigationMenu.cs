using Bowling.DAL;
using Bowling.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bowling.Components
{
    /// <summary>
    /// Provides filtering via buttons.
    /// </summary>
    public class NavigationMenu : ViewComponent
    {
        private IUnitOfWork _unitOfWork;

        public NavigationMenu(IUnitOfWork unitOfWOrk)
        {
            _unitOfWork = unitOfWOrk;
        }

        /// <summary>
        /// Renders the ViewComponent HTML.
        /// </summary>
        /// <returns>HTML.</returns>
        public IViewComponentResult Invoke()
        {
            // Populates the HTML with all teams associated with a Bowler.
            return View(
                _unitOfWork.BowlerRepo.GetAll(b => b.Team)
                .Select(b => b.Team.TeamName)
                .Distinct()
                .OrderBy(t => t)
                );
            ;
        }
    }
}
