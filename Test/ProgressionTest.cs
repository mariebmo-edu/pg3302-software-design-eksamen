using NUnit.Framework;
using PG332_SoftwareDesign_EksamenH21;


namespace Test
{
    public class ProgressionTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void NodeNotFinished()
        {
            ProgressionNode TaskProgression = new();
            TaskProgression.Published = true;
            TaskProgression.Finished = false;
            Assert.AreEqual(0.00, TaskProgression.GetProgression());
        }

        [Test]
        public void NodeFinished()
        {
            ProgressionNode TaskProgression = new();
            TaskProgression.Published = true;
            TaskProgression.Finished = true;
            Assert.AreEqual(1.00, TaskProgression.GetProgression());
        }

        [Test]
        public void CompositeWithNodeChildren()
        {
            ProgressionNode TaskProgression1 = new();
            TaskProgression1.Published = true;
            TaskProgression1.Finished = false;

            ProgressionNode TaskProgression2 = new();
            TaskProgression2.Published = true;
            TaskProgression2.Finished = true;

            ProgressionComposite TaskSetProgression = new(2);
            TaskSetProgression.Published = true;
            TaskSetProgression.Children.Add(TaskProgression1);
            TaskSetProgression.Children.Add(TaskProgression2);

            Assert.AreEqual(0.50, TaskSetProgression.GetProgression());
        }

        [Test]
        public void CompositeWithCompositeChildren()
        {
            ProgressionNode Task1 = new();
            Task1.Published = true;
            Task1.Finished = false;

            ProgressionNode Task2 = new();
            Task2.Published = true;
            Task2.Finished = true;

            ProgressionNode Task3 = new();
            Task3.Published = true;
            Task3.Finished = true;

            ProgressionComposite TaskSet1 = new(3);
            TaskSet1.Published = true;
            TaskSet1.Children.Add(Task1);
            TaskSet1.Children.Add(Task2);
            TaskSet1.Children.Add(Task3);



            ProgressionNode Task4 = new();
            Task4.Published = true;
            Task4.Finished = false;

            ProgressionNode Task5 = new();
            Task5.Published = true;
            Task5.Finished = true;

            ProgressionNode Task6 = new();
            Task6.Published = true;
            Task6.Finished = true;

            ProgressionComposite TaskSet2 = new(3);
            TaskSet2.Published = true;
            TaskSet2.Children.Add(Task4);
            TaskSet2.Children.Add(Task5);
            TaskSet2.Children.Add(Task6);



            ProgressionComposite Lecture = new(2);
            Lecture.Published = true;
            Lecture.Children.Add(TaskSet1);
            Lecture.Children.Add(TaskSet2);



            Assert.AreEqual(0.66, Lecture.GetProgression());
        }

        [Test]
        public void CompositeWithNodeAndCompositeChildren()
        {
            ProgressionNode Task1 = new();
            Task1.Published = true;
            Task1.Finished = false;

            ProgressionNode Task2 = new();
            Task2.Published = true;
            Task2.Finished = false;

            ProgressionNode Task3 = new();
            Task3.Published = true;
            Task3.Finished = true;

            ProgressionNode Task4 = new();
            Task4.Published = true;
            Task4.Finished = true;

            ProgressionComposite TaskSet1 = new(4);
            TaskSet1.Published = true;
            TaskSet1.Children.Add(Task1);
            TaskSet1.Children.Add(Task2);
            TaskSet1.Children.Add(Task3);
            TaskSet1.Children.Add(Task4);



            ProgressionNode Lecture = new();
            Lecture.Published = true;
            Lecture.Finished = true;



            ProgressionComposite LectureTotal = new(2);
            LectureTotal.Published = true;
            LectureTotal.Children.Add(TaskSet1);
            LectureTotal.Children.Add(Lecture);



            Assert.AreEqual(0.75, LectureTotal.GetProgression());
        }
    }
}