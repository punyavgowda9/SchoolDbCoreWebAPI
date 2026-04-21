namespace SchoolDbCodeWbAPI.Services
{
    public class StdWithGradeDTO
    {
        public int StudentId { get; internal set; }
        public string StudentName { get; internal set; }
        public object GrdDescription { get; internal set; }
        public string GrdSection { get; internal set; }
    }
}