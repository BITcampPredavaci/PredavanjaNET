using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worker
{
   abstract class Worker
    {
        private static int NumberOfWorkers = 1;
       
        private string name, surname;
        private int id;

        public string Name {
            get { return name; }
            set { name = value; }
        }

        public string Surname
        {
            get { return surname;  }
            set { surname = value; }
        }

        public int Id
        {
            get { return id; }
        }

        public Worker(string name, string surname)
        {
            this.name = name;
            this.surname = surname;
            this.id = NumberOfWorkers;
            NumberOfWorkers++;
        }

        public Worker(Worker other)
        {
            this.name = other.name;
            this.surname = other.surname;
            this.id = other.id;
        }

        public bool Equals(Worker other)
        {
            return this.id == other.id;
        }

        public override string ToString()
        {
            return String.Format(
                "{0}: {1}, {2}",
                this.id, this.surname, this.name
                );
        }

        public abstract double GetSalary();
    }

    class SalaryWorker : Worker
    {
        private double salary;

        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        public SalaryWorker(string name,
            string surname,
            double salary) : base(name, surname)
        {
            this.salary = salary;
        }

        public SalaryWorker(SalaryWorker other) : base(other)
        {
            this.salary = other.salary;
        }

        public override double GetSalary()
        {
            return salary;
        }

    }

    class HourlyWorker : Worker
    {
        private double hourlyRate;

        public double HourlyRate {
            get { return hourlyRate; }
            set { hourlyRate = value; }
        }

        public double HoursWorked { get; set; }

        public HourlyWorker(
            string name,
            string surname,
            double hourlyRate) : base(name, surname)
        {
            this.hourlyRate = hourlyRate;
            this.HoursWorked = 0;
        }

        public HourlyWorker(string name,
            string surname,
            double hourlyRate,
            double hoursWorked) : base(name, surname)
        {
            this.hourlyRate = hourlyRate;
            this.HoursWorked = hoursWorked;
        }

        public override double GetSalary()
        {
            return hourlyRate * HoursWorked;
        }
    }
}
