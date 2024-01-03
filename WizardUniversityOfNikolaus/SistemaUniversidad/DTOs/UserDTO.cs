namespace UniSmart.API.DTOs
{
    public abstract class UserDTO
    {
        public int? Id { get; set; }
        private string name;
        private int age;

        public UserDTO() { }//TODO User con constructor vacío? El name va poder ser vacío?
        public UserDTO(string name, int age, int? id = null)
        {
            this.name = name;
            this.Id = id;
            this.age = age;
        }

        public string GetName()
        {
            return name;
        }

        public int? GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            this.Id = id;
        }

        public int GetAge()
        {
            return age;
        }
    }
}
