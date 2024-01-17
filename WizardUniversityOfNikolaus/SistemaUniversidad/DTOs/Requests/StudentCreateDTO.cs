namespace UniSmart.API.DTOs.Requests
{
    public class StudentCreateDTO : UserCreateDTO
    {
        public StudentCreateDTO(string name, int age,string user,string password):base(name,age,user,password) {}
    }
}
