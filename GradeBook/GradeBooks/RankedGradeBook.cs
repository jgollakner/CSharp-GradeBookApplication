using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook:BaseGradeBook
    {
        public RankedGradeBook(string name):base(name)  
        {
            Type = GradeBookType.Ranked;
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a " +
                    "student's overall grade.");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a " +
                    "student's overall grade.");
            }
            else
            {
                base.CalculateStatistics();
            }
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }

            //This will tell you what 20% of your students number is
            var studentThreshold = (int)Math.Ceiling(Students.Count * .20);
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();


            if (grades[studentThreshold - 1] <= averageGrade)
            {
                return 'A';
            }
            else if (grades[(studentThreshold * 2) - 1] <= averageGrade)
            {
                return 'B';
            }
            else if (grades[(studentThreshold * 3) - 1] <= averageGrade)
            {
                return 'C';
            }
            else if (grades[(studentThreshold * 4) - 1] <= averageGrade)
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        }
    }
}
