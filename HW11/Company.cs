using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11
{
    public class Company
    {
        private static Random random = new Random();
        private List<Employee> employees = new List<Employee>();

        public Company(int employeeCnt)
        {
            Console.WriteLine("Введите имя сотрудника, должность, зарплата и дата определяется рандомно.");
            for(var i = 0; i < employeeCnt; i++)
            {
                employees.Add(new Employee
                {
                    Name = Console.ReadLine(),
                    Salary = random.Next(100,200),
                    ReceiptDate = new int[] { random.Next(1, 30), random.Next(1, 13), random.Next(2010, 2019) },
                    Vacancy = (Vacancies)(i < 6 ? i : random.Next(1, 6)) //до итерации 6, должность сотрудников будет идти последоветельно, а потом уже рандом.
                });
            }
        }

        public void ShowAllEmployees()
        {
            foreach (var employee in employees)
            {
                ShowEmployee(employee);
            }
        }


        public void ShowManagers()
        {
            Console.WriteLine("\n-----Вывод менеджеров чья зарплата выше клерков------");
            List<Employee> managers = new List<Employee>();
            foreach (var manager in employees)
            {
                if (manager.Vacancy == Vacancies.Manager && manager.Salary > AvarageClerkSalary())
                {
                   managers.Add(manager);
                }
            }
            managers.Sort((a, b) => a.Name.CompareTo(b.Name)); // с интернета взял, не совсем понял че тут происходит :D
            foreach(var manager in managers)
            {
                ShowEmployee(manager);
            }
        }

        public void ShowEmployeeLaterBoss()
        {
            Console.WriteLine("\n-----Вывод сотрудников, которые поступили на рабоут позже босса-----");
            List<Employee> youngerEmps = new List<Employee>();
            var empBoss = employees.Find(x => x.Vacancy == Vacancies.Boss);
            foreach (var employee in employees)
            {
                if (employee.ReceiptDate[2] > empBoss.ReceiptDate[2]) // если год больше
                {
                    youngerEmps.Add(employee);
                }
                else if (employee.ReceiptDate[2] == empBoss.ReceiptDate[2]) // если года равны,
                {
                    if (employee.ReceiptDate[1] > empBoss.ReceiptDate[1]) // проверка по месяцам
                    {
                        youngerEmps.Add(employee);
                    }
                    else if (employee.ReceiptDate[1] == empBoss.ReceiptDate[1]) //если они тоже равны
                    {
                        if (employee.ReceiptDate[0] > empBoss.ReceiptDate[0]) //проверка по дням.
                        {
                            youngerEmps.Add(employee);
                        }
                    }
                }
            }
            youngerEmps.Sort((a, b) => a.Name.CompareTo(b.Name));
            foreach (var emp in youngerEmps)
            {
                ShowEmployee(emp);
            }
        }

        private void ShowEmployee(Employee employee)
        {
            Console.WriteLine($"\nИмя: {employee.Name}");
            Console.WriteLine($"Зарплата: {employee.Salary}");
            Console.WriteLine($"Должность: {employee.Vacancy}");
            Console.WriteLine($"Дата приема: {employee.ReceiptDate[0]}.{employee.ReceiptDate[1]}.{employee.ReceiptDate[2]}\n");
        }

        private double AvarageClerkSalary()
        {
            var salarySum = 0;
            var clerkCnt = 0;
            foreach (var clerk in employees)
            {
                if (clerk.Vacancy == Vacancies.Clerk)
                {
                    salarySum += clerk.Salary;
                    clerkCnt++;
                }
            }
            return (double)salarySum / clerkCnt;
        }
        
    }
}
