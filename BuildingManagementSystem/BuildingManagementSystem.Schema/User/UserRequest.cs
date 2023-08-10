
namespace BuildingManagementSystem.Schema;

public class UserRequest
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Status { get; set; } = 1;
    public string Role { get; set; }
}
