using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11_2
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FullName { get; set; }
        public string Group { get; set; }
        public double AvgMark { get; set; }
        public double IncomeForMember { get; set; }
        public Gender Gender { get; set; }
        public LearningForm LearningForm { get; set; }
    }
}
