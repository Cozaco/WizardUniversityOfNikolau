using Contracts.Models;

namespace UniSmart.API.DTOs.Responses
{
    public class ProfessorDTO : UserDTO
    {
        public ProfessorDTO(string name, int age = 0, int? id = null) : base(name, age, id) { }

        public ProfessorDTO() { }

        public ProfessorDTO(Professor professor) //TODO hicimos esta ilegalidad, ya que la idea del DTO es separar lo que ocurre en la API con la estructura.
                                                 //TODO como resolvemos el problema de Listas? ya que terminabamos convirtiendo una lista de professors en una lista de professorDto
        {
            Id = professor.Id;
            Name = professor.Name;
            Age = professor.Age;
        }
    }
}
