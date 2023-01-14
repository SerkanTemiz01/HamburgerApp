using HamburgerAppMvc.Models.Enum;

namespace HamburgerAppMvc.Models
{
    public class Extra
    {
        public int ExtraID { get; set; }

        public string ExtraName { get; set; }

        public decimal Price { get; set; }

        public virtual List<Order>? Orders { get; set; }
        

        public Status Status { get; set; } = Status.Active;
    }
}
