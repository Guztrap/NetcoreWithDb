using connectoToPostgres.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace connectoToPostgres.DataAccess
{
    public interface IStudentDbContext
    {
        DbSet<Student> Students { get; set; }

        Task<int> Save();
    }
}
