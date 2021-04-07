using System.Linq;
using System.Net;
using CoreProject.Core.Interfaces.Validations;
using Microsoft.AspNetCore.Mvc;

namespace FLentProject.Api.Controlllers
{
    public abstract class ApiController : ControllerBase
    {
        private readonly IValidationNotification _validationNotification;

        protected ApiController(IValidationNotification validationNotification)
        {
            _validationNotification = validationNotification;
        }

        protected IActionResult CreateResponse(HttpStatusCode code, object result)
        {
            switch (code)
            {
                case HttpStatusCode.OK when result == null:
                    return Ok(new
                    {
                        success = true,
                        data = "Nenhum resultado gerado no request."
                    });
                case HttpStatusCode.OK when _validationNotification.Notifications != null && _validationNotification.Notifications.Any():
                    return Ok(new
                    {
                        success = false,
                        data = _validationNotification.Notifications
                    });
                case HttpStatusCode.OK:
                    return Ok(new
                    {
                        success = true,
                        data = result
                    });
                case HttpStatusCode.BadRequest:
                    return BadRequest(result);
                default:
                    return BadRequest(result);
            }
        }
    }
}
