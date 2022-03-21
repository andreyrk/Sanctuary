using System.Net;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sanctuary.Domain;
using Sanctuary.Presentation.Models;

namespace Sanctuary.Presentation.Controllers
{
    public class RacesController : BaseController
    {
        public RacesController(BaseContext context) : base(context) { }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public JsonResult Data()
        {
            var data = new List<RacesViewModel>();
            foreach (var item in _context.Races.ToList())
            {
                data.Add(new RacesViewModel
                {
                    Id = item.Id,
                    SpeciesId = item.SpeciesId,
                    Name = item.Name,
                });
            }

            Response.StatusCode = (int)HttpStatusCode.OK;
            return Json(data);
        }
    }
}
