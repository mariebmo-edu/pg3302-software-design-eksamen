using System;
using System.Text;

namespace PG332_SoftwareDesign_EksamenH21.Handlers
{
    public class ProgressionBarHandler
    {
        public static String GenerateProgressBar(ProgressionWrapper progressionWrapper)
        {
            var finishedLength = (long)Math.Round(100 * progressionWrapper.FinishedPercent);
            var publishedLength =(long)Math.Round(100 * progressionWrapper.PublishedPercent) - finishedLength;

            StringBuilder buffer = new();
            buffer.Append('|');
            BarGenerator('#', finishedLength, buffer);
            BarGenerator('=', publishedLength, buffer);
            BarGenerator('-', 101 - buffer.Length, buffer); 
            buffer.Append('|');

            return buffer.ToString();
        }

        private static void BarGenerator(char c, long amount, StringBuilder buffer)
        {
            for (var i = 0; i < amount; i++)
            {
                buffer.Append(c);
            }
        }
    }
}