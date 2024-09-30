namespace Domain.Contracts.CourseContracts
{
    public class CreateCourseRequest
    {
        public string NameCourse { get; set; }
        public string Description { get; set; }
        public int IdCategory { get; set; }
    }
}
