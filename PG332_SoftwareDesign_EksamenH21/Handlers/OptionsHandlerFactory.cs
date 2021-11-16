using PG332_SoftwareDesign_EksamenH21.Model;

namespace PG332_SoftwareDesign_EksamenH21.Handlers
{
    public class OptionsHandlerFactory
    {
        public static OptionsHandler MakeOptionsHandler(IProgressable progressable, OptionsHandler superOption)
        {
            if (progressable is User)
            {
                User u = progressable as User;
                OptionsHandler oh = new(u, null, false);
                foreach (var s in u.Semesters)
                {
                    oh.Options.Add(s);
                }
                return oh;
            }

            if (progressable is Semester)
            {
                Semester s = progressable as Semester;
                OptionsHandler oh = new(s, superOption, false);
                foreach (var c in s.Courses)
                {
                    oh.Options.Add(c);
                }
                return oh;
            }

            if (progressable is Course)
            {
                Course c = progressable as Course;
                OptionsHandler oh = new(c, superOption, false);
                foreach (var l in c.Lectures)
                {
                    oh.Options.Add(l);
                }
                return oh;
            }

            if (progressable is Lecture)
            {
                Lecture l = progressable as Lecture;
                OptionsHandler oh = new(l, superOption, true);
                foreach (var t in l.TaskSet.Tasks)
                {
                    oh.Options.Add(t);
                }
                return oh;
            }

            if (progressable is TaskSet)
            {
                TaskSet ts = progressable as TaskSet;
                OptionsHandler oh = new(ts, superOption, false);
                foreach (var t in ts.Tasks)
                {
                    oh.Options.Add(t);
                }

                return oh;
            }
            
            Task task = progressable as Task;
            OptionsHandler optionsHandler = new(task, superOption, true);
            return optionsHandler;
        }
    }
}
