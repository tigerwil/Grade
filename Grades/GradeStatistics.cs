using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
   public  class GradeStatistics
    {
        //fields
        public float HighestGrade;
        public float LowestGrade;
        public float AverageGrade;

        //Constructor
        public GradeStatistics()
        {
            HighestGrade = 0f;
            LowestGrade = float.MaxValue;

        }

        public string LetterGrade
        {
            get
            {
                string result;

                if(AverageGrade>=90)
                {
                    result = "A";
                }

                else if (AverageGrade >= 80)
                {
                    result = "B";
                }

                else if (AverageGrade >= 70)
                {
                    result = "C";
                }

                else if (AverageGrade >= 60)
                {
                    result = "D";
                }
                else
                {
                    result = "F";
                }

                return result;
            }
        }//LetterGrade

        public string Description
        {
            get
            {
                string result;
                //Switching:  Restricted to integers, characters, strings
                //            and enums
                //Case labels are constants
                //Need a break for each case
                //Default label is optional 

                switch (LetterGrade)
                {
                    case "A":
                        result = "Excellent";
                        break;
                    case "B":
                        result = "Good";
                        break;
                    case "C":
                        result = "Average";
                        break;
                    case "D":
                        result = "Below Average";
                        break;
                    case "F":
                        result = "Failing";
                        break;
                    default:
                        result = "Failing";
                        break;
                }

                return result;
            }
        }
    }
}
