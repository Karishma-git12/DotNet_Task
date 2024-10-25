namespace Developer_Task.Models
{
    public class StudentClass
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public ICollection<Student> Students { get; set; }
    }
}
