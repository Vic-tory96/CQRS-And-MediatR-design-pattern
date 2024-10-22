using CQRSAndMediatRDemo.Models;
using MediatR;

namespace CQRSAndMediatRDemo.Commands
{
    public class CreateStudentCommand : IRequest<StudentDetail>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email {  get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public CreateStudentCommand(string firstName, string lastName, string email, string address, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;

            Address = address;
            Age = age;

        }
    }
}
