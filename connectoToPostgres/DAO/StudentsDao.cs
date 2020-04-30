using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using connectoToPostgres.DataAccess;
using connectoToPostgres.Entities;
using Microsoft.EntityFrameworkCore;

namespace connectoToPostgres.DAO
{
    public class StudentsDao : IStudentDao
    {
        private readonly IStudentDbContext studentDb;

        public StudentsDao(IStudentDbContext dbContext)
        {
            studentDb = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Student> GetStudentById(int id)
        {
            return await studentDb.Students.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {            
            return await studentDb.Students.ToListAsync();
        }

        public async Task<Student> SaveStudent(Student student)
        {
            await studentDb.Students.AddAsync(student);
            await studentDb.Save();
            return student;
        }

    }
}
