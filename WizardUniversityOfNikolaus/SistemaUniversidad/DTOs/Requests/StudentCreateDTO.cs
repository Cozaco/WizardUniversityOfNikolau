namespace UniSmart.API.DTOs.Requests
{
    public class StudentCreateDTO : UserCreateDTO
    {
        public StudentCreateDTO(string name, int age):base(name,age) {}
    }
}
