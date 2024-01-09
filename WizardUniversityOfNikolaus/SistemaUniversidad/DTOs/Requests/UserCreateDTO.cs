namespace UniSmart.API.DTOs.Requests
{
    public abstract class UserCreateDTO
    {
        public string Name { get; init; }
        public int Age { get; init; }

        public UserCreateDTO() { }//TODO User con constructor vacío? El name va poder ser vacío?
        public UserCreateDTO(string name, int age, int? id = null)
        {
            Name = name;
            Age = age;
        }
    }
}
