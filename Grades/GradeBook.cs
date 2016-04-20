using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
   public class GradeBook
    {
        private List<float> grades;

        //Field
        //public string Name;
        //End Field

        //Auto-implemented Property (implicitly creates the getter and setter)
        //public String Name { get; set; }

        //Property  with explicit getter and setter
        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                //check for null or empty
                if (!String.IsNullOrEmpty(value))
                {
                    //mwilliams:  added exception
                    //use the throw to raise an exception
                    //Exceptions providde type safe and structured error handling
                    throw new ArgumentException("Name cannot be null or empty");

                }
                    //delegates:  detect when name has changed
                    if (_name != value && NameChanged !=null)
                    {
                        //Create an instance of the NameChangedEventArgs class
                        NameChangedEventArgs args = new NameChangedEventArgs();
                        //equal to the value we currently have in _name
                        args.existingName = _name;
                        args.newName = value; //equal to the incoming value

                        NameChanged(this, args);//implicit variable this
                        //pass myself to the NameChanged event

                    }

                     _name = value;

                
            }
        }

        //Convert the NameChangedDelagate to NameChanged Event
        public event NameChangedDelegate NameChanged;


        //Default Constructor method - without parameters
        //type ctor and tab twice (snippet)
        public GradeBook()
        {
            //Initialize name property
            _name = "No name yet";

            //Initialize grade as a new list of float
            grades = new List<float>();

        }

        //internal void AddGrade(double v)
        //{
        //    throw new NotImplementedException();
        //}

        //Create a method to compute grade statistics
        //(lowest, highest and average) scores
        //returns GradeStatistics
        public GradeStatistics ComputeStatistics()
        {
            //Instantiate the GradeStatistics 
            GradeStatistics stats = new GradeStatistics();

            //Loop through all grades (in grades collection)
            //float sum = 0;
            foreach (float grade in grades)
            {
                //get largest of the two (new grade compared the current highest)
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                //get the smallest of the two
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                //sum += grade;//running sum             

            }

            //average
            stats.AverageGrade = grades.Average();
            //or manually
            //stats.AverageGrade = sum / grades.Count;


            //return stats
            return stats;
        }

        //Create a method to add a new grade
        //void:  does not return a value
        public void AddGrade(float grade)
        {
            grades.Add(grade);
        }

        public void WriteGrades(TextWriter destination)
        {
            for (int i = 0; i < grades.Count; i++)
            {
                destination.WriteLine(grades[i]);
            }
        }

        public void WriteGrades(TextWriter destination,string name)
        {
            destination.WriteLine("Gradebook for " + name + ":");
            for (int i = 0; i < grades.Count; i++)
            {
                //destination.WriteLine(grades[i]);
                destination.WriteLine($"{grades[i]:F2}");//formatted grades
            }
        }

    }
}
