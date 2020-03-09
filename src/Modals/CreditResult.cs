using src.Enums;

namespace src.Modals
{
    public class CreditResult
    {
        public CreditStatus Status { get; set; }
        public long Limit { get; set; }
        
        public string StatusDescription { get; set; }

        public static CreditResult Success(long limit)
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