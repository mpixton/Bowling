using Bowling.DAL;
using Bowling.Infrastructure;
using Bowling.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Bowling.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IUnitOfWork _unitOfWork;

        private int _pageSize = 5;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index(string team = null, int pageNum = 1)
        {
            _logger.LogInformation("{} on {} with params: {} {}, {} {}", Request.Method, Request.Path, nameof(pageNum), pageNum, nameof(team), team);
            // Filter all bowlers on Team if selected.
            var result = from b in _unitOfWork.BowlerRepo.GetAll(b => b.Team)
                         where team == null || b.Team.TeamName == team
                         orderby b.BowlerLastName
                         select b;
            // Instantiate a new Paginator.
            var viewModel = new Paginator<Bowler>(_pageSize, pageNum, team, result);

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
