using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            GradeBook book = new GradeBook();

            //book.NameChanged += new NameChangedDelegate(onNameChanged);
            //book.NameChanged += new NameChangedDelegate(onNameChanged2);
            //book.NameChanged += new NameChangedDelegate(onNameChanged2);
            //book.NameChanged += (onNameChanged);
            
            //book.Name = "Scott's Grade Book";
            //book.Name = "Joes's Grade Book";

            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);

            

            GradeStatistics stats = book.ComputeStatistics();
            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest", (int)stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);
            WriteResult("Grade", stats.Description);
            
            //Console.WriteLine(book.Name);
            //Console.WriteLine(stats.AverageGrade);
            //Console.WriteLine(stats.HighestGrade);
            //Console.WriteLine(stats.LowestGrade);
            
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
