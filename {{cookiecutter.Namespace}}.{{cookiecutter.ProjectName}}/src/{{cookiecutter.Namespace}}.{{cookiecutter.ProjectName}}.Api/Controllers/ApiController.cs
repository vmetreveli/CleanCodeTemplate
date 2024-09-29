using Cai.Send.Api.Routes;
using Framework.Abstractions.Dispatchers;
using Microsoft.AspNetCore.Mvc;

namespace Cai.Send.Api.Controllers;

[ApiController]
[Route(ApiRoutes.BaseRoute)]
public class ApiController : ControllerBase
{
    protected ApiController(IDispatcher dispatcher)
    {
        Dispatcher = dispatcher;
    }

    protected IDispatcher Dispatcher { get; }
}