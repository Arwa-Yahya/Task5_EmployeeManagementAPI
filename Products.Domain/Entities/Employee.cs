
namespace Products.Domain.Entities
{
    public class Employee
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Position { get; private set; }
        public decimal Salary { get; private set; }

        private Employee() {}

        public Employee(string name, string position, decimal salary)
        {
            Name = name;
            Position = position;
            Salary = salary;
        }

        public void Update(string name, string position, decimal salary)
        {
            Name = name;
            Position = position;
            Salary = salary;
        }
    }
}
