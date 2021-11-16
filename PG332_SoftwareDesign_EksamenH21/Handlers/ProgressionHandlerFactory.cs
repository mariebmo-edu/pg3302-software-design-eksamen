using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PG332_SoftwareDesign_EksamenH21.Model;

namespace PG332_SoftwareDesign_EksamenH21.Handlers
{
    public class ProgressionHandlerFactory
    {
        public static IProgressionHandler<IProgressable> MakeProgressionHandler(IProgressable _progressable)
        {
            if (_progressable is User)
            {
                User u = _progressable as User;

                ProgressionHandlerComposite _progComp = new(u);

                foreach (var s in u.Semesters)
                {
                    _progComp.Children.Add(MakeProgressionHandler(s));
                }

                return _progComp;
            }
            
            if (_progressable is Semester)
            {
                Semester s = _progressable as Semester;

                ProgressionHandlerComposite _progComp = new(s);

                foreach (var c in s.Courses)
                {
                    _progComp.Children.Add(MakeProgressionHandler(c));
                }

                return _progComp;
            }

            if (_progressable is Course)
            {
                Course c = _progressable as Course;

                ProgressionHandlerComposite _progComp = new(c);

                foreach (var l in c.Lectures)
                {
                    _progComp.Children.Add(MakeProgressionHandler(l));
                }

                return _progComp;
            }

            if (_progressable is Lecture)
            {
                Lecture l = _progressable as Lecture;

                ProgressionHandlerComposite _progComp = new(l);

                _progComp.Children.Add(new ProgressionHandlerLeaf(l));
                _progComp.Children.Add(MakeProgressionHandler(l.TaskSet));

                return _progComp;
            }

            if (_progressable is TaskSet)
            {
                TaskSet ts = _progressable as TaskSet;

                ProgressionHandlerComposite _progComp = new(ts);

                foreach (var t in ts.Tasks)
                {
                    _progComp.Children.Add(MakeProgressionHandler(t));
                }

                return _progComp;
            }

            return new ProgressionHandlerLeaf(_progressable as Task);
        }
    }
}
