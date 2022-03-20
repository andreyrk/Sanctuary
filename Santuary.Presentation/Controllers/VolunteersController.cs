using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sanctuary.Domain;
using Sanctuary.Presentation.Models;
using System.Net;

namespace Sanctuary.Presentation.Controllers
{
    public class VolunteersController : BaseController
    {
        public VolunteersController(BaseContext context) : base(context) { }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public JsonResult Data()
        {
            var data = new List<VolunteersViewModel>();
            foreach (var item in _context.Volunteers.ToList())
            {
                data.Add(new VolunteersViewModel
                {
                    Name = item.Name,
                    Email = item.Email,
                    Phone = item.Phone,
                    Birthdate = item.Birthdate,
                });
            }

            Response.StatusCode = (int)HttpStatusCode.OK;
            return Json(data);
        }
    }
}
