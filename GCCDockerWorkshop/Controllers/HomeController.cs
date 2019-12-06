using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GCCDockerWorkshop.Models;
using Microsoft.EntityFrameworkCore;


namespace GCCDockerWorkshop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GCCDockerWorkshopDB _context;

        public HomeController(ILogger<HomeController> logger, GCCDockerWorkshopDB context)
        {
            _context= context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var orders = _context.Orders;
            return View(await orders.ToListAsync());
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

        public IActionResult Create([Bind("OrderNumber,OrderTotal,OrderDate")] Order order)
        {
            return View(order);

            //if (ModelState.IsValid)
            //{
            //    _context.Add(order);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(order);
        }
    }
}
