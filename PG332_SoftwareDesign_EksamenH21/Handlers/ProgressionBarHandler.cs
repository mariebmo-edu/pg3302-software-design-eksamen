using System;
using System.Text;
using PG332_SoftwareDesign_EksamenH21.Handlers;

namespace PG332_SoftwareDesign_EksamenH21
{
    public class ProgressionBarHandler
    {
        public static String GenerateProgressBar(ProgressionWrapper progressionWrapper)
        {
            long finishedLength = (long)Math.Round(100 * progressionWrapper.FinishedPercent);
            long publishedLength =(long)Math.Round(100 * progressionWrapper.PublishedPercent) - finishedLength;

            StringBuilder buffer = new();
            buffer.Append("|");
            BarGenerator('#', finishedLength, buffer);
            BarGenerator('=', publishedLength, buffer);
            BarGenerator('-', 101 - buffer.Length, buffer); 
            buffer.Append("|");

            return buffer.ToString();
        }

        private static void BarGenerator(char c, long amount, StringBuilder buffer)
        {
            for (int i = 0; i < amount; i++)
            {
                buffer.Append(c);
            }
        }
    }
}