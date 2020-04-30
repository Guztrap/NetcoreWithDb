using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using connectoToPostgres.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace connectoToPostgres.DataAccess
{
    public class StudentDbContext : DbContext, IStudentDbContext
    {
        public StudentDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Student> Students {get; set;}

        public async Task<int> Save()
        {
            await this.SaveChangesAsync();
            return 0;
        }
    }
}
