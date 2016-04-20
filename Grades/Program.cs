using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instantiate the Gradebook
            GradeBook book = new GradeBook();

            GetBookName(book);
            AddGrades(book);
            SaveGrades(book);
            WriteResults(book);
            ViewGrades(book);

        }

        private static void ViewGrades(GradeBook book)
        {
            using (StreamReader inputFile =
                File.OpenText(book.Name + "_grades.txt"))
            {
                Console.WriteLine("*******************************");
                string s = "";
                while ((s = inputFile.ReadLine()) != null)
                {
                    Console.WriteLine(s);//write the current line to screen
                }

                Console.WriteLine("*******************************");
            }
        }

        private static void WriteResults(GradeBook book)
        {
            //Instantiate the GradeStatistics
            GradeStatistics stats  =book.ComputeStatistics();
            WriteResults("Average", stats.AverageGrade);
            WriteResults("Highest", stats.HighestGrade);
            WriteResults("Lowest", stats.LowestGrade);
            WriteResults(stats.Description, stats.LetterGrade);
        }

        private static void WriteResults(string description, string result)
        {
            Console.WriteLine($"{description}: {result}");
        }

        private static void WriteResults(string description, float result)
        {
            Console.WriteLine($"{description}: {result:F2}");
        }

        private static void SaveGrades(GradeBook book)
        {
            using (StreamWriter outputFile =
                File.CreateText(book.Name + "_grades.txt"))
            {
                book.WriteGrades(outputFile, book.Name);
            }
            /* Using Statement
             * When  you are using an object that encapsulates any
             * resources (ie. file, database) you have to make sure
             * that when you are done with the object, you dispose it
             * The Using Statement takes care of that automatically
             * 
             */
        }

        private static void AddGrades(GradeBook book)
        {
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);
            book.AddGrade(95);
        }

        private static void GetBookName(GradeBook book)
        {
            try
            {
                Console.WriteLine("Enter a name");
                book.Name = Console.ReadLine();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
               
            }
            //Chaining: Place most specific type in first catch clause
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }//GetBookName
    }//Program class
}//Namepace
