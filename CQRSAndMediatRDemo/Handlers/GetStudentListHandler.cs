using CQRSAndMediatRDemo.Models;
using CQRSAndMediatRDemo.Queries;
using CQRSAndMediatRDemo.Repositories;
using MediatR;

namespace CQRSAndMediatRDemo.Handlers
{
    public class GetStudentListHandler : IRequestHandler<GetStudentListQuery, List<StudentDetail>>
    {
        private readonly IStudentRepository _studentRepository;
        public GetStudentListHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<List<StudentDetail>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
           return await _studentRepository.GetStudentListAsync();
        }
    }
}
