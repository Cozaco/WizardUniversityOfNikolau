namespace UniSmart.API.DTOs.Responses
{
    public class CourseDTO
    {
        public int? Id { get; init; }
        public string Name { get; init; }
        public int Comission { get; init; }

        public CourseDTO(string name, int comission, int? id = null)
        {
            this.Name = name;
            this.Id = id;
            this.Comission = comission;
        }

        public CourseDTO() { }
    }
}
