using CQRSAndMediatRDemo.Commands;
using CQRSAndMediatRDemo.Dto;
using CQRSAndMediatRDemo.Models;
using CQRSAndMediatRDemo.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRSAndMediatRDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("listOfStudent")]
        public async Task<List<StudentDetail>> GetStudentList()
        {
            var studentDetail = await _mediator.Send(new GetStudentListQuery());
            return studentDetail;
        }

        [HttpGet("get-studentbyid")]
        public async Task<StudentDetail> GetStudentById (string id)
        {
            var studentDetail = await _mediator.Send(new GetStudentByIdQuery() { Id = id});
            return studentDetail;
        }

        [HttpPost("add-student")]
        public async Task<StudentDetail> AddStudentAsync (AddStudentDto studentDetail)
        {
            var studentDetails = await _mediator.Send(new CreateStudentCommand(

                studentDetail.FirstName,
                studentDetail.LastName,
                studentDetail.Email,
                studentDetail.Address,
                studentDetail.Age
                ));
            return studentDetails;
        }

        [HttpPut("update-student")]
        public async Task<StudentDetail> UpdateStudentAsync  (StudentDetail studentDetail)
        {
            var isStudentDetailsUpdated = await _mediator.Send(new UpdateStudentCommand(

                studentDetail.Id,
                studentDetail.FirstName,
                studentDetail.LastName,
                studentDetail.Email,
                studentDetail.Address,
                studentDetail.Age
                ));
            return isStudentDetailsUpdated;
        }

        [HttpDelete("delete-studentbyid")]
        public async Task<string> DeleteStudentAsync (string studentId)
        {
            var studentDetail = await _mediator.Send(new DeleteStudentCommand() { Id = studentId });
            return studentDetail;
        }
    }
}
