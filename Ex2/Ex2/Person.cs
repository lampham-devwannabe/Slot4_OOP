using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2
{
    public abstract class Person
    {
        public string Name { get; set; }
        public string Address {  get; set; }

        protected Person(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public abstract void display();
    }

    public class Employee : Person
    {
        public int Salary { get; set; }
        public Employee(string name, string address,  int salary):base(name, address)
        {
            Salary = salary;
        }  
        public override void display()
        {
            Console.WriteLine($"Name: {Name} | Salary:{Salary} | Address:{Address}");
        }
    }

    public class Customer : Person
    {
        public int Balance { get; set; }
        public Customer(string name, string address, int balance):base(name, address)
        {
            Balance = balance;
        }
        public override void display()
        {
            Console.WriteLine($"Name: {Name} | Balance:{Balance} | Address:{Address}");
        }
    }
}
