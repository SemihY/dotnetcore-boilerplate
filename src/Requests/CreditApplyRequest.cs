namespace src.Requests
{
    public class CreditApplyRequest
    {
        public int IdentificationNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal Salary { get; set; }
        public string TelephoneNumber { get; set; }
    }
}