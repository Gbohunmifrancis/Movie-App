using Microsoft.AspNetCore.Identity;

namespace Movie_App.Models.Domain;

public class ApplicationUser : IdentityUser
{
    public string? Name { get; set; }
    
    public string? Movie { get; set; }
}