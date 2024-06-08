using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthDemo.API.Controllers;

[ApiController]
[Authorize]
public class BaseApiController : ControllerBase
{
}
