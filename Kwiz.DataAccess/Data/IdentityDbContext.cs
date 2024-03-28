using Kwiz.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Kwiz.DataAccess.Data;

public class IdentityDbContext(DbContextOptions options)
    : IdentityDbContext<ApplicationUser>(options)
{

}
