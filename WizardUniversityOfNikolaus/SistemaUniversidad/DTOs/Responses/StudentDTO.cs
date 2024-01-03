namespace UniSmart.API.DTOs.Responses
{
    public class StudentDTO : UserDTO
    {
        public StudentDTO(string name, int age = 0, int? id = null) : base(name, age, id) { }

        public StudentDTO() { }
    }
}

