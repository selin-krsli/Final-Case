
using BuildingManagementSystem.Base;
using BuildingManagementSystem.Schema;

namespace BuildingManagementSystem.Business;

public interface ITokenService
{
    ResponseMessage<TokenResponse> Login(TokenRequest request);
}
