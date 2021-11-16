using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PG332_SoftwareDesign_EksamenH21.Model;

namespace PG332_SoftwareDesign_EksamenH21.Handlers
{
    public class OptionsHandlerFactory
    {
        public static OptionsHandler MakeMenuHandler(IProgressable progressable, OptionsHandler superOptions)
        {
            if (progressable is User)
            {
                User u = progressable as User;
                OptionsHandler mh = new(u, null, false);
                foreach (var s in u.Semesters)
                {
                    mh.Options.Add(s);
                }
                return mh;
            }

            if (progressable is Semester)
            {
                Semester s = progressable as Semester;
                OptionsHandler mh = new(s, superOptions, false);
                foreach (var c in s.Courses)
                {
                    mh.Options.Add(c);
                }
                return mh;
            }

            if (progressable is Course)
            {
                Course c = progressable as Course;
                OptionsHandler mh = new(c, superOptions, false);
                foreach (var l in c.Lectures)
                {
                    mh.Options.Add(l);
                }
                return mh;
            }

            if (progressable is Lecture)
            {
                Lecture l = progressable as Lecture;
                OptionsHandler mh = new(l, superOptions, true);
                foreach (var t in l.TaskSet.Tasks)
                {
                    mh.Options.Add(t);
                }
                return mh;
            }

            if (progressable is TaskSet)
            {
                TaskSet ts = progressable as TaskSet;
                OptionsHandler oh = new(ts, superOptions, false);
                foreach (var t in ts.Tasks)
                {
                    oh.Options.Add(t);
                }

                return oh;
            }
            
            Task task = progressable as Task;
            OptionsHandler optionsHandler = new(task, superOptions, true);
            return optionsHandler;
        }
    }
}
