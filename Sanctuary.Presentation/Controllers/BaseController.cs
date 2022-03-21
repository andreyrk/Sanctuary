using System.Net;
using Microsoft.AspNetCore.Mvc;
using Sanctuary.Domain;
using Sanctuary.Domain.Entities;

namespace Sanctuary.Presentation.Controllers
{
    public class BaseController : Controller
    {
        protected readonly BaseContext _context;

        public BaseController(BaseContext context)
        {
            _context = context;
        }

        protected virtual JsonResult Error(HttpStatusCode statusCode, object errorData)
        {
            Response.StatusCode = (int)statusCode;
            return Json(new
            {
                success = false,
                message = errorData
            });
        }

        protected virtual JsonResult Success(object successData)
        {
            Response.StatusCode = (int)HttpStatusCode.OK;
            return Json(new
            {
                success = true,
                message = successData
            });
        }

        protected Volunteer UserEntity { get
            {
                if (User.Identity.IsAuthenticated)
                {
                    return _context.Find<Volunteer>(int.Parse(User.Identity.Name));
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
