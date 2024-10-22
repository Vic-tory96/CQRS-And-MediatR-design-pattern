using CQRSAndMediatRDemo.Data;
using CQRSAndMediatRDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSAndMediatRDemo.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDbContext _studentDbContext;
        public StudentRepository(StudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }
        public async  Task<StudentDetail> AddStudentAsync(StudentDetail studentDetail)
        {
           if(studentDetail == null)
            {
                throw new ArgumentNullException(nameof(studentDetail));
            }
           _studentDbContext.StudentDetails.Add(studentDetail);
           await _studentDbContext.SaveChangesAsync();
           return studentDetail;
        }

        public async Task<StudentDetail> DeleteStudentAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException(nameof(id));
            }
            var getStudent = await _studentDbContext.StudentDetails.Where(x => x.Id == id).FirstOrDefaultAsync();
            _studentDbContext.Remove(getStudent);
             await _studentDbContext.SaveChangesAsync();
            return getStudent;
            
        }

        public async Task<StudentDetail> GetStudentByIdAsync(string id)
        {
            if(string.IsNullOrWhiteSpace(id))
            {
               throw new ArgumentNullException(nameof(id));
            }
            var getStudent = await _studentDbContext.StudentDetails.Where(x => x.Id == id).FirstOrDefaultAsync();
            return getStudent;

        }

        public async Task<List<StudentDetail>> GetStudentListAsync()
        {
            return await _studentDbContext.StudentDetails.ToListAsync();
        }

        public async Task<StudentDetail> UpdateStudentAsync(StudentDetail studentDetail)
        {
            if (studentDetail == null)
            {
                throw new ArgumentNullException(nameof(studentDetail));
            }
            _studentDbContext.StudentDetails.Update(studentDetail);
            await _studentDbContext.SaveChangesAsync();
            return studentDetail;
            
        }
    }
}
