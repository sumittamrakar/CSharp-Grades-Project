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
        public GradeBook()
        {
            grades = new List<float>();
        }

        public GradeStatistics ComputeStatistics()
        {
            GradeStatistics stats = new GradeStatistics();

            float sum = 0;
            foreach (float grade in grades)
            {
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
            }
            try
            {
                stats.AverageGrade = sum / grades.Count;//error handling needed
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            return stats;
        }

        public void WriteGrades(TextWriter destination)
        {
            for (int i = grades.Count; i > 0; i--)
            {
                destination.WriteLine(grades[i-1]);
            }
        }

        public void AddGrade(float grade)
        {
            grades.Add(grade);
        }

        private List<float> grades;

        public string Name;
    }
}
