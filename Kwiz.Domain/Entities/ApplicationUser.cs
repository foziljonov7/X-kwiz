using Microsoft.AspNetCore.Identity;

namespace Kwiz.Domain.Entities;
public class ApplicationUser : IdentityUser
{
    public string? User { get; set; }
}
