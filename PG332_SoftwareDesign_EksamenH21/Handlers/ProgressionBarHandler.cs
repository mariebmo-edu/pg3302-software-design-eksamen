using System;
using System.Text;
using PG332_SoftwareDesign_EksamenH21.Handlers;

namespace PG332_SoftwareDesign_EksamenH21
{
    public class ProgressionBarHandler
    {
        public static String GenerateProgressBar(ProgressionWrapper progressionWrapper)
        {
            int finishedLength = Convert.ToInt32(100 * progressionWrapper.FinishedPercent);
            int publishedLength = Convert.ToInt32(100 * progressionWrapper.PublishedPercent) - finishedLength;

            StringBuilder buffer = new();
            buffer.Append("|");
            BarGenerator('#', finishedLength, buffer);
            BarGenerator('=', publishedLength, buffer);
            BarGenerator('-', 101 - buffer.Length, buffer); 
            buffer.Append("|");

            return buffer.ToString();
        }

        private static void BarGenerator(char c, int amount, StringBuilder buffer)
        {
            for (int i = 0; i < amount; i++)
            {
                buffer.Append(c);
            }
        }
    }
}