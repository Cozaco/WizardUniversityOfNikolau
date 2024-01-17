using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UniSmart.API.DTOs.Requests
{
    public abstract class UserCreateDTO
    {

        [EmailAddress(ErrorMessage = "Esto debería ser un mail")]
        public string UserName { get; set; }
        [PasswordPropertyText]
        public string Password { get; set; }
        public string Name { get; init; }
        public int Age { get; init; }

        public UserCreateDTO() { }
        public UserCreateDTO(string name, int age,string user,string password)
        {
            Name = name;
            Age = age;
            UserName = user;
            Password = password;
        }
    }
}
