using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Papasi.Entities;

public class ApplicationUser : IdentityUser
{
    public string? Name { get; set; }
}