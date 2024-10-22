using CQRSAndMediatRDemo.Models;

namespace CQRSAndMediatRDemo.Repositories
{
    public interface IStudentRepository
    {
        public Task<List<StudentDetail>> GetStudentListAsync();
        public Task<StudentDetail> GetStudentByIdAsync(string id);
        public Task<StudentDetail> AddStudentAsync(StudentDetail studentDetail);
        public Task<StudentDetail> UpdateStudentAsync(StudentDetail studentDetail);
        public Task<StudentDetail> DeleteStudentAsync(string id);
    }
}
