using GenericRepository.GenericRepository.Context;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GenericRepository.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return Json(_context.Users.ToList());
        }
    }
}
