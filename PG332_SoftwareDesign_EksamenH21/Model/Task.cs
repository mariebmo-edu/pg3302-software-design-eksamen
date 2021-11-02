namespace PG332_SoftwareDesign_EksamenH21
{
    public class Task
    {
        private Lecture _lecture;
        private IProgression _progression;

        public Task(Lecture lecture, IProgression progression)
        {
            _lecture = lecture;
            _progression = progression;
        }
        
    }
}