using System;
using System.Text;
using PG332_SoftwareDesign_EksamenH21.Handlers;

namespace PG332_SoftwareDesign_EksamenH21
{
    public class ProgressionBarHandler
    {
        public static String GenereteProgressbar(ProgressionWrapper progressionWrapper)
        {
            String sample = "|####################==========----------|";


            double finishedLength = 100 * progressionWrapper.FinishedPercent;
            double publishedLength = (100 * progressionWrapper.PublishedPercent) - finishedLength;
            
            String buffer = "|";
            buffer += barGenerator('#', Convert.ToInt32(finishedLength));
            buffer += barGenerator('=', Convert.ToInt32(publishedLength));
            buffer += barGenerator('-', 100 - buffer.Length - 1);

            return buffer;
        }

        public static String barGenerator(char c, int amount)
        {
            StringBuilder buffer = new();
            for (int i = 0; i < amount; i++)
            {
                buffer.Append(c);
            }
            return buffer.ToString();
        }
    }
}