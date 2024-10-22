using CQRSAndMediatRDemo.Commands;
using CQRSAndMediatRDemo.Models;
using CQRSAndMediatRDemo.Repositories;
using MediatR;

namespace CQRSAndMediatRDemo.Handlers
{
    public class CreateStudentHandler : IRequestHandler<CreateStudentCommand, StudentDetail>
    {
       private readonly IStudentRepository _studentRepository;
        public CreateStudentHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<StudentDetail> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var studentDetail = new StudentDetail()
            {
               FirstName = request.FirstName,
               LastName = request.LastName,
               Email = request.Email,
               Address = request.Address,
               Age = request.Age,   
            };

            return await _studentRepository.AddStudentAsync(studentDetail);
        }
    }
}
