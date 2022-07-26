using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BookEcommerceAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BookEcommerceAPI
{
    [Route("[controller]")]
    public class Startup : Controller
    {
        private readonly ILogger<Startup> _logger;

        public Startup(ILogger<Startup> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public void ConfigureServices(IServiceCollection services){
            services.AddControllers();

            services.AddDbContext<ToDoContext>{opt => opt.UseInMemoryDatabase(databaseName:"ToDoProducts")};
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}