using PG332_SoftwareDesign_EksamenH21.Model;

namespace PG332_SoftwareDesign_EksamenH21.Handlers
{
    public class ProgressionHandlerFactory
    {
        public static IProgressionHandler<IProgressable> MakeProgressionHandler(IProgressable progressable)
        {
            if (progressable is User)
            {
                User u = progressable as User;

                ProgressionHandlerComposite progComp = new(u);
                
                foreach (var s in u.Semesters)
                {
                    progComp.Children.Add(MakeProgressionHandler(s));
                }

                return progComp;
            }
            
            if (progressable is Semester)
            {
                Semester s = progressable as Semester;

                ProgressionHandlerComposite progComp = new(s);

                foreach (var c in s.Courses)
                {
                    progComp.Children.Add(MakeProgressionHandler(c));
                }

                return progComp;
            }

            if (progressable is Course)
            {
                Course c = progressable as Course;

                if (c.Lectures.Count > 0)
                {
                    ProgressionHandlerComposite progComp = new(c);

                    foreach (var l in c.Lectures)
                    {
                        progComp.Children.Add(MakeProgressionHandler(l));
                    }
                    
                    return progComp;
                }

                return new ProgressionHandlerLeaf(c);
            }

            if (progressable is Lecture)
            {
                Lecture l = progressable as Lecture;

                ProgressionHandlerComposite progComp = new(l);

                progComp.Children.Add(new ProgressionHandlerLeaf(l));
                if (l.TaskSet.Tasks.Count > 0)
                {
                    progComp.Children.Add(MakeProgressionHandler(l.TaskSet));
                }
                
                return progComp;
            }

            if (progressable is TaskSet)
            {
                TaskSet ts = progressable as TaskSet;

                ProgressionHandlerComposite progComp = new(ts);
                
                foreach (var t in ts.Tasks)
                {
                    progComp.Children.Add(MakeProgressionHandler(t));
                }
                
                return progComp;
            }

            return new ProgressionHandlerLeaf(progressable as Task);
        }
    }
}
