using PG332_SoftwareDesign_EksamenH21.Model;

namespace PG332_SoftwareDesign_EksamenH21.Handlers.Printable
{
    public static class OptionsHandlerFactory
    {
        public static OptionsWrapper MakeOptionsHandler(IProgressable progressable, OptionsWrapper superOption = null)
        {
            switch (progressable)
            {
                case User user:
                {
                    OptionsWrapper oh = new(user, null, false);
                    foreach (var s in user.Semesters)
                    {
                        oh.Options.Add(s);
                    }
                    return oh;
                }
                case Semester semester:
                {
                    OptionsWrapper oh = new(semester, superOption, false);
                    foreach (var c in semester.Courses)
                    {
                        oh.Options.Add(c);
                    }
                    return oh;
                }
                case Course course:
                {
                    OptionsWrapper oh = new(course, superOption, true);
                    foreach (var l in course.Lectures)
                    {
                        oh.Options.Add(l);
                    }
                    return oh;
                }
                case Lecture lecture:
                {
                    OptionsWrapper oh = new(lecture, superOption, true);
                    foreach (var t in lecture.TaskSet.Tasks)
                    {
                        oh.Options.Add(t);
                    }
                    return oh;
                }
                case TaskSet taskSet:
                {
                    OptionsWrapper oh = new(taskSet, superOption, false);
                    foreach (var t in taskSet.Tasks)
                    {
                        oh.Options.Add(t);
                    }

                    return oh;
                }
            }

            var task = progressable as Task;
            OptionsWrapper optionsWrapper = new(task, superOption, true);
            return optionsWrapper;
        }
    }
}
