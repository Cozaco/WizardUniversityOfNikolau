using System.ComponentModel.DataAnnotations;

namespace UniSmart.API.DTOs.Requests
{
    public abstract class UserCreateDTO
    {

        //[EmailAddress(ErrorMessage = "Esto debería ser un mail")]
        public string Name { get; init; }
        public int Age { get; init; }

        public UserCreateDTO() { }
        public UserCreateDTO(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}
