using BackendBusinessObject;

using Microsoft.EntityFrameworkCore;

namespace BackendDatabaseAccess;

public class Context : DbContext
{


    public Context(DbContextOptions<Context> options) : base(options)
    {

    }

    public DbSet<Products> ProductData { get; set; }
}