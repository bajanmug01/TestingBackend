using Ardalis.Result.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TestingBackend.Api.Controllers
{
    [TranslateResultToActionResult]
    //[Authorize(Roles = "App.Read")]
    public abstract class BaseServiceController<TService> : ControllerBase
    {
        protected readonly TService _service;

        protected BaseServiceController(TService service)
        {
            _service = service;
        }
    }
}
