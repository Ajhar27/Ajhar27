using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration configuration;

        public HomeController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public ViewResult Index()
        {
            var result = configuration["AppName"];
            var Key1 = configuration["Info_Obj:Key1"];
            var Key2 = configuration["Info_Obj:Key2:Key01"];
            
            return View();
        }

        public ViewResult Aboutus()
        {
            return View();
        }

        public ViewResult Contact()
        {
            return View();
        }
    }
}
