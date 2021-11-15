namespace PG332_SoftwareDesign_EksamenH21.Model
{
    public class StudentLecture
    {
        public long Id { get; set; }
        public long LectureId { get; set; }
        public long StudentId { get; set; }
        public bool LectureSeen { get; set; }
        
    }
}