using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Repositories.Models;
using Controller = Microsoft.AspNetCore.Mvc.Controller;
using JsonResult = Microsoft.AspNetCore.Mvc.JsonResult;

namespace UserApp.Controllers
{
    public class PersonsController : Controller
    {
        private readonly PersonsContext _context;

        public PersonsController(PersonsContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Persons> personsList = _context.Persons;
            return View(personsList);
        }

        public JsonResult GetAll()
        {
            List<Persons> list = new PersonsDA(_context).GetAll();
            return Json(list);
        }

        public JsonResult Save(Persons person)
        {
            string user = new PersonsDA(_context).Save(person);
            return Json(user);
        }
    }
}
