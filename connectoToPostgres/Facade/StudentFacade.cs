using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using connectoToPostgres.DAO;
using connectoToPostgres.Entities;

namespace connectoToPostgres.Facade
{
    public class StudentFacade : IStudentFacade
    {
        private readonly IStudentDao studentDao;

        public StudentFacade(IStudentDao student)
        {
            studentDao = student ?? throw new ArgumentException(nameof(student));
        }

        public async Task<Student> GetStudentById(int id)
        {
            return await studentDao.GetStudentById(id);
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await studentDao.GetStudents();
        }

        public async Task<Student> SaveStudent(Student student)
        {
            return await studentDao.SaveStudent(student);
        }
    }
}
