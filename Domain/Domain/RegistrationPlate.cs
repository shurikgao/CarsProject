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

        public virtual string Plate { get; set; }
        public virtual Car Car { get; set; }

        //public void Add()
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}