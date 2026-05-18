namespace CourseSelling.Catalog.Api.Features.Courses.DTOs
{
    public class FeatureDTO
    {
        public int Duration { get; set; }
        public float Rating { get; set; }
        public string EducatorFullName { get; set; } = default!;
    }
}
