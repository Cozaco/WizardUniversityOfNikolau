using UniSmart.Contracts.Models;

namespace UniSmart.API.DTOs.Responses
{
    public class ProfessorDTO : UserDTO
    {
        public ProfessorDTO(string name, int age, int id) : base(name, age, id) { }

        public ProfessorDTO() { }
    }
}
