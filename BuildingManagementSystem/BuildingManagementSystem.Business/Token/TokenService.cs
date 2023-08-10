
using BuildingManagementSystem.Base;
using BuildingManagementSystem.Data;
using BuildingManagementSystem.Schema;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BuildingManagementSystem.Business;

public class TokenService:ITokenService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserLogService _userLogService;
    private readonly JwtConfig _jwtConfig;
    public TokenService(IUnitOfWork unitOfWork, IUserLogService userLogService, IOptionsMonitor<JwtConfig> jwtConfig)
    {
        _unitOfWork = unitOfWork;
        _userLogService = userLogService;
        _jwtConfig = jwtConfig.CurrentValue;
    }

    public ResponseMessage<TokenResponse> Login(TokenRequest request)
    {
        if(request == null)
        {
            return new ResponseMessage<TokenResponse>("Request was null!!");
        }
        if(string.IsNullOrEmpty(request.UserName) || string.IsNullOrEmpty(request.Password))
        {
            return new ResponseMessage<TokenResponse>("Request was null!!");
        }
        request.UserName = request.UserName.Trim().ToLower();
        request.Password = request.Password.Trim();

        var user = _unitOfWork.UserRepository.Where(s=>s.UserName.Equals(request.UserName)).FirstOrDefault();
        if(user == null)
        {
            Log(request.UserName, LogType.InvalidUserName);
            return new ResponseMessage<TokenResponse>("Inavlid user informations!!");
        }
        if(user.Password.ToLower() != CreateMD5(request.Password))
        {
            user.PasswordRetryCount++;
            user.LastActivity = DateTime.UtcNow;

            if (user.PasswordRetryCount > 3)
                user.Status = 2;

            _unitOfWork.UserRepository.Update(user);
            _unitOfWork.Complete();

            Log(request.UserName, LogType.WrongPassword);
            return new ResponseMessage<TokenResponse>("Invalid user informations!!");
        }
        if(user.Status != 1)
        {
            Log(request.UserName, LogType.InvalidUserName);
            return new ResponseMessage<TokenResponse>("Inavlid user informations!!");
        }
        if(user.PasswordRetryCount > 3)
        {
            Log(request.UserName, LogType.PasswordRetryCountExceed);
            return new ResponseMessage<TokenResponse>("Password retry count exceed!!");
        }
        user.LastActivity = DateTime.UtcNow;
        user.Status = 1;

        _unitOfWork.UserRepository.Update(user);
        _unitOfWork.Complete();

        string token = Token(user);
        Log(request.UserName, LogType.LogedIn);

        TokenResponse response = new()
        {
            AccessToken = token,
            ExpiryTime = DateTime.Now.AddMinutes(_jwtConfig.AccessTokenExpiration),
            UserName = user.UserName
        };
        return new ResponseMessage<TokenResponse>(response);
    }
    private string Token(User user)
    {
        Claim[] claims = GetClaims(user);
        var secret = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

        var jwtToken = new JwtSecurityToken(
            _jwtConfig.Issuer,
            _jwtConfig.Audience,
            claims,
            expires: DateTime.Now.AddMinutes(_jwtConfig.AccessTokenExpiration),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature)
            );

        var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
        return accessToken;
    }
    private Claim[] GetClaims(User user)
    {
        var claims = new[]
        {
            new Claim("UserName", user.UserName),
            new Claim("UserId", user.UserId.ToString()),
            new Claim("Role", user.Role),
            new Claim("Status", user.Status.ToString()),
            new Claim(ClaimTypes.Role, user.Role),
            new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
        };
        return claims;
    }

    private void Log(string username, string logType)
    {
        UserLogRequest request = new UserLogRequest()
        {
            LogType = logType,
            UserName = username,
        };
        _userLogService.Insert(request);
    }
    private string CreateMD5(string input)
    {
        using(System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
        {
            byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            return Convert.ToHexString(hashBytes).ToLower();
        }
    }
}
