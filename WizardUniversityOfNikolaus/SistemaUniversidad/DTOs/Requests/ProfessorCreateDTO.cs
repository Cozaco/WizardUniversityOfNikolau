namespace UniSmart.API.DTOs.Requests
{
    public class ProfessorCreateDTO : UserCreateDTO
    {
        public ProfessorCreateDTO(string name, int age):base(name,age) { }
    }
}
