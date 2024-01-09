namespace UniSmart.API.DTOs.Responses
{
    public abstract class UserDTO
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public int Age { get; init; }

        public UserDTO() { }//TODO User con constructor vacío? El name va poder ser vacío?
        public UserDTO(string name, int age, int id)
        {
            Name = name;
            Id = id;
            Age = age;
        }
    }
}
