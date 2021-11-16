using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PG332_SoftwareDesign_EksamenH21.Model;

namespace PG332_SoftwareDesign_EksamenH21.Handlers
{
    class MenuHandlerFactory
    {
        public static MenuHandler MakeMenuHandler(IProgressable progressable)
        {
            if (progressable is User)
            {
                User u = progressable as User;
                MenuHandler mh = new(u, false);
                foreach (var s in u.Semesters)
                {
                    mh.Options.Add(s);
                }
                return mh;
            }

            if (progressable is Semester)
            {
                Semester s = progressable as Semester;
                MenuHandler mh = new(s, false);
                foreach (var c in s.Courses)
                {
                    mh.Options.Add(c);
                }
                return mh;
            }

            if (progressable is Course)
            {
                Course c = progressable as Course;
                MenuHandler mh = new(c, false);
                foreach (var l in c.Lectures)
                {
                    mh.Options.Add(l);
                }
                return mh;
            }

            if (progressable is Lecture)
            {
                Lecture l = progressable as Lecture;
                MenuHandler mh = new(l, true);
                foreach (var t in l.TaskSet.Tasks)
                {
                    mh.Options.Add(t);
                }
                return mh;
            }
            /*
            if (progressable is TaskSet)
            {
                TaskSet ts = progressable as TaskSet;
                MenuHandler mh = new(ts, false);
                foreach (var t in ts.Tasks)
                {
                    mh.Options.Add(t);
                }
                return mh;
            }
            */
            Task task = progressable as Task;
            MenuHandler MenuHandler = new(task, true);
            return MenuHandler;
        }
    }
}
