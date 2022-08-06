using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PartyInvites.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CodeFixes;
using PartyInvites.Repository;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {

        public int ChooseSortBy { get; set; }
        public AppDbContext _context = new AppDbContext();
        public IActionResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
            return View("MyView");
        }

        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                Models.Repository.AddResponse(guestResponse);
                
                return View("Thanks", guestResponse);
            }
            else
            {
                return View();
            }
        }
        
        public ViewResult ListResponses()
        {
            return View(_context.guestResponses.Where(x => x.WillAttend == true));
        }

        public ViewResult ListNonResponses()
        {
            return View(_context.guestResponses.Where(x => x.WillAttend == false));
        }
        
    }
}
