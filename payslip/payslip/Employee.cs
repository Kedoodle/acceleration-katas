namespace payslip
{
    public class Employee
    {

        public Employee(string firstName, string lastName, float salary, float superRate)
        {
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
            SuperRate = superRate;
        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public float Salary { get; private set; }
        public float SuperRate { get; private set; }
        
        
    }
}