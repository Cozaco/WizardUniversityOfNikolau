using Contracts.Models;

namespace UniSmart.API.DTOs.Responses
{
    public class ProfessorDTO : UserDTO
    {
        public ProfessorDTO(string name, int age = 0, int id) : base(name, age, id) { }

        public ProfessorDTO() { }
    }
}
