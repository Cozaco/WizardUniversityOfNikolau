namespace UniSmart.API.DTOs.Requests
{
    public class CourseCreateDTO
    {
        public string Name { get; init; }
        public int Comission { get; init; }

        public CourseCreateDTO(string name, int comission)
        {
            Name = name;
            Comission = comission;
        }
    }
}
