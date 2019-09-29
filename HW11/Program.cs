using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11
{
    class Program
    {
        static void Main(string[] args)
        {
            Company company = new Company(6);
            company.ShowAllEmployees();
            company.ShowManagers();
            company.ShowEmployeeLaterBoss();

            Console.ReadKey();
        }
    }
}
