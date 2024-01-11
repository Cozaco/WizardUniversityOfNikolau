namespace UniSmart.API.DTOs.Responses
{
    public class StudentDTO : UserDTO
    {
        public StudentDTO(string name, int age, int id) : base(name, age, id) { }

        public StudentDTO() { }
    }
}

