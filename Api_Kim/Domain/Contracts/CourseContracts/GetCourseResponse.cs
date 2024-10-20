namespace Domain.Contracts.CourseContracts
{
    public class GetCourseResponse
    {
        public int IdCourse { get; set; }
        public string NameCourse { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public DateTime DateCreated { get; set; }
        public int IdCategory { get; set; }
    }
}
