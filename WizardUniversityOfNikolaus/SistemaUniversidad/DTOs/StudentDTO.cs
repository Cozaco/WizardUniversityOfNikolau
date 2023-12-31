namespace UniSmart.API.DTOs
{
    public class StudentDTO : UserDTO
    {
        public StudentDTO(string name, int age = 0, int? id = null) : base(name, age, id) { }
    }
}

