namespace Domain.Domain
{
    public class Driver : Entity
    {
        public Driver(string name, int age, Car car)
        {
            Name = name;
            Age = age;
            Car = car;
        }

        protected Driver()
        {
        }

        public virtual string Name { get; protected set; }
        public virtual int Age { get; set; }
        public virtual Car Car { get; set; }
    }
}