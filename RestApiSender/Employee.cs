using Newtonsoft.Json;

namespace RestApiSender
{
    public class Employee
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Salary { get; set; }
        [JsonIgnore]
        public string Image { get; set; }
     

    }
}
