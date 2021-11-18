using NUnit.Framework;
using PG332_SoftwareDesign_EksamenH21;
using PG332_SoftwareDesign_EksamenH21.Handlers;
using PG332_SoftwareDesign_EksamenH21.Model;
using PG332_SoftwareDesign_EksamenH21.Handlers.Printable;
using PG332_SoftwareDesign_EksamenH21.Model;
using static PG332_SoftwareDesign_EksamenH21.Handlers.Printable.OptionsWrapperFactory;

namespace Test
{
    public class OptionsHandlerTest
    {
        [Test]
        public void ShouldReturnErrorMessage()
        {
            TaskSet taskSet = new();
            
            OptionsWrapper tsOh = new(taskSet, null, false);

            ErrorMessageWrapper expected = new("Velg et gyldig menyalternativ", tsOh);
            
            ErrorMessageWrapper actual = tsOh.ChooseOption("t") as ErrorMessageWrapper;
            
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ShouldReturnSubOption()
        {
            Task  task1 = new();
            task1.Published = true;
            
            TaskSet taskSet = new();
            taskSet.Published = true;
            taskSet.Tasks.Add(task1);

            OptionsWrapper tsOh = MakeOptionsWrapper(taskSet, null);

            OptionsWrapper expected = new(task1, tsOh, true);

            OptionsWrapper actual = tsOh.ChooseOption("1") as OptionsWrapper;
            
            for (int i = 0; i < expected.Options.Count; i++)
            {
                Assert.AreEqual(expected.Options[i], actual.Options[i]);
            }
            
            Assert.AreEqual(expected.SuperOption, actual.SuperOption);
            Assert.AreEqual(expected.IsFinishable, actual.IsFinishable);
            Assert.AreEqual(expected.Publishable, actual.Publishable);
        }

        [Test]
        public void ShouldReturnSuperOption()
        {
            Task  task1 = new();
            task1.Published = true;
            
            TaskSet taskSet = new();
            taskSet.Published = true;
            taskSet.Tasks.Add(task1);
            
            OptionsWrapper expected = MakeOptionsWrapper(taskSet);

            OptionsWrapper temp = expected.ChooseOption("1") as OptionsWrapper;
            
            OptionsWrapper actual = temp.ChooseOption("0") as OptionsWrapper;
            
            //ErrorMessageWrapper actual = tsOh.ChooseOption("t") as ErrorMessageWrapper;
            
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ShouldSetFinished()
        {
            Task task1 = new();
            task1.Published = true;

            OptionsWrapper tOh = MakeOptionsWrapper(task1, null);

            tOh.ChooseOption("F");

            Assert.True(task1.Finished);
        }

        [Test]
        public void ShouldNotReturnSuperOptions()
        {
            Task task1 = new();
            task1.Published = true;

            OptionsWrapper tOh = new(task1, null, true);
            OptionsWrapper actual = tOh.ChooseOption("0") as OptionsWrapper;
            Assert.AreEqual(tOh, actual);
        }
    }
}