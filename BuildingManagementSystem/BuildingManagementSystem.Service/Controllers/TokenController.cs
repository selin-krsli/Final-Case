using BuildingManagementSystem.Base;
using BuildingManagementSystem.Business;
using BuildingManagementSystem.Schema;
using Microsoft.AspNetCore.Mvc;

namespace BuildingManagementSystem.Service;

[ApiController]
[Route("mngmt/systm/[controller]")]
public class TokenController:ControllerBase
{
    private readonly ITokenService _service;
    public TokenController(ITokenService service)
    {
        _service = service;
    }

    [HttpPost("Login")]
    public ResponseMessage<TokenResponse> Post([FromBody] TokenRequest request)
    {
        var response = _service.Login(request);
        return response;
    }
}
