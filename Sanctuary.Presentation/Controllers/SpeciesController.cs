using System.Net;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sanctuary.Domain;
using Sanctuary.Presentation.Models;
using Sanctuary.Domain.Entities;

namespace Sanctuary.Presentation.Controllers
{
    public class SpeciesController : BaseController
    {
        public SpeciesController(BaseContext context) : base(context) { }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public JsonResult Data()
        {
            var data = new List<SpeciesViewModel>();
            foreach (var item in _context.Species.ToList())
            {
                data.Add(new SpeciesViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                });
            }

            Response.StatusCode = (int)HttpStatusCode.OK;
            return Json(data);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public JsonResult Add([FromBody] SpeciesViewModel model)
        {
            if (!ModelState.IsValid) 
                return Error(HttpStatusCode.BadRequest, "Campos preenchidos incorretamente");

            _context.Species.Add(new Species
            {
                Name = model.Name
            });
            _context.SaveChanges();

            return Success(null);
        }
    }
}
