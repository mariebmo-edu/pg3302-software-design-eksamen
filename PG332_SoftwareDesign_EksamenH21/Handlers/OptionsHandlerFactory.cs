using PG332_SoftwareDesign_EksamenH21.Model;

namespace PG332_SoftwareDesign_EksamenH21.Handlers
{
    public class OptionsHandlerFactory
    {
        public static OptionsWrapper MakeOptionsHandler(IProgressable progressable)
        {
            return MakeOptionsHandler(progressable, null);
        }
        public static OptionsWrapper MakeOptionsHandler(IProgressable progressable, OptionsWrapper superOption)
        {
            if (progressable is User)
            {
                User u = progressable as User;
                OptionsWrapper oh = new(u, null, false);
                foreach (var s in u.Semesters)
                {
                    oh.Options.Add(s);
                }
                return oh;
            }

            if (progressable is Semester)
            {
                Semester s = progressable as Semester;
                OptionsWrapper oh = new(s, superOption, false);
                foreach (var c in s.Courses)
                {
                    oh.Options.Add(c);
                }
                return oh;
            }

            if (progressable is Course)
            {
                Course c = progressable as Course;
                OptionsWrapper oh = new(c, superOption, true);
                foreach (var l in c.Lectures)
                {
                    oh.Options.Add(l);
                }
                return oh;
            }

            if (progressable is Lecture)
            {
                Lecture l = progressable as Lecture;
                OptionsWrapper oh = new(l, superOption, true);
                foreach (var t in l.TaskSet.Tasks)
                {
                    oh.Options.Add(t);
                }
                return oh;
            }

            if (progressable is TaskSet)
            {
                TaskSet ts = progressable as TaskSet;
                OptionsWrapper oh = new(ts, superOption, false);
                foreach (var t in ts.Tasks)
                {
                    oh.Options.Add(t);
                }

                return oh;
            }
            
            Task task = progressable as Task;
            OptionsWrapper optionsWrapper = new(task, superOption, true);
            return optionsWrapper;
        }
    }
}
