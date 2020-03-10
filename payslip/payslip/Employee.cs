namespace payslip
{
    public class Employee
    {

        public Employee(string firstName, string lastName, double salary, double superRate)
        {
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
            SuperRate = superRate;
        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public double Salary { get; private set; }
        public double SuperRate { get; private set; }
        
        
    }
}