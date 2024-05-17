namespace Ex1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            while (true)
            {
                Console.WriteLine("--- Menu ---");
                Console.WriteLine("1. Add fulltime employee");
                Console.WriteLine("2. Add partime employee");
                Console.WriteLine("3. Find max salary part time & fulltime ");
                Console.WriteLine("4. Display all employees");
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
                            AddFullTimeEmployee(employees);
                            break;
                        }
                    case 2:
                        {
                            AddPartTimeEmployee(employees);
                            break;
                        }
                    case 3:
                        {
                            Employee full = FindMaxFullTime(employees);
                            Employee part = FindMaxPartTime(employees);
                            Console.WriteLine(full.ToString());
                            Console.WriteLine(part.ToString());
                            break;
                        }
                    case 4:
                        {
                            foreach (Employee emp in employees)
                            {
                                Console.WriteLine(emp.ToString());
                            }
                            break;
                        }
                    case 5:
                        {
                            Employee e = FindByName(employees);
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

        public static Employee FindMaxFullTime(List<Employee> employees)
        {
            Employee fullMax = new FullTimeEmployee("", 0);
            foreach (Employee e in employees)
            {
                if (e is FullTimeEmployee && e.CalculateSalary() > fullMax.CalculateSalary())
                {
                    fullMax = e;
                }
            }
            return fullMax;
        }

        public static Employee FindMaxPartTime(List<Employee> employees)
        {
            Employee partMax = new PartTimeEmployee("", 0, 0);
            foreach (Employee e in employees)
            {
                if (e is PartTimeEmployee && e.CalculateSalary() > partMax.CalculateSalary())
                {
                    partMax = e;
                }
            }
            return partMax;
        }

        public static void AddPartTimeEmployee(List<Employee> employees)
        {
            string name = GetString("Enter name: ");
            int paymentPerHour = CheckMinMax("Enter payment/hour: ", 1, int.MaxValue);
            int workingHour = CheckMinMax("Enter working hour: ", 1, 24);
            PartTimeEmployee pe = new PartTimeEmployee(name, paymentPerHour, workingHour);
            employees.Add(pe);
        }

        public static void AddFullTimeEmployee(List<Employee> employees)
        {
            string name = GetString("Enter name: ");
            int paymentPerHour = CheckMinMax("Enter payment/hour: ", 1, int.MaxValue);
            FullTimeEmployee fe = new FullTimeEmployee(name, paymentPerHour);
            employees.Add(fe);
        }

        public static Employee FindByName(List<Employee> employees)
        {
            string find = GetString("Enter a name to find: ");
            Employee found = null;
            foreach (Employee e in employees)
            {
                if (e.Name.Equals(find))
                {
                    found = e;
                }
            }
            return found;
        }

        
    }
}
