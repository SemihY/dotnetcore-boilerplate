using CreditApi.Enums;

namespace CreditApi.Modals
{
    public class CreditResult
    {
        public CreditStatus Status { get; set; }
        public decimal Limit { get; set; }
        public string StatusDescription { get; set; }

        private CreditResult() {}

        public static CreditResult Success(decimal limit)
        {
            return new CreditResult
            {
                Limit = limit,
                Status = CreditStatus.Applied,
                StatusDescription = "Credit applied"
            };
        }
        
        public static CreditResult Fail()
        {
            return new CreditResult
            {
                Limit = 0,
                Status = CreditStatus.NotApplied,
                StatusDescription = "Credit not applied"
            };
        }
        
    }
}