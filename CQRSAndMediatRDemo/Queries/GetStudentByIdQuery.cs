using CQRSAndMediatRDemo.Models;
using MediatR;

namespace CQRSAndMediatRDemo.Queries
{
    public class GetStudentByIdQuery : IRequest<StudentDetail>
    {
        public string Id { get; set; }
    }
}
