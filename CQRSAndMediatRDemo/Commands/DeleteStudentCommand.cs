using MediatR;

namespace CQRSAndMediatRDemo.Commands
{
    public class DeleteStudentCommand : IRequest<string>
    {
        public string Id { get; set; }
    }
}
