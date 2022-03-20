using System.Net;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sanctuary.Domain;
using Sanctuary.Presentation.Models;

namespace Sanctuary.Presentation.Controllers
{
    public class AnimalsController : BaseController
    {
        public AnimalsController(BaseContext context) : base(context) { }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public JsonResult Data()
        {
            var data = new List<AnimalsViewModel>();
            foreach (var item in _context.Animals.ToList())
            {
                data.Add(new AnimalsViewModel
                {
                    Name = item.Name,
                    SpeciesId = item.SpeciesId,
                    Sex = item.Sex,
                    Birthdate = item.Birthdate,
                });
            }

            Response.StatusCode = (int)HttpStatusCode.OK;
            return Json(data);
        }
    }
}
