using DEVPratica.Dapper.Generic.Domain.Configuration.Events;
using DEVPratica.Dapper.Generic.Domain.Domain;
using Microsoft.AspNetCore.Mvc;

namespace DEVPratica.Dapper.Generic.Api.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    //[Authorize]
    public class MainController : ControllerBase
    {
        protected ActionResult CustomResponse(IEvent result = null)
        {
            RetornoPadraoDto ret = new();

            if (result.Success)
            {
                ret.HasError = false;
                ret.Data = result.Data;
                ret.Notifications = result.Warning;
            }
            else
            {
                ret.HasError = true;
                ret.Notifications = result.Data;
            }

            return Ok(ret);
        }

        protected ActionResult CustomResponse(object result = null)
        {
            RetornoPadraoDto ret = new();

            ret.HasError = false;
            ret.Data = result;

            return Ok(ret);
        }
    }
}
