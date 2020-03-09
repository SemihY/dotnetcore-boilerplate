namespace src.Entities
{
    public class Credit
    {
        public long Id { get; set; }
        public int IdentificationNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal Salary { get; set; }
        public string TelephoneNumber { get; set; }
        public long CreditLimit { get; set; }
    }
}