using Data;
using Microsoft.AspNetCore.Mvc;

namespace soca.Controllers.Base
{
    public class BaseController : ControllerBase
    {
        protected SocaContext db;

        public BaseController(SocaContext context)
        {
            db = context;
        }
    }
}
