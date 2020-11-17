using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;
using connectoToPostgres.DataAccess;
using connectoToPostgres.Entities;
using Microsoft.EntityFrameworkCore;
using ZXing;
using Newtonsoft.Json;
using System.IO;
using System.Drawing;
using connectoToPostgres.AbstractClass;

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
            /*var writer = new BarcodeWriter()
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new ZXing.Common.EncodingOptions()
                {
                    Height = 300,
                    Width = 300,
                    Margin = 1,
                },
            };

            var text = JsonConvert.SerializeObject(student);
            var bitmap = writer.Write(text);
            bitmap.Save(@"C:\Users\gramirez\Documents\dojo\qrtest.png", ImageFormat.Png);

            var base64String = string.Empty;

            using (var ms = new MemoryStream())
            {
                using (var bmp = new Bitmap(bitmap))
                {
                    bmp.Save(ms, ImageFormat.Png);
                    base64String = Convert.ToBase64String(ms.GetBuffer());
                }
            }*/

            var pagosBan = new PagosBanorte();
            var pagosInb = new PagosInbursa();

            var totalBan = pagosBan.GetTotal(5, 5);
            var totalInb = pagosInb.GetTotal(10, 10);

            await studentDb.Students.AddAsync(student);

            await studentDb.Save();
            return student;
        }

    }
}
