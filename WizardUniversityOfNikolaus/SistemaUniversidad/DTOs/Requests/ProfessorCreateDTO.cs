namespace UniSmart.API.DTOs.Requests
{
    public class ProfessorCreateDTO : UserCreateDTO
    {
        public ProfessorCreateDTO(string name, int age,string user,string password):base(name,age,user,password) { }
    }
}
