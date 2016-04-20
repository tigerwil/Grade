using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    //Make it public and inherit GradeBook
    public class ThrowAwayGradeBook : GradeBook
    {
        public override GradeStatistics ComputeStatistics()
        {
            Console.WriteLine("ThrowAwayGradeBook::ComputeStatistics");//debug info

            //remove the lowest grade 
            float lowest = float.MaxValue;

            if (grades.Count > 1)//if only one grade is avaible
            {
                foreach (float grade in grades)
                {
                    lowest = Math.Min(grade, lowest);
                }

                grades.Remove(lowest);//remove the lowest grade from grades collection
            }



            //Keep in mind that if only one grade is added - you will
            //have some issues

            //base:  reach specific methods from inherited class
            return base.ComputeStatistics();
        }
    }
}
