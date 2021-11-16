using System;
using System.IO;
using NUnit.Framework;
using PG332_SoftwareDesign_EksamenH21;
using PG332_SoftwareDesign_EksamenH21.Handlers;
using static PG332_SoftwareDesign_EksamenH21.Handlers.OptionsHandlerFactory;

namespace Test
{
    public class OptionsHandlerTest
    {
        [Test]
        public void ShouldReturnSame()
        {
            // OBS! Linje 108 må kommenteres ut i OptionsHandler for at denne skal kjøre riktig!
            
            TaskSet taskSet = new();
            
            OptionsHandler tsOh = new(taskSet, null, false);

            OptionsHandler actual = tsOh.ChooseOption("t");
            
            Assert.AreEqual(tsOh, actual);
        }

        [Test]
        public void ShouldReturnSubOption()
        {
            Task  task1 = new();
            task1.Published = true;
            
            TaskSet taskSet = new();
            taskSet.Published = true;
            taskSet.Tasks.Add(task1);

            OptionsHandler tsOh = MakeMenuHandler(taskSet, null);

            OptionsHandler expected = new(task1, tsOh, true);

            OptionsHandler actual = tsOh.ChooseOption("1");

            for (int i = 0; i < expected.Options.Count; i++)
            {
                Assert.AreEqual(expected.Options[i], actual.Options[i]);
            }
            
            Assert.AreEqual(expected.SuperOption, actual.SuperOption);
            Assert.AreEqual(expected.IsFinishable, actual.IsFinishable);
            Assert.AreEqual(expected.Progressable, actual.Progressable);
        }

        [Test]
        public void ShouldReturnSuperOption()
        {
            Task  task1 = new();
            task1.Published = true;
            
            TaskSet taskSet = new();
            taskSet.Published = true;
            taskSet.Tasks.Add(task1);
            
            OptionsHandler tsOh = MakeMenuHandler(taskSet, null);

            OptionsHandler actual = tsOh.ChooseOption("1").ChooseOption("0");
            
            Assert.AreEqual(tsOh, actual);
        }

        [Test]
        public void ShouldSetFinished()
        {
            // OBS! Linje 132 må kommenteres ut i OptionsHandler for at denne skal kjøre riktig!
            
            Task task1 = new();
            task1.Published = true;

            OptionsHandler tOh = MakeMenuHandler(task1, null);

            tOh.ChooseOption("F");

            Assert.True(task1.Finished);
        }

        [Test]
        public void ShouldNotReturnSuperOptions()
        {
            Task task1 = new();
            task1.Published = true;

            OptionsHandler tOh = new(task1, null, true);
            OptionsHandler actual = tOh.ChooseOption("0");
            Assert.AreEqual(tOh, actual);
        }
    }
}