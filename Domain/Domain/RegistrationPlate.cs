namespace Domain.Domain
{
    public class RegistrationPlate : Entity
    {
        public RegistrationPlate(string plate, Car car)
        {
            Plate = plate;
            Car = car;
        }

        protected RegistrationPlate()
        {
        }

        public virtual string Plate { get; protected set; }
        public virtual Car Car { get; set; }
    }
}