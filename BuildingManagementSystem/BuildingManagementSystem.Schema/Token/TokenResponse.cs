
namespace BuildingManagementSystem.Schema;

public class TokenResponse
{
    public DateTime ExpiryTime { get; set; }
    public string AccessToken { get; set; }
    public string UserName { get; set; }
}
