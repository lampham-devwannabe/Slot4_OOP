using System.Dynamic;
using System.Net;

namespace Ex2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Customer> cList = new List<Customer>();
            List<Employee> eList = new List<Employee>();
            while (true)
            {
                Console.WriteLine("--- Menu ---");
                Console.WriteLine("1. Add employee");
                Console.WriteLine("2. Add customer");
                Console.WriteLine("3. Find max salary & min balance");
                Console.WriteLine("4. Display all person");
                Console.WriteLine("5. Find employee by name");
                Console.WriteLine("0. Exit");
                int choice = CheckMinMax("Choose 1-4: ", 0, 5);
                switch (choice)
                {
                    case 0:
                        {
                            return;
                        }
                    case 1:
                        {
                            AddEmployee(eList);
                            break;
                        }
                    case 2:
                        {
                            AddCustomer(cList);
                            break;
                        }
                    case 3:
                        {
                            Employee max = FindMaxSalary(eList);
                            Customer min = FindMinBalance(cList);
                            if (max != null && min != null)
                            {
                                max.display();
                                min.display();
                            } else
                            {
                                Console.WriteLine("Error");
                            }
                            break;
                        }
                    case 4:
                        {
                            foreach (Employee e in eList)
                            {
                                e.display();
                            }
                            foreach (Customer c in cList)
                            {
                                c.display();
                            }
                            break;
                        }
                    case 5:
                        {
                            Employee e = FindByName(eList);
                            if (e != null)
                            {
                                Console.WriteLine(e.ToString());
                            }
                            else
                            {
                                Console.WriteLine("Employee not found");
                            }
                            break;
                        }
                }
            }
        }

        public static string GetString(string msg)
        {
            Console.Write(msg);
            while (true)
            {
                try
                {
                    string s = Console.ReadLine();
                    if (string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s))
                    {
                        throw new Exception();
                    }
                    return s;
                }
                catch (Exception)
                {
                    Console.Write("Invalid string input. Please enter again: ");
                }
            }
        }

        public static int CheckMinMax(string msg, int min, int max)
        {
            Console.Write(msg);
            while (true)
            {
                try
                {
                    int a = int.Parse(Console.ReadLine());
                    if (a < min || a > max)
                    {
                        throw new Exception();
                    }
                    return a;
                }
                catch (Exception)
                {
                    Console.Write($"Invalid int input. Please enter an int from {min} to {max}: ");
                }
            }
        }

        public static Employee FindMaxSalary(List<Employee> eList)
        {
            Employee max = new Employee("", "", int.MaxValue);
            foreach (Employee e in eList)
            {
                if (e.Salary > max.Salary)
                {
                    max = e;
                }
            }
            return max;
        }

        public static Customer FindMinBalance(List<Customer> cList)
        {
            Customer min = new Customer("", "", 0);
            foreach (Customer c in cList)
            {
                if (c.Balance < min.Balance)
                {
                    min = c;
                }
            }
            return min;
        }

        public static Employee FindByName(List<Employee> eList)
        {
            string find = GetString("Enter name: ");
            Employee e = null;
            foreach (Employee em in eList)
            {
                if (em.Name.Equals(find))
                {
                    e = em;
                }
            }
            return e;
        }

        public static void AddEmployee(List<Employee> eList)
        {
            string name = GetString("Enter name: ");
            string add = GetString("Enter address: ");
            int salary = CheckMinMax("Enter salary: ", 1, int.MaxValue);
            Employee e = new Employee(name, add, salary);
            eList.Add(e);
        }

        public static void AddCustomer(List<Customer> cList)
        {
            string name = GetString("Enter name: ");
            string add = GetString("Enter address: ");
            int balance = CheckMinMax("Enter balance: ", 1, int.MaxValue);
            Customer c = new Customer(name, add, balance);
            cList.Add(c);
        }
    }
}
