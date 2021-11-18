using NUnit.Framework;
using PG332_SoftwareDesign_EksamenH21.Handlers;
using PG332_SoftwareDesign_EksamenH21.Model;

namespace Test
{
    class ProgressionHandlerTest
    {
        [Test]
        public void NodeNotPublishedAndNotFinished()
        {
            Task task = new();

            Assert.AreEqual(
                new ProgressionWrapper(0.00, 0.00),
                ProgressionHandlerFactory.MakeProgressionHandler(task).GetProgression());
        }

        [Test]
        public void NodeNotPublishedAndFinished()
        {
            Task task = new() {Finished = true};

            Assert.AreEqual(
                new ProgressionWrapper(0.00, 0.00),
                ProgressionHandlerFactory.MakeProgressionHandler(task).GetProgression());
        }

        [Test]
        public void NodePublishedAndNotFinished()
        {
            Task task = new() {Published = true};

            Assert.AreEqual(
                new ProgressionWrapper(1.00, 0.00),
                ProgressionHandlerFactory.MakeProgressionHandler(task).GetProgression());
        }

        [Test]
        public void NodePublishedAndFinished()
        {
            Task task = new() {Published = true, Finished = true};

            Assert.AreEqual(
                new ProgressionWrapper(1.00, 1.00),
                ProgressionHandlerFactory.MakeProgressionHandler(task).GetProgression());
        }

        [Test]
        public void NotPublishedCompositeWithPublishedLeafChildren()
        {
            Task task1 = new() {Published = true};

            Task task2 = new() {Published = true, Finished = true};

            TaskSet taskSet = new();
            taskSet.Tasks.Add(task1);
            taskSet.Tasks.Add(task2);

            Assert.AreEqual(
                new ProgressionWrapper(0.00, 0.00),
                ProgressionHandlerFactory.MakeProgressionHandler(taskSet).GetProgression());
        }

        [Test]
        public void PublishedCompositeWithAnyLeafChildren()
        {
            Task task1 = new();

            Task task2 = new() {Published = true, Finished = true};

            Task task3 = new() {Published = true};

            Task task4 = new() {Finished = true};

            TaskSet taskSet = new() {Published = true};
            taskSet.Tasks.Add(task1);
            taskSet.Tasks.Add(task2);
            taskSet.Tasks.Add(task3);
            taskSet.Tasks.Add(task4);

            Assert.AreEqual(
                new ProgressionWrapper(0.50, 0.25),
                ProgressionHandlerFactory.MakeProgressionHandler(taskSet).GetProgression());
        }

        [Test]
        public void CompositeWithLeafAndCompositeChildren()
        {
            Task task1 = new() {Published = true, Finished = true};

            Task task2 = new() {Published = true};

            TaskSet taskSet1 = new() {Published = true};
            taskSet1.Tasks.Add(task1);
            taskSet1.Tasks.Add(task2);

            Task task3 = new() {Published = true};

            Task task4 = new() {Published = true};

            TaskSet taskSet2 = new() {Published = true};
            taskSet2.Tasks.Add(task3);
            taskSet2.Tasks.Add(task4);

            Task task5 = new();

            Task task6 = new();

            TaskSet taskSet3 = new();
            taskSet3.Tasks.Add(task5);
            taskSet3.Tasks.Add(task6);

            Lecture lecture1 = new() {Published = true, Finished = true, TaskSet = taskSet1};

            Lecture lecture2 = new() {Published = true, TaskSet = taskSet2};

            Lecture lecture3 = new() {TaskSet = taskSet3};

            Course course = new() {Published = true};
            course.Lectures.Add(lecture1);
            course.Lectures.Add(lecture2);
            course.Lectures.Add(lecture3);

            Assert.AreEqual(
                new ProgressionWrapper(0.66, 0.25),
                ProgressionHandlerFactory.MakeProgressionHandler(course).GetProgression()
            );
        }
    }
}