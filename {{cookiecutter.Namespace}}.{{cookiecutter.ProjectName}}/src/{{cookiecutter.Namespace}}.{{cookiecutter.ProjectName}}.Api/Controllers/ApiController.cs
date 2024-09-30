using Microsoft.AspNetCore.Mvc;

namespace  {{cookiecutter.Namespace}}.{{cookiecutter.ProjectName}}.Api.Controllers;

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