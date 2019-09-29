using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter group name and student count: ");
            var groupName = Console.ReadLine();
            int.TryParse(Console.ReadLine(), out int studentCnt);
            Group group = new Group(studentCnt, groupName);


            group.ShowInfo();
            group.ShowQueue();

            Console.ReadKey();
        }
    }
}
