namespace INNOMIATE_API.DTOs;

public class UserDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Bio { get; set; }
    public string? Location { get; set; }
    public string? Website { get; set; }
    public string? Github { get; set; }
    public string? Linkedin { get; set; }
    public string? Image { get; set; }
    public string Password { get; set; }
    public List<string>? Skills { get; set; }
    public List<string>? Interests { get; set; }
    public List<int>? Followers { get; set; }
    public List<int>? Following { get; set; }
}
