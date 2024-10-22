using CQRSAndMediatRDemo.Commands;
using CQRSAndMediatRDemo.Models;
using CQRSAndMediatRDemo.Repositories;
using MediatR;

namespace CQRSAndMediatRDemo.Handlers
{
    public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, StudentDetail>
    {
        private readonly IStudentRepository _studentRepository;
        public UpdateStudentHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<StudentDetail> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var studentDetail = await _studentRepository.GetStudentByIdAsync(request.Id);
            if (studentDetail == null)
            {
                throw new ArgumentException("Student not found");
            }
            studentDetail.FirstName = request.FirstName;
            studentDetail.LastName = request.LastName;
            studentDetail.Email = request.Email;
            studentDetail.Address = request.Address;
            studentDetail.Age = request.Age;

            return await _studentRepository.UpdateStudentAsync(studentDetail);
        }
    }
}
