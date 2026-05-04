using Microsoft.AspNetCore.Mvc;
using Meadow_Framework.Core.Abstractions.Dispatchers;
using {{cookiecutter.Namespace}}.{{cookiecutter.ProjectName}}.Api.Routes;

namespace {{cookiecutter.Namespace}}.{{cookiecutter.ProjectName}}.Api.Controllers;

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