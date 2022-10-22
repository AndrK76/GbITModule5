using Microsoft.EntityFrameworkCore;
using HRM.API.Models;

namespace HRM.API.Db
{
    public class HRMContext : DbContext
    {
        public HRMContext(DbContextOptions<HRMContext> options) : base(options)
        {

        }
        public DbSet<Employee>? Employees { get; set; }
    }
}
