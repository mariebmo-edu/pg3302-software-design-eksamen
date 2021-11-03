namespace PG332_SoftwareDesign_EksamenH21.Model
{
    public class UserCoursePlan
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long CourseId { get; set; }
        public SemesterEnum? SemesterEnum { get; set; }
    }

    public enum SemesterEnum
    {
        FIRST,
        SECOND,
        THIRD,
        FOURTH,
        FIFTH,
        SIXTH
    }
}