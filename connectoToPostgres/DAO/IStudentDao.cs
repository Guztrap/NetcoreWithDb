using connectoToPostgres.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace connectoToPostgres.DAO
{
    public interface IStudentDao
    {
        Task<Student> GetStudentById(int id);

        Task<IEnumerable<Student>> GetStudents();

        Task<Student> SaveStudent(Student student);
    }
}
