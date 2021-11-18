using PG332_SoftwareDesign_EksamenH21.Model;

namespace PG332_SoftwareDesign_EksamenH21.Handlers.Progression
{
    public class ProgressionHandlerFactory
    {
        public static IProgressionHandler<IProgressable> MakeProgressionHandler(IProgressable progressable)
        {
            switch (progressable)
            {
                case User user:
                {
                    ProgressionHandlerComposite progComp = new(user);
                
                    foreach (var s in user.Semesters)
                    {
                        progComp.Children.Add(MakeProgressionHandler(s));
                    }

                    return progComp;
                }
                case Semester semester:
                {
                    ProgressionHandlerComposite progComp = new(semester);
                
                    foreach (var c in semester.Courses)
                    {
                        progComp.Children.Add(MakeProgressionHandler(c));
                    }

                    return progComp;
                }
                case Course course:
                {
                    ProgressionHandlerComposite progComp = new(course);
                    progComp.Children.Add(new ProgressionHandlerLeaf(course));

                    if (course.Lectures.Count <= 0) return progComp;
                    foreach (var l in course.Lectures)
                    {
                        progComp.Children.Add(MakeProgressionHandler(l));
                    }

                    return progComp;
                }
                case Lecture lecture:
                {
                    ProgressionHandlerComposite progComp = new(lecture);

                    progComp.Children.Add(new ProgressionHandlerLeaf(lecture));
                    if (lecture.TaskSet.Tasks.Count > 0)
                    {
                        progComp.Children.Add(MakeProgressionHandler(lecture.TaskSet));
                    }
                
                    return progComp;
                }
                case TaskSet taskSet:
                {
                    ProgressionHandlerComposite progComp = new(taskSet);
                
                    foreach (var t in taskSet.Tasks)
                    {
                        progComp.Children.Add(MakeProgressionHandler(t));
                    }
                
                    return progComp;
                }
                default:
                    return new ProgressionHandlerLeaf(progressable as Task);
            }
        }
    }
}
