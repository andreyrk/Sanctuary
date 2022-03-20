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
