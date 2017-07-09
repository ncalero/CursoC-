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
            IGradeTracker book = CreateGradeBook();

            GetBookName(book);


            //book.NameChanged += new NameChangedDelegate(onNameChanged);
            //book.NameChanged += new NameChangedDelegate(onNameChanged2);
            //book.NameChanged += new NameChangedDelegate(onNameChanged2);
            //book.NameChanged += (onNameChanged);

            //book.Name = "Scott's Grade Book";
            //book.Name = "Joes's Grade Book";

            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);

            SaveGrades(book);
            WriteResults(book);

            //Console.WriteLine(book.Name);
            //Console.WriteLine(stats.AverageGrade);
            //Console.WriteLine(stats.HighestGrade);
            //Console.WriteLine(stats.LowestGrade);

        }

        private static void WriteResults(IGradeTracker book)
        {
            GradeStatistics stats = book.ComputeStatistics();

            foreach (float grade in book)
            {
                Console.WriteLine(grade);
            }
            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest", (int)stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);
            WriteResult("Grade", stats.Description);
        }

        private static void SaveGrades(IGradeTracker book)
        {
            using (StreamWriter outputFile = File.CreateText("grades.txt"))
            {
                book.WriteGrades(outputFile);

            }
        }

        private static IGradeTracker CreateGradeBook()
        {
            return new ThrowAwayGradeBook();
        }

        private static void GetBookName(IGradeTracker book)
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
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Something went wrong!");
            }
        }

        //static void onNameChanged(object sender, NameChangedEventArgs args)
        //{
        //    Console.WriteLine($"Grade book changing name from {args.ExistingName} to {args.NewName}");
        //}


        static void WriteResult(string description, string result)
        {
            Console.WriteLine("{0}: {1}", description, result);        
        }

        static void WriteResult(string description, int result)
        {
            Console.WriteLine(description + ": " + result);
        }

        static void WriteResult(string description, float result)
        {
            Console.WriteLine("{0}: {1:F2}", description, result);
            //Console.WriteLine($"{description}: {result:F2}", description, result);
        }
    }
}
