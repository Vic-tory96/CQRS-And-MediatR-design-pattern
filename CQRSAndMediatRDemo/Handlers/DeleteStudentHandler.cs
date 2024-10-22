using CQRSAndMediatRDemo.Commands;
using CQRSAndMediatRDemo.Repositories;
using MediatR;

namespace CQRSAndMediatRDemo.Handlers
{
    public class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand, string>
    {
        private readonly IStudentRepository _studentRepository;
        public DeleteStudentHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<string> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var studentDetail = await _studentRepository.GetStudentByIdAsync(request.Id);
            if (studentDetail == null)
            {
                throw new ArgumentException("Student not found");
            }
            var result = await _studentRepository.DeleteStudentAsync(studentDetail.Id);

            return result != null ? "Student successfully deleted" : "Failed to delete student";
        }
    }
}
