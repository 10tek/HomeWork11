using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11_2
{
    public class Group
    {
        private int twoMinSalary = 50000;
        private static Random random = new Random();
        private List<Student> group;

        public Group(int studentCnt, string groupName)
        {
            group = new List<Student>();
            for (var i = 0; i < studentCnt; i++)
            {
                Console.WriteLine("\nEnter student name: ");
                group.Add(new Student()
                {
                    StudentId = i,
                    FullName = Console.ReadLine(),
                    Group = groupName,
                    AvgMark = Math.Round(random.NextDouble() * 3 + 2, 1), //от 2 до 5 рандомное double число которую округлили до 1 знака после запятой
                    IncomeForMember = Math.Round(random.NextDouble() * 50000 + 30000, 1),
                    Gender = (Gender)random.Next(2),
                    LearningForm = (LearningForm)random.Next(3)
                });
            }
        }

        public void ShowInfo()
        {
            foreach (var student in group)
            {
                Console.WriteLine($"FullName:        {student.FullName}");
                Console.WriteLine($"Group:           {student.Group}");
                Console.WriteLine($"AvgMark:         {student.AvgMark}");
                Console.WriteLine($"IncomeForMember: {student.IncomeForMember}");
                Console.WriteLine($"Gender:          {student.Gender}");
                Console.WriteLine($"LearningForm:    {student.LearningForm}\n");
            }
        }

        public void ShowQueue()
        {
            Console.WriteLine("\nВыводится очередь на общагу: ");
            var newGroup = new List<Student>();
            group.Sort((a, b) => b.AvgMark.CompareTo(a.AvgMark));
            foreach (var student in group)
            {
                if (student.IncomeForMember < twoMinSalary)
                {
                    newGroup.Add(student);
                }
            }
            foreach (var student in group)
            {
                if (!newGroup.Contains(student))
                {
                    newGroup.Add(student);
                }
            }
            foreach(var student in newGroup)
            {
                Console.WriteLine(student.FullName);
            }
        }

    }
}
