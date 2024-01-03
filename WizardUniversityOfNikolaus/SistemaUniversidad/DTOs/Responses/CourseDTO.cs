namespace UniSmart.API.DTOs.Responses
{
    public class CourseDTO
    {
        private int? id;
        private string name;
        private int comission;

        public CourseDTO(string name, int comission, int? id = null)
        {
            this.name = name;
            this.id = id;
            this.comission = comission;
        }

        public CourseDTO() { }
    }
}
