using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MinesweeperMVC.Models;

namespace MinesweeperMVC.Controllers
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string PasswordEncrypted { get; set; }
    }
    public interface IDatabase
    {
        List<User> Users { get; set; }
    }

    public class MS_Context : IDatabase
    {
        public List<User> Users { get; set; }
    }
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public static MinesweeperModel _mm;
        private IDatabase db = new MS_Context();
        public HomeController(ILogger<HomeController> logger, IDatabase db) // dependency injection
        {
            _logger = logger;
            _mm = new MinesweeperModel(10, 5, 8); // store as a session variable
            // session variables stored locally in RAM
            // 5 servers load balanced 
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Game()
        {
            return View(model: _mm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Move(int row, int col)
        {
            _mm.Board[row, col]++;
            return View("Game",_mm);
        }
    }
}
